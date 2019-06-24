namespace BarcodeStandardWeb.Models
{
    using Cec.Barcode.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BarCodeVM
    {
        public BarCodeVM()
        {
            BarCodeList = new List<BarCodeModel>();
            BarCode = new BarCodeModel();
        }

        public BarCodeModel BarCode { get; set; }
        public List<BarCodeModel> BarCodeList { get; set; }
    }
}
