namespace BarcodeStandardWeb.Controllers
{
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

        public ActionResult GetModifiedImage()
        {
            Image image = Image.FromFile(Path.Combine(Server.MapPath("/Content/images"), "image.png"));
            using (Graphics g = Graphics.FromImage(image))
            {
                // do something with the Graphics (eg. write "Hello World!")
                string text = "Hello World!";

                // Create font and brush.
                Font drawFont = new Font("Arial", 10);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Create point for upper-left corner of drawing.
                PointF stringPoint = new PointF(0, 0);

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


    }
}