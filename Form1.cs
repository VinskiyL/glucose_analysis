using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NaPredeleVozmozshnostey
{
    public partial class Form1 : Form
    {
        List<double> gl;
        List<int> times;
        int time = 0, dt = 0;
        bool flag = true;
        int count = 0, low = 0, high = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Next_Day_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            low = 0;
            high = 0;
            for (int i = time ; i < gl.Count - 1; i++)
            {
                if (times[i + 1] < times[i])
                {
                    dt = i + 1;
                    flag = false;
                    break;
                }
            }
            if (!flag) { count = times[dt - 1] - times[time]; flag = true; }
            else { count = times[gl.Count - 1] - times[time]; dt = gl.Count;}
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            string[] text = new string[10];
            string[] str;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файлы txt (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                { 
                    str = File.ReadAllLines(dialog.FileName);
                    text = str[0].Split(' ');
                    form.Fname.Text = text[0];
                    form.Name_.Text = text[1];
                    form.Lname.Text = text[2];
                    text = str[1].Split(' ');
                    if (text[1] == "Мужской")
                    {
                        form.radioButton1.Checked = true;
                    }
                    else
                    {
                        form.radioButton2.Checked = true;
                    }
                    text = str[2].Split(' ');
                    form.Height_.Text = text[1];
                    form.Weight.Text = text[3];
                    text = str[3].Split(' ');
                    text = text[2].Split('.');
                    form.Day.Text = text[0];
                    form.Mounth.Text = text[1];
                    form.Year.Text = text[2];
                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Next_Day.Enabled = false;
            string path = @"C:\Users\katuh\Downloads\export20240319-093004.csv";
            Reader reader = new Reader();
            reader.Read(path);
            times = reader.Times;
            gl = reader.Gl;
            for (int i = 0; i < gl.Count-1; i++)
            {
                if (times[i + 1] < times[i])
                {
                    dt = i + 1;
                    flag = false;
                    break;
                }
            }
            if (!flag) { count = times[dt - 1] - times[0]; flag = true; }
            else { count = times[gl.Count - 1] - times[0]; dt = gl.Count; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 20;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor= Color.Gray;
            double mediana = 0, min = 1000, max = 0, razm = 0;
            for (int i = time, j = time; i < dt; i++)
            {
                if ((gl[i] > 10.0 || gl[i] < 4.0) && flag)
                {
                    j = i;
                    flag = false;
                }
                else if(gl[i] <= 10.0 && gl[i] >= 4.0 && (!flag || (!flag && i == gl.Count - 1)))
                {
                    count-= times[i] - times[j];
                    flag = true;
                    if (gl[i - 1] > 10.0)
                    {
                        high += times[i] - times[j];
                    }
                    else
                    {
                        low += times[i] - times[j];
                    }
                }
                if (gl[i] < min)
                {
                    min = gl[i];
                }
                if (gl[i] > max)
                {
                    max = gl[i];
                }
                chart1.Series[0].Points.AddXY((double)times[i], 10.0);
                chart1.Series[1].Points.AddXY((double)times[i], 4.0);
                chart1.Series[2].Points.AddXY((double)times[i], gl[i]);
                mediana += gl[i];
            }
            time = dt;
            mediana /= time;
            mediana = Math.Round(mediana, 2);
            razm = max - min;
            razm = Math.Round(razm, 2);
            double disp = 0, x2 = 0, s = 0, moda = 0;
            double procn = (double)count / (double)times[time - 1] * 100;
            double proch = (double)high / (double)times[time - 1] * 100;
            double procl = (double)low / (double)times[time - 1] * 100;
            string str;
            if(procn >= 70)
            {
                str = " (компенсация)";
            }
            else
            {
                str = " (декомпенсация)";
            }
            procn = Math.Round(procn, 2);
            proch = Math.Round(proch, 2);
            procl = Math.Round(procl, 2);
            textBox2.Text = count.ToString() + " мин. - " + procn + "%" + str;
            textBox7.Text = high.ToString() + " мин. - " + proch + "%";
            textBox8.Text = low.ToString() + " мин. - " + procl + "%";
            double[] pieProc = new double[3];
            pieProc[0] = procn;
            pieProc[1] = proch;
            pieProc[2] = procl;
            for (int i = 0; i < time; i++)
            {
                disp += Math.Pow(gl[i] - mediana, 2);
                x2 += Math.Pow(gl[i], 2);
            }
            Moda m = new Moda();
            moda = m.Mod(gl, time-1);
            moda = Math.Round(moda, 2);
            disp /= time;
            disp = Math.Round(disp, 2);
            x2 /= time;
            s = x2 - Math.Pow(mediana, 2);
            s = Math.Round(s, 2);
            textBox4.Text = "Медиана: " + mediana + "\r\nРазмах: " + razm + "\r\nДисперсия: " + disp +
                "\r\nСтандартное отклонение: " + s + "\r\nМода: " + moda;
            string[] values = { "Norm", "Above normal", "Below normal" };
            chart2.Series[0]["PieLabelStyle"] = "Disabled";
            chart2.Series[0].Points.DataBindXY(values, pieProc);
            button1.Enabled = false;
            Next_Day.Enabled = true;
            if(dt == gl.Count) { Next_Day.Enabled = false; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
