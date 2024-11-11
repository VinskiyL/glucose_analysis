using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    internal class Check_Day: Check_Num
    {
        public override void CheckTxt(string txt, string name_field)
        {
            base.CheckTxt(txt, name_field);
            int day = int.Parse(txt);
            if (day < 1 || day > 31)
            {
                throw new Exception("Число в поле " + name_field + " введено некорректно");
            }
        }
    }
}
