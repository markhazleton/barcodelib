namespace BarcodeStandardWeb.Controllers
{
    using Cec.Barcode.Repositories;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        public IBarCodeDB BarCodeDb
        {
            get
            {
                if (HttpContext.Application == null)
                    return new BarCodeMock();
                if ((BarCodeMock)HttpContext.Application["BarCodeMock"] == null)
                    HttpContext.Application["BarCodeMock"] = new BarCodeMock();
                return ((BarCodeMock)HttpContext.Application["BarCodeMock"]);
            }
        }


    }
}