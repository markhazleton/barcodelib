using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BarcodeLib
{
    public partial class Barcode
    {
        #region Properties
        /// <summary>
        /// Gets or sets the raw data to encode.
        /// </summary>
        public string RawData
        {
            get { return Raw_Data; }
            set { Raw_Data = value; }
        }//RawData
        /// <summary>
        /// Gets the encoded value. Not available for 2D/matrix symbologies (e.g. QR Code) --
        /// use <see cref="EncodedMatrix"/> for those instead.
        /// </summary>
        public string EncodedValue
        {
            get
            {
                if (IsMatrixSymbology(Encoded_Type))
                    throw new NotSupportedException("EENCODE-3: EncodedValue is not available for 2D/matrix symbologies. Use EncodedMatrix instead.");
                return Encoded_Value;
            }
        }//EncodedValue
        /// <summary>
        /// Gets the encoded value as a 2D grid of modules (true = dark/foreground, false =
        /// light/background). Only populated for 2D/matrix symbologies (e.g. QR Code); null for
        /// all 1D/linear symbologies, which use <see cref="EncodedValue"/> instead.
        /// </summary>
        public bool[,] EncodedMatrix
        {
            get { return _Encoded_Matrix; }
        }//EncodedMatrix
        /// <summary>
        /// Gets the Country that assigned the Manufacturer Code.
        /// </summary>
        public string Country_Assigning_Manufacturer_Code
        {
            get { return _Country_Assigning_Manufacturer_Code; }
        }//Country_Assigning_Manufacturer_Code
        /// <summary>
        /// Gets or sets the Encoded Type (ex. UPC-A, EAN-13 ... etc)
        /// </summary>
        public TYPE EncodedType
        {
            set { Encoded_Type = value; }
            get { return Encoded_Type; }
        }//EncodedType
        /// <summary>
        /// Gets the Image of the generated barcode.
        /// </summary>
        public Image EncodedImage
        {
            get
            {
                return _Encoded_Image;
            }
        }//EncodedImage
        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        public Color ForeColor
        {
            get { return this._ForeColor; }
            set { this._ForeColor = value; }
        }//ForeColor
        /// <summary>
        /// Gets or sets the background color. (Default is white)
        /// </summary>
        public Color BackColor
        {
            get { return this._BackColor; }
            set { this._BackColor = value; }
        }//BackColor
        /// <summary>
        /// Gets or sets the label font. (Default is Microsoft Sans Serif, 10pt, Bold)
        /// </summary>
        public Font LabelFont
        {
            get { return this._LabelFont; }
            set { this._LabelFont = value; }
        }//LabelFont
        /// <summary>
        /// Gets or sets the location of the label in relation to the barcode. (BOTTOMCENTER is default)
        /// </summary>
        public LabelPositions LabelPosition
        {
            get { return _LabelPosition; }
            set { _LabelPosition = value; }
        }//LabelPosition
        /// <summary>
        /// Gets or sets the degree in which to rotate/flip the image.(No action is default)
        /// </summary>
        public RotateFlipType RotateFlipType
        {
            get { return _RotateFlipType; }
            set { _RotateFlipType = value; }
        }//RotatePosition
        /// <summary>
        /// Gets or sets the width of the image to be drawn. (Default is 300 pixels)
        /// </summary>
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        /// <summary>
        /// Gets or sets the height of the image to be drawn. (Default is 150 pixels)
        /// </summary>
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        /// <summary>
        ///   The number of pixels per horizontal inch. Used when creating the Bitmap.
        /// </summary>
        public float HoritontalResolution { get; set; } = DefaultResolution;
        /// <summary>
        ///   The number of pixels per vertical inch. Used when creating the Bitmap.
        /// </summary>
        public float VerticalResolution { get; set; } = DefaultResolution;
        /// <summary>
        ///   If non-null, sets the width of a bar. <see cref="Width"/> is ignored and calculated automatically.
        /// </summary>
        public int? BarWidth { get; set; }
        /// <summary>
        ///   If non-null, <see cref="Height"/> is ignored and set to <see cref="Width"/> divided by this value rounded down.
        /// </summary>
        /// <remarks><para>
        ///   As longer barcodes may be more difficult to align a scanner gun with,
        ///   growing the height based on the width automatically allows the gun to be rotated the
        ///   same amount regardless of how wide the barcode is. A recommended value is 2.
        ///   </para><para>
        ///   This value is applied to <see cref="Height"/> after after <see cref="Width"/> has been
        ///   calculated. So it is safe to use in conjunction with <see cref="BarWidth"/>.
        /// </para></remarks>
        public double? AspectRatio { get; set; }
        /// <summary>
        /// Gets or sets whether a label should be drawn below the image. (Default is false)
        /// </summary>
        public bool IncludeLabel
        {
            get;
            set;
        }

        /// <summary>
        /// Alternate label to be displayed.  (IncludeLabel must be set to true as well)
        /// </summary>
        public String AlternateLabel
        {
            get;
            set;
        }

        /// <summary>
        /// Try to standardize the label format. (Valid only for EAN13 and empty AlternateLabel, default is true)
        /// </summary>
        public bool StandardizeLabel
        {
            get { return _StandardizeLabel; }
            set { _StandardizeLabel = value; }
        }

        /// <summary>
        /// Gets or sets the amount of time in milliseconds that it took to encode and draw the barcode.
        /// </summary>
        public double EncodingTime
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the image format to use when encoding and returning images. (Jpeg is default)
        /// </summary>
        public ImageFormat ImageFormat
        {
            get { return _ImageFormat; }
            set { _ImageFormat = value; }
        }
        /// <summary>
        /// Gets the list of errors encountered.
        /// </summary>
        public List<string> Errors
        {
            get { return this.ibarcode.Errors; }
        }
        /// <summary>
        /// Gets or sets the alignment of the barcode inside the image. (Not for Postnet or ITF-14)
        /// </summary>
        public AlignmentPositions Alignment
        {
            get;
            set;
        }//Alignment
        /// <summary>
        /// When true (the default), rendered barcodes reserve a GS1-compliant quiet zone (clear
        /// margin, sized in symbol modules per the GS1 General Specifications) on each side of
        /// the bars. Set to false to reproduce the pre-3.2.0 rendering geometry, which did not
        /// reserve any quiet zone for most symbologies.
        /// </summary>
        public bool EnforceGS1QuietZone { get; set; } = true;
        /// <summary>
        /// Gets a byte array representation of the encoded image. (Used for Crystal Reports)
        /// </summary>
        public byte[] Encoded_Image_Bytes
        {
            get
            {
                if (_Encoded_Image == null)
                    return null;

                using (MemoryStream ms = new MemoryStream())
                {
                    _Encoded_Image.Save(ms, _ImageFormat);
                    return ms.ToArray();
                }//using
            }
        }
        /// <summary>
        /// Gets the assembly version information.
        /// </summary>
        public static Version Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version; }
        }
        /// <summary>
        /// Disables EAN13 invalid country code exception.
        /// </summary>
        public bool DisableEAN13CountryException { get; set; } = false;
        #endregion

        /// <summary>
        /// Represents the size of an image in real world coordinates (millimeters or inches).
        /// </summary>
        public class ImageSize
        {
            public ImageSize(double width, double height, bool metric)
            {
                Width = width;
                Height = height;
                Metric = metric;
            }

            public double Width { get; set; }
            public double Height { get; set; }
            public bool Metric { get; set; }
        }
    }
}
