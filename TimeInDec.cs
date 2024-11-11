using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    internal class TimeInDec
    {
        public int Convert(string str)
        {
            int i = 0;
            string strhour = "", strmin = "";
            while (str[i] != ':')
            {
                strhour += str[i].ToString();
                i++;
            }
            i++;
            while (str.Length > i)
            {
                strmin += str[i].ToString();
                i++;
            }
            i = int.Parse(strhour) * 60 + int.Parse(strmin);
            return i;
        }
    }
}
