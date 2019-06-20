﻿namespace Barcode.Web.Models
{
    using BarcodeLib;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    public class BarCodeModel
    {
        public BarCodeModel()
        {
            Id = 1;
            Width = 290;
            Height = 120;
            AlignmentPosition = AlignmentPositions.CENTER;
            EncodedType = TYPE.CODE93;
            BarWidth = null;
            BarHeight = 250;
            AspectRatio = null;
            IncludeLabel = true;
            RotateFlip = RotateFlipType.Rotate180FlipXY;
            AlternateLabel = "TEST TEST TEST";
            LabelPosition = LabelPositions.BOTTOMCENTER;
            BarValue = "0000444";
            BackColor = Color.White;
            ForeColor = Color.Black;
        }

        public BarCodeModel(string Value)
        {
            Id = 1;
            Width = 290;
            Height = 120;
            AlignmentPosition = AlignmentPositions.CENTER;
            EncodedType = TYPE.CODE93;
            BarWidth = null;
            BarHeight = 250;
            AspectRatio = null;
            IncludeLabel = true;
            RotateFlip = RotateFlipType.Rotate180FlipXY;
            AlternateLabel = Value;
            LabelPosition = LabelPositions.BOTTOMCENTER;
            BarValue = Value;
            BackColor = Color.White;
            ForeColor = Color.Black;
        }



        public int Id { get; set; }
        public AlignmentPositions AlignmentPosition { get; set; }
        public string AlternateLabel { get; set; }
        public double? AspectRatio { get; set; }
        public Color BackColor { get; set; }
        public int BarHeight { get; set; }
        public string BarValue { get; set; }
        public int? BarWidth { get; set; }
        public string EncodedText { get; set; }
        public TYPE EncodedType { get; set; }
        public string EncodedTypeText { get; set; }
        public string EncodingTime { get; set; }
        public Color ForeColor { get; set; }
        public int Height { get; set; }
        public bool IncludeLabel { get; set; }
        public LabelPositions LabelPosition { get; set; }
        public RotateFlipType RotateFlip { get; set; }
        public int Width { get; set; }


        public Byte[] BarcodeByteArray
        {
            get
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    BarcodeImage.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
                    return mStream.ToArray();
                }
            }
        }

        public Image BarcodeImage
        {
            get
            {
                Barcode b = new Barcode();
                try
                {
                    if (this.EncodedType != TYPE.UNSPECIFIED)
                    {
                        b.EncodedType = this.EncodedType;
                        b.Alignment = this.AlignmentPosition;
                        b.BarWidth = this.BarWidth;
                        b.AspectRatio = this.AspectRatio;
                        b.IncludeLabel = this.IncludeLabel;
                        b.RotateFlipType = this.RotateFlip;
                        b.AlternateLabel = this.AlternateLabel;
                        b.LabelPosition = this.LabelPosition;
                    }//if
                }//try
                catch (Exception ex)
                {
                    // do Something!
                }//catch
                return b.Encode(b.EncodedType, this.BarValue.Trim(), this.ForeColor, this.BackColor, this.Width, this.Height);
            }
        }
    }
}
