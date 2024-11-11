using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    internal class Check_Mounth: Check_Num
    {
        public override void CheckTxt(string txt, string name_field)
        {
            base.CheckTxt(txt, name_field);
            int mounth = int.Parse(txt);
            if (mounth < 1 || mounth > 12)
            {
                throw new Exception("Число в поле " + name_field + " введено некорректно");
            }
        }
    }
}
