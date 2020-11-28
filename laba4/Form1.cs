using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4
{
    public partial class Form1 : Form
    {
        List<Transport> trList = new List<Transport>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void button1_Click(object sender, EventArgs e) //Перезаполнить
        {
            this.trList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2 (ну остаток от деления на 3)
                {
                    case 0: // если 0, то самолёт
                        this.trList.Add(Plane.Generate());
                        break;
                    case 1: // если 1 то велосипед
                        this.trList.Add(Bicycle.Generate());
                        break;
                    case 2: // если 2 то автомобиль
                        this.trList.Add(Car.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        private void button2_Click(object sender, EventArgs e) //Взять
        {
            if (this.trList.Count == 0)
            {
                txtOut.Text = "Пусто";
                pictureBox1.Image = Properties.Resources.Без_названия;
                return;
            }

            var transp = this.trList[0];
            string str = trList[0].ToString();
            string[] words = str.Split('.');

            foreach (var word in words) //выбор картинки
            {
                if (words[1] == "Plane")
                {
                    pictureBox1.Image = Properties.Resources.ракетный;
                }
                else if (words[1] == "Bicycle")
                {
                    pictureBox1.Image = Properties.Resources.горный;
                }
                else if (words[1] == "Car")
                {
                    pictureBox1.Image = Properties.Resources.внедорожник;
                }
            }
            this.trList.RemoveAt(0);

            // ЗАМЕНИЛ НАШИ if`ы
            txtOut.Text = transp.GetInfo();

            ShowInfo();
        }

        private void ShowInfo()
        {
            //счетчики под каждый тип
            int planeCount = 0;
            int bicycleCount = 0;
            int carCount = 0;

            // пройдемся по всему списку
            foreach (var transp in this.trList)
            {
                if (transp is Plane)
                {
                    planeCount += 1;
                }
                else if (transp is Bicycle)
                {
                    bicycleCount += 1;
                }
                else if (transp is Car)
                {
                    carCount += 1;
                }
            }

            txtInfo.Text = "Самолёт\tВелосипед Автомобиль";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t   {2}", planeCount, bicycleCount, carCount);
        }
    }
}
