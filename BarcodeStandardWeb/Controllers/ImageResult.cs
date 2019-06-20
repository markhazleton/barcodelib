namespace BarcodeStandardWeb.Controllers
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Web.Mvc;
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