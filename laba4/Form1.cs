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
                return;
            }

            var transp = this.trList[0];
            this.trList.RemoveAt(0);

            // ЗАМЕНИЛ НАШИ if`ы
            txtOut.Text = transp.GetInfo();

            ShowInfo();
        }

        private void ShowInfo()
        {
            // заведем счетчики под каждый тип
            int planeCount = 0;
            int bicycleCount = 0;
            int carCount = 0;

            // пройдемся по всему списку
            foreach (var transp in this.trList)
            {
                // помните, что в списки у нас лежат фрукты,
                // то есть объекты типа Fruit
                // поэтому чтобы проверить какой именно фрукт
                // мы в данный момент обозреваем, мы используем ключевое слово is
                if (transp is Plane) // читается почти как чистый инглиш, "если fruit есть Мандарин"
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

            // а ну и вывести все это надо на форму
            txtInfo.Text = "Самолёт\tВелосипед Автомобиль"; // буквы экономлю, чтобы влезло на форму
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t   {2}", planeCount, bicycleCount, carCount);
        }
    }
}
