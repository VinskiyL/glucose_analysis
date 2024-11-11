using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaPredeleVozmozshnostey
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static void KeyPr(KeyPressEventArgs e, bool val)
        {
            char number = e.KeyChar;
            if (!val)
            {
                if (!Char.IsDigit(number) && number != 8) { e.Handled = true; }
                return;
            }
            if (!Char.IsDigit(number) && number != 8 && number != ',') { e.Handled = true; }
        }
        static void KeyPr(KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (Regex.IsMatch(number.ToString(), @"^[a-zA-Zа-яА-Я]+$") || number == 8)
            { e.Handled = false; }
            else { e.Handled = true; }
        }
        private void Fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPr(e);
        }

        private void Name__KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPr(e);
        }

        private void Lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPr(e);
        }

        private void Hight_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPr(e, true);
        }

        private void Weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPr(e, true);
        }

        private void Day_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPr(e, false);
        }

        private void Mounth_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPr(e, false);
        }

        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPr(e, false);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Year.MaxLength = 4;
            Mounth.MaxLength = 2;
            Day.MaxLength = 2;
            Weight.MaxLength = 6;
            Height_.MaxLength = 4;
        }

        private void save_Click(object sender, EventArgs e)
        {
            string path = @"D:\Научная деятельность\Пациент\";
            string info = "";
            try
            {
                Check check = new Check_FIO();
                check.CheckTxt(Fname.Text, "Фамилия");
                check.CheckTxt(Name_.Text, "Имя");
                check.CheckTxt(Lname.Text, "Отчество");
                path += check.FIO;
                check = new Check_Height();
                check.CheckTxt(Height_.Text, "Рост");
                check = new Check_Weight();
                check.CheckTxt(Weight.Text, "Вес");
                check = new Check_Day();
                check.CheckTxt(Day.Text, "День");
                check = new Check_Mounth();
                check.CheckTxt(Mounth.Text, "Месяц");
                check = new Check_Year();
                check.CheckTxt(Year.Text, "Год");
                path += check.Year + ".txt";
                info += Fname.Text.ToLower() + " " + Name_.Text.ToLower() + " " + Lname.Text.ToLower() + "\r\n" + "Пол: ";
                if (radioButton1.Checked)
                {
                    info += "Мужской" + "\r\n";
                }
                else if (radioButton2.Checked)
                {
                    info += "Женский" + "\r\n";
                }
                else
                {
                    throw new Exception("Выберите пол");
                }
                info += "Рост: " + Height_.Text + " Вес: " + Weight.Text + "\r\n" +
                    "Дата рождения: " + Day.Text + "." + Mounth.Text + "." + Year.Text;
                using(StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.Write(info);
                }
                MessageBox.Show("Файл успешно сохранён");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
