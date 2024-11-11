using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    abstract class Check
    {
        string fio = "";
        public virtual string FIO { get { return fio; } }
        int year = 1;
        virtual public int Year { get { return year; } }
        public virtual void CheckTxt(string txt, string name_field)
        {
            if (txt == null) { throw new Exception("Введите текст в поле " + name_field); }
        }
    }
}
