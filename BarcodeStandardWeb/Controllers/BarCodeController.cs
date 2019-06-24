using BarcodeStandardWeb.Models;
using Cec.Barcode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarcodeStandardWeb.Controllers
{
    public class BarCodeController : BaseController
    {
        public BarCodeController()
        {
        }
        public BarCodeVM BarCodeMain
        {
            get
            {
                return new BarCodeVM()
                {
                    BarCodeList = BarCodeDb.ListAll()
                };
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(BarCodeMain);
        }
        [HttpGet]
        public ActionResult Details(int id = 1)
        {
            return View(BarCodeMain.BarCodeList.Where(W=>W.Id==id).FirstOrDefault());
        }
        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            return View(BarCodeMain.BarCodeList.Where(W => W.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(BarCodeModel postBarcode, int id = 1)
        {
            BarCodeDb.Update(postBarcode);
            return View(BarCodeDb.Get(id));
        }
    }
}