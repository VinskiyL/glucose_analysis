using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    internal class Check_Year: Check_Num
    {
        int year = 1;
        public override int Year { get { return year; } }
        public override void CheckTxt(string txt, string name_field)
        {
            base.CheckTxt(txt, name_field);
            int year = int.Parse(txt);
            DateTime moment = DateTime.Now;
            int this_year = moment.Year;
            if (year < this_year - 150 || year > this_year)
            {
                throw new Exception("Число в поле " + name_field + " введено некорректно");
            }
            this.year = year;
        }
    }
}
