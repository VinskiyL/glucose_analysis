using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NaPredeleVozmozshnostey
{
    internal class Reader
    {
        List<int> times = new List<int>();
        List<double> gl = new List<double>();
        TimeInDec timeInDec = new TimeInDec();
        public List<int> Times { get { return times; } }
        public List<double> Gl { get { return gl; } }
        public void Read(string path)
        {
            string[] str;
            string[] s = new string[3];
            try
            {
                str = File.ReadAllLines(path);
                for (int i = 1; i < str.Length; i++)
                {
                    s = str[i].Split(';');
                    if (s[2] == "")
                    {
                        continue;
                    }
                    times.Add(timeInDec.Convert(s[1]));
                    gl.Add(double.Parse(s[2])/18.0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
