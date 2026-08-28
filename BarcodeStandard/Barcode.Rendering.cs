using BarcodeStandard;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BarcodeLib
{
    public partial class Barcode
    {
        #region Image Functions
        /// <summary>
        /// Create and preconfigures a Bitmap for use by the library. Ensures it is independent from
        /// system DPI, etc.
        /// </summary>
        internal Bitmap CreateBitmap(int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            bitmap.SetResolution(HoritontalResolution, VerticalResolution);
            return bitmap;
        }
        /// <summary>
        /// Returns true if the given symbology is a 2D/matrix type (e.g. QR Code), whose encoded
        /// data is a 2D grid of modules rather than a 1D bar/space sequence.
        /// </summary>
        internal static bool IsMatrixSymbology(TYPE type)
        {
            return type == TYPE.QRCODE;
        }
        /// <summary>
        /// Calculates the module size and centering offset for rendering a square 2D/matrix
        /// symbol (e.g. QR Code) within a <paramref name="totalWidthPx"/> x
        /// <paramref name="totalHeightPx"/> canvas, reserving <paramref name="quietZoneModules"/>
        /// modules of clear margin on each side. The symbol is centered and rendered as large as
        /// possible while staying square (matrix symbologies are not stretched to fill a
        /// non-square canvas).
        /// </summary>
        internal (int moduleSizePx, int offsetX, int offsetY, int contentPx) CalculateMatrixGeometry(int totalWidthPx, int totalHeightPx, int moduleCount, int quietZoneModules)
        {
            int totalModules = moduleCount + (2 * quietZoneModules);
            int moduleSizePx = Math.Max(1, Math.Min(totalWidthPx, totalHeightPx) / totalModules);
            int contentPx = moduleSizePx * totalModules;
            int offsetX = (totalWidthPx - contentPx) / 2;
            int offsetY = (totalHeightPx - contentPx) / 2;
            return (moduleSizePx, offsetX, offsetY, contentPx);
        }
        /// <summary>
        /// Calculates the per-module bar width and quiet-zone/alignment shift for a linear
        /// symbol drawn across <paramref name="totalWidthPx"/> pixels, reserving a GS1-compliant
        /// quiet zone (per <see cref="Gs1QuietZone"/>) on each side when
        /// <see cref="EnforceGS1QuietZone"/> is true. When false, this reproduces the pre-3.2.0
        /// geometry (no reserved quiet zone; whole remainder goes to alignment shift only).
        /// </summary>
        internal (int barWidth, int quietZonePx, int shiftAdjustment) CalculateModuleGeometry(int totalWidthPx, int moduleCount)
        {
            int quietZoneModules = EnforceGS1QuietZone ? Gs1QuietZone.GetQuietZoneModules(Encoded_Type) : 0;
            int barWidth = totalWidthPx / (moduleCount + (2 * quietZoneModules));
            int quietZonePx = quietZoneModules * barWidth;
            int usedWidth = (barWidth * moduleCount) + (2 * quietZonePx);
            int remainder = totalWidthPx - usedWidth;

            int shiftAdjustment;
            switch (Alignment)
            {
                case AlignmentPositions.LEFT:
                    shiftAdjustment = quietZonePx;
                    break;
                case AlignmentPositions.RIGHT:
                    shiftAdjustment = quietZonePx + remainder;
                    break;
                case AlignmentPositions.CENTER:
                default:
                    shiftAdjustment = quietZonePx + (remainder / 2);
                    break;
            }//switch

            return (barWidth, quietZonePx, shiftAdjustment);
        }
        /// <summary>
        /// Gets a bitmap representation of the encoded data.
        /// </summary>
        /// <returns>Bitmap of encoded value.</returns>
        private Bitmap Generate_Image()
        {
            if (Encoded_Value == string.Empty) throw new Exception("EGENERATE_IMAGE-1: Must be encoded first.");

            if (IsMatrixSymbology(this.Encoded_Type))
                return Generate_Image_Matrix();

            Bitmap bitmap = null;

            DateTime dtStartTime = DateTime.Now;

            switch (this.Encoded_Type)
            {
                case TYPE.ITF14:
                    {
                        // Automatically calculate the Width if applicable. Quite confusing with this
                        // barcode type, and it seems this method overestimates the minimum width. But
                        // at least it�s deterministic and doesn�t produce too small of a value.
                        if (BarWidth.HasValue)
                        {
                            // Width = (BarWidth * EncodedValue.Length) + bearerwidth + iquietzone
                            // Width = (BarWidth * EncodedValue.Length) + 2*Width/12.05 + 2*Width/20
                            // Width - 2*Width/12.05 - 2*Width/20 = BarWidth * EncodedValue.Length
                            // Width = (BarWidth * EncodedValue.Length)/(1 - 2/12.05 - 2/20)
                            // Width = (BarWidth * EncodedValue.Length)/((241 - 40 - 24.1)/241)
                            // Width = BarWidth * EncodedValue.Length / 176.9 * 241
                            // Rounding error? + 1
                            Width = (int)(241 / 176.9 * Encoded_Value.Length * BarWidth.Value + 1);
                        }
                        Height = (int?)(Width / AspectRatio) ?? Height;

                        int ILHeight = Height;
                        if (IncludeLabel)
                        {
                            ILHeight -= this.LabelFont.Height;
                        }

                        bitmap = CreateBitmap(Width, Height);

                        int bearerwidth = (int)((bitmap.Width) / 12.05);
                        int iquietzone = Convert.ToInt32(bitmap.Width * 0.05);
                        int iBarWidth = (bitmap.Width - (bearerwidth * 2) - (iquietzone * 2)) / Encoded_Value.Length;
                        int shiftAdjustment = ((bitmap.Width - (bearerwidth * 2) - (iquietzone * 2)) % Encoded_Value.Length) / 2;

                        if (iBarWidth <= 0 || iquietzone <= 0)
                            throw new Exception("EGENERATE_IMAGE-3: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel or quiet zone determined to be less than 1 pixel)");

                        //draw image
                        int pos = 0;

                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            //fill background
                            g.Clear(BackColor);

                            //lines are fBarWidth wide so draw the appropriate color line vertically
                            using (Pen pen = new Pen(ForeColor, iBarWidth))
                            {
                                while (pos < Encoded_Value.Length)
                                {
                                    //draw the appropriate color line vertically
                                    if (Encoded_Value[pos] == '1')
                                        g.DrawLine(pen, new Point((pos * iBarWidth) + shiftAdjustment + bearerwidth + iquietzone, 0), new Point((pos * iBarWidth) + shiftAdjustment + bearerwidth + iquietzone, Height));

                                    pos++;
                                }//while

                                //bearer bars
                                pen.Width = (float)ILHeight / 8;
                                pen.Color = ForeColor;
                                g.DrawLine(pen, new Point(0, 0), new Point(bitmap.Width, 0));//top
                                g.DrawLine(pen, new Point(0, ILHeight), new Point(bitmap.Width, ILHeight));//bottom
                                g.DrawLine(pen, new Point(0, 0), new Point(0, ILHeight));//left
                                g.DrawLine(pen, new Point(bitmap.Width, 0), new Point(bitmap.Width, ILHeight));//right
                            }//using
                        }//using

                        if (IncludeLabel)
                            Labels.Label_ITF14(this, bitmap);

                        break;
                    }//case
                case TYPE.UPCA:
                    {
                        // Automatically calculate Width if applicable.
                        Width = BarWidth * Encoded_Value.Length ?? Width;

                        // Automatically calculate Height if applicable.
                        Height = (int?)(Width / AspectRatio) ?? Height;

                        int ILHeight = Height;
                        int topLabelAdjustment = 0;

                        var upcaGeometry = CalculateModuleGeometry(Width, Encoded_Value.Length);
                        int shiftAdjustment = upcaGeometry.shiftAdjustment;
                        int iBarWidth = upcaGeometry.barWidth;

                        if (IncludeLabel)
                        {
                            if ((AlternateLabel == null || RawData.StartsWith(AlternateLabel)) && _StandardizeLabel)
                            {
                                // UPCA standardized label
                                string defTxt = RawData;
                                string labTxt = defTxt.Substring(0, 1) + "--" + defTxt.Substring(1, 6) + "--" + defTxt.Substring(7);

                                Font labFont = new Font(this.LabelFont != null ? this.LabelFont.FontFamily.Name : "Arial", Labels.getFontsize(this, Width, Height, labTxt) * DotsPerPointAt96Dpi, FontStyle.Regular, GraphicsUnit.Pixel);
                                if (this.LabelFont != null)
                                {
                                    this.LabelFont.Dispose();
                                }
                                LabelFont = labFont;

                                ILHeight -= (labFont.Height / 2);
                            }
                            else
                            {
                                // Shift drawing down if top label.
                                if ((LabelPosition & (LabelPositions.TOPCENTER | LabelPositions.TOPLEFT | LabelPositions.TOPRIGHT)) > 0)
                                    topLabelAdjustment = this.LabelFont.Height;

                                ILHeight -= this.LabelFont.Height;
                            }
                        }

                        bitmap = CreateBitmap(Width, Height);
                        int iBarWidthModifier = 1;
                        if (iBarWidth <= 0)
                            throw new Exception("EGENERATE_IMAGE-2: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)");

                        //draw image
                        int pos = 0;
                        int halfBarWidth = (int)(iBarWidth * 0.5);

                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            //clears the image and colors the entire background
                            g.Clear(BackColor);

                            //lines are fBarWidth wide so draw the appropriate color line vertically
                            using (Pen backpen = new Pen(BackColor, iBarWidth / iBarWidthModifier))
                            {
                                using (Pen pen = new Pen(ForeColor, iBarWidth / iBarWidthModifier))
                                {
                                    while (pos < Encoded_Value.Length)
                                    {
                                        if (Encoded_Value[pos] == '1')
                                        {
                                            g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, topLabelAdjustment), new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, ILHeight + topLabelAdjustment));
                                        }

                                        pos++;
                                    }//while
                                }//using
                            }//using
                        }//using
                        if (IncludeLabel)
                        {
                            if ((AlternateLabel == null || RawData.StartsWith(AlternateLabel)) && _StandardizeLabel)
                            {
                                Labels.Label_UPCA(this, bitmap);
                            }
                            else
                            {
                                Labels.Label_Generic(this, bitmap);
                            }
                        }

                        break;
                    }//case
                case TYPE.EAN13:
                    {
                        // Automatically calculate Width if applicable.
                        Width = BarWidth * Encoded_Value.Length ?? Width;

                        // Automatically calculate Height if applicable.
                        Height = (int?)(Width / AspectRatio) ?? Height;

                        int ILHeight = Height;
                        int topLabelAdjustment = 0;

                        var ean13Geometry = CalculateModuleGeometry(Width, Encoded_Value.Length);
                        int shiftAdjustment = ean13Geometry.shiftAdjustment;

                        if (IncludeLabel)
                        {
                            if (((AlternateLabel == null) || RawData.StartsWith(AlternateLabel)) && _StandardizeLabel)
                            {
                                // EAN13 standardized label
                                string defTxt = RawData;
                                string labTxt = defTxt.Substring(0, 1) + "--" + defTxt.Substring(1, 6) + "--" + defTxt.Substring(7);

                                Font font = this.LabelFont;
                                Font labFont = new Font(font != null ? font.FontFamily.Name : "Arial", Labels.getFontsize(this, Width, Height, labTxt) * DotsPerPointAt96Dpi, FontStyle.Regular, GraphicsUnit.Pixel);

                                if (font != null)
                                {
                                    this.LabelFont.Dispose();
                                }

                                LabelFont = labFont;

                                ILHeight -= (labFont.Height / 2);
                            }
                            else
                            {
                                // Shift drawing down if top label.
                                if ((LabelPosition & (LabelPositions.TOPCENTER | LabelPositions.TOPLEFT | LabelPositions.TOPRIGHT)) > 0)
                                    topLabelAdjustment = this.LabelFont.Height;

                                ILHeight -= this.LabelFont.Height;
                            }
                        }

                        bitmap = CreateBitmap(Width, Height);
                        int iBarWidth = ean13Geometry.barWidth;
                        int iBarWidthModifier = 1;
                        if (iBarWidth <= 0)
                            throw new Exception("EGENERATE_IMAGE-2: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)");

                        //draw image
                        int pos = 0;
                        int halfBarWidth = (int)(iBarWidth * 0.5);

                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            //clears the image and colors the entire background
                            g.Clear(BackColor);

                            //lines are fBarWidth wide so draw the appropriate color line vertically
                            using (Pen backpen = new Pen(BackColor, iBarWidth / iBarWidthModifier))
                            {
                                using (Pen pen = new Pen(ForeColor, iBarWidth / iBarWidthModifier))
                                {
                                    while (pos < Encoded_Value.Length)
                                    {
                                        if (Encoded_Value[pos] == '1')
                                        {
                                            g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, topLabelAdjustment), new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, ILHeight + topLabelAdjustment));
                                        }

                                        pos++;
                                    }//while
                                }//using
                            }//using
                        }//using
                        if (IncludeLabel)
                        {
                            if (((AlternateLabel == null) || RawData.StartsWith(AlternateLabel)) && _StandardizeLabel)
                            {
                                Labels.Label_EAN13(this, bitmap);
                            }
                            else
                            {
                                Labels.Label_Generic(this, bitmap);
                            }
                        }

                        break;
                    }//case
                default:
                    {
                        // Automatically calculate Width if applicable.
                        Width = BarWidth * Encoded_Value.Length ?? Width;

                        // Automatically calculate Height if applicable.
                        Height = (int?)(Width / AspectRatio) ?? Height;

                        int ILHeight = Height;
                        int topLabelAdjustment = 0;

                        if (IncludeLabel)
                        {
                            // Shift drawing down if top label.
                            if ((LabelPosition & (LabelPositions.TOPCENTER | LabelPositions.TOPLEFT | LabelPositions.TOPRIGHT)) > 0)
                                topLabelAdjustment = this.LabelFont.Height;

                            ILHeight -= this.LabelFont.Height;
                        }


                        bitmap = CreateBitmap(Width, Height);
                        var defaultGeometry = CalculateModuleGeometry(Width, Encoded_Value.Length);
                        int iBarWidth = defaultGeometry.barWidth;
                        int shiftAdjustment = defaultGeometry.shiftAdjustment;
                        int iBarWidthModifier = 1;

                        if (this.Encoded_Type == TYPE.PostNet)
                            iBarWidthModifier = 2;

                        if (iBarWidth <= 0)
                            throw new Exception("EGENERATE_IMAGE-2: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)");

                        //draw image
                        int pos = 0;
                        int halfBarWidth = (int)Math.Round(iBarWidth * 0.5);

                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            //clears the image and colors the entire background
                            g.Clear(BackColor);

                            //lines are fBarWidth wide so draw the appropriate color line vertically
                            using (Pen backpen = new Pen(BackColor, iBarWidth / iBarWidthModifier))
                            {
                                using (Pen pen = new Pen(ForeColor, iBarWidth / iBarWidthModifier))
                                {
                                    while (pos < Encoded_Value.Length)
                                    {
                                        if (this.Encoded_Type == TYPE.PostNet)
                                        {
                                            //draw half bars in postnet
                                            if (Encoded_Value[pos] == '0')
                                                g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, ILHeight + topLabelAdjustment), new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, (ILHeight / 2) + topLabelAdjustment));
                                            else
                                                g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, ILHeight + topLabelAdjustment), new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, topLabelAdjustment));
                                        }//if
                                        else
                                        {
                                            if (Encoded_Value[pos] == '1')
                                                g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, topLabelAdjustment), new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, ILHeight + topLabelAdjustment));
                                        }
                                        pos++;
                                    }//while
                                }//using
                            }//using
                        }//using
                        if (IncludeLabel)
                        {
                            Labels.Label_Generic(this, bitmap);
                        }//if

                        break;
                    }//switch
            }//switch

            _Encoded_Image = (Image)bitmap;

            this.EncodingTime += (DateTime.Now - dtStartTime).TotalMilliseconds;

            return bitmap;
        }//Generate_Image
        /// <summary>
        /// Renders a 2D/matrix symbol (e.g. QR Code) from <see cref="_Encoded_Matrix"/>. QR's own
        /// minimum quiet zone is 4 modules. Matrix symbols are square, so they're centered and
        /// rendered as large as possible within the canvas without stretching. Text labels are not
        /// currently supported for matrix symbologies (<see cref="IncludeLabel"/> is ignored).
        /// </summary>
        private Bitmap Generate_Image_Matrix()
        {
            if (_Encoded_Matrix == null)
                throw new Exception("EGENERATE_IMAGE-1: Must be encoded first.");

            DateTime dtStartTime = DateTime.Now;

            const int quietZoneModules = 4;
            int moduleCount = _Encoded_Matrix.GetLength(0);

            Bitmap bitmap = CreateBitmap(Width, Height);
            var geometry = CalculateMatrixGeometry(Width, Height, moduleCount, quietZoneModules);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(BackColor);
                using (SolidBrush brush = new SolidBrush(ForeColor))
                {
                    for (int y = 0; y < moduleCount; y++)
                    {
                        for (int x = 0; x < moduleCount; x++)
                        {
                            if (_Encoded_Matrix[y, x])
                            {
                                int px = geometry.offsetX + ((x + quietZoneModules) * geometry.moduleSizePx);
                                int py = geometry.offsetY + ((y + quietZoneModules) * geometry.moduleSizePx);
                                g.FillRectangle(brush, px, py, geometry.moduleSizePx, geometry.moduleSizePx);
                            }
                        }
                    }
                }
            }

            _Encoded_Image = (Image)bitmap;
            this.EncodingTime += (DateTime.Now - dtStartTime).TotalMilliseconds;
            return bitmap;
        }//Generate_Image_Matrix
        /// <summary>
        /// Renders the currently encoded barcode as an SVG document (vector output), as an
        /// alternative to the raster <see cref="EncodedImage"/>. Must be called after encoding
        /// (e.g. via <see cref="GenerateBarcode(string)"/> or one of the <c>Encode</c> overloads).
        /// </summary>
        /// <returns>A complete, self-contained SVG document as a string.</returns>
        public string GetSvg()
        {
            return SvgRenderer.Render(this);
        }//GetSvg
        #endregion
    }
}