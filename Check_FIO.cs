using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    internal class Check_FIO: Check
    {
        string fio = "";
        public override string FIO { get { return fio; } }
        public override void CheckTxt(string txt, string name_field)
        {
            base.CheckTxt(txt, name_field);
            txt = txt.Trim();
            txt = txt.ToLower();
            fio += txt[0];
        }
    }
}
