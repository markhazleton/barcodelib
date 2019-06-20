namespace Barcode.Web.Repositories
{
    using Barcode.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public interface IBarCodeDB
    {
        int Delete(int ID);

        BarCodeModel Get(int id);

        List<BarCodeModel> ListAll();

        int Update(BarCodeModel barcode);
    }
}
