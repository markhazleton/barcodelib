using Cec.Barcode.Models;

namespace Barcode.Web.Models
{
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
