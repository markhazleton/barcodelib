namespace Cec.Barcode.Repositories
{
    using Cec.Barcode.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BarCodeMock : IBarCodeDB
    {
        private List<BarCodeModel> _list;
        public BarCodeMock()
        {
            _list = new List<BarCodeModel>();

            Random rnd = new Random();
            for (int p = 0; p < 20; p++)
            {
                _list.Add(new BarCodeModel(rnd.Next(100000000, 999999999).ToString()));
            }

            int i = 1;
            foreach (var bc in _list)
            {
                if (bc == null) continue;
                bc.Id = i;
                i++;
            }
        }

        public int Delete(int id)
        {
            var myBC = _list.Where(w => w.Id == id).FirstOrDefault();
            if (myBC == null)
                return -1;
            _list.Remove(myBC);
            return 1;
        }

        public BarCodeModel Get(int id)
        {
            var myBC = _list.Where(w => w.Id == id).FirstOrDefault();
            if (myBC == null)
                return new BarCodeModel();
            return myBC;
        }

        public List<BarCodeModel> ListAll()
        {
            return _list;
        }

        public int Update(BarCodeModel item)
        {
            if (item.Id == 0)
            {
                int nextID = _list.OrderByDescending(o => o.Id).Select(s => s.Id).FirstOrDefault() + 1;
                item.Id = nextID;
                _list.Add(item);
                return nextID;
            }
            else
            {
                var myItem = _list.Where(w => w.Id == item.Id).FirstOrDefault();

                if (myItem == null)
                    return -1;
                myItem.AlignmentPosition = item.AlignmentPosition;
                myItem.AlternateLabel = item.AlternateLabel;
                myItem.AspectRatio = item.AspectRatio;
                myItem.BackColor = item.BackColor;
                myItem.BarHeight = item.BarHeight;
                myItem.BarValue = item.BarValue;
                myItem.BarWidth = item.BarWidth;
                myItem.EncodedText = item.EncodedText;
                myItem.EncodedType = item.EncodedType;
                myItem.EncodedTypeText = item.EncodedTypeText;
                myItem.EncodingTime = item.EncodingTime;
                myItem.ForeColor = item.ForeColor;
                myItem.Height = item.Height;
                myItem.IncludeLabel = item.IncludeLabel;
                myItem.LabelPosition = item.LabelPosition;
                myItem.RotateFlip = item.RotateFlip;
                myItem.Width = item.Width;
                return myItem.Id;
            }
        }
    }
}
