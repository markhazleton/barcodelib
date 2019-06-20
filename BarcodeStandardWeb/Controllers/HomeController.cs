namespace BarcodeStandardWeb.Controllers
{
    using Barcode.Web.Extensions;
    using Barcode.Web.Models;
    using BarcodeLib;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    public class HomeController : BaseController
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        //
        // Samples from https://stackoverflow.com/questions/186062/can-an-asp-net-mvc-controller-return-an-image 
        // More Good Stuff https://www.danylkoweb.com/Blog/update-dynamically-resizing-your-asp-net-mvc-images-LT


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetFile()
        {
            // No need to dispose the stream, MVC does it for you
            string path = Path.Combine(Server.MapPath("/Content/images"), "image.png");
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStreamResult result = new FileStreamResult(stream, "image/png");
            result.FileDownloadName = "image.png";
            return result;
        }

        public ActionResult GetModifiedImage(string text = "Hello World")
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image image = b.Encode(BarcodeLib.TYPE.CODE93, "038000356216", Color.Black, Color.White, 290, 120);

            using (Graphics g = Graphics.FromImage(image))
            {
                // Create font and brush.
                Font drawFont = new Font("Arial", 18);
                SolidBrush drawBrush = new SolidBrush(Color.Blue);

                // Create point for upper-left corner of drawing.
                PointF stringPoint = new PointF(0, image.Height - 10);

                g.DrawString(text, drawFont, drawBrush, stringPoint);
            }
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return File(ms.ToArray(), "image/png");
        }

        public ActionResult MyImage()
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image image = b.Encode(BarcodeLib.TYPE.CODE93, "038000356216", Color.Black, Color.White, 290, 120);
            return new ImageResult { Image = image, ImageFormat = ImageFormat.Png };
        }

        public ActionResult MyBarCode()
        {
            var BC = new BarCodeModel();
            return new ImageResult
            {
                Image = BC.BarcodeImage,
                ImageFormat = ImageFormat.Png
            };

        }
    }
}
