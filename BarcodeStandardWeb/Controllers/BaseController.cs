namespace BarcodeStandardWeb.Controllers
{
    using Barcode.Web.Repositories;
    using System;
    using System.Linq;
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