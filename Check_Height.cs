using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    internal class Check_Height: Check_Double
    {
        public override void CheckTxt(string txt, string name_field)
        {
            base.CheckTxt(txt, name_field);
            double num = double.Parse(txt);
            if( num < 0.4 || num > 2.8)
            {
                throw new Exception("Некорректное значение в поле " + name_field);
            }
        }
    }
}
