using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void yOrNBtn_Click(object sender, EventArgs e)
        {
            if(queTxtBox.Text.Length!=0)
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 2);
                if (value == 1)
                    answerLabel.Text = "ДА";
                else
                    answerLabel.Text = "НЕТ";
            }
            else
            {
                MessageBox.Show("Задай вопрос!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (queTxtBox.Text.Length != 0)
            {
                String[] answer = { "Бесспорно", "Предрешено", "Никаких сомнений",
                "Определённо да", "Можешь быть уверен в этом",
                "Мне кажется — «да»", "Вероятнее всего", "Хорошие перспективы",
                "Знаки говорят — «да»", "Да", "Пока не ясно, попробуй снова",
                "Спроси позжe", "Лучше не рассказывать", "Сейчас нельзя предсказать",
                "Сконцентрируйся и спроси опять", "Даже не думай", "Весьма сомнительно",
                "Мой ответ — «нет»", "По моим данным — «нет»", "Перспективы не очень хорошие"};

                double p = 1.0 / 20.0;

                Random rnd = new Random();
                double A = rnd.NextDouble();
                int value = 0;
                A -= p;

                while (A > 0)
                {
                    A -= p;
                    value++;
                };
                magicBallLabel.Text = answer[value];

            }
            else
            {
                MessageBox.Show("Задай вопрос!");
            }
        }
    }
}
