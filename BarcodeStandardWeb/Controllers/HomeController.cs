namespace BarcodeStandardWeb.Controllers
{
    using Cec.Barcode.Extensions;
    using Cec.Barcode.Models;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web.Mvc;
    public class HomeController : BaseController
    {
        public Microsoft.AspNetCore.Mvc.ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public Microsoft.AspNetCore.Mvc.ActionResult GetFile()
        {
            // No need to dispose the stream, MVC does it for you
            string path = Path.Combine(Server.MapPath("/Content/images"), "image.png");
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStreamResult result = new FileStreamResult(stream, "image/png");
            result.FileDownloadName = "image.png";
            return result;
        }

        public Microsoft.AspNetCore.Mvc.ActionResult MyImage()
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
