using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    internal class Check_Num: Check
    {
        public override void CheckTxt(string txt, string name_field)
        {
            base.CheckTxt(txt, name_field);
            bool h = int.TryParse(txt, out _);
            if (!h)
            {
                throw new Exception("Число в поле " + name_field + " введено некорректно");
            }
        }
    }
}
