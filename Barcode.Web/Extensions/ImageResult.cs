namespace Barcode.Web.Extensions
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Web.Mvc;
    //
    // from https://stackoverflow.com/questions/186062/can-an-asp-net-mvc-controller-return-an-image 
    //  https://www.danylkoweb.com/Blog/update-dynamically-resizing-your-asp-net-mvc-images-LT
    //

    public class ImageResult : ActionResult
    {
        public ImageResult() { }
        public Image Image { get; set; }
        public ImageFormat ImageFormat { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            // verify properties 
            if (Image == null)
            {
                throw new ArgumentNullException("Image");
            }
            if (ImageFormat == null)
            {
                throw new ArgumentNullException("ImageFormat");
            }

            // output 
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = GetMimeType(ImageFormat);
            Image.Save(context.HttpContext.Response.OutputStream, ImageFormat);
        }

        private static string GetMimeType(ImageFormat imageFormat)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            return codecs.First(codec => codec.FormatID == imageFormat.Guid).MimeType;
        }
    }
}