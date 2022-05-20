using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задача_3__20_баллов_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        string filename;

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader streamreader = new StreamReader(filename); // Открываем поток
            int disksize = int.Parse(streamreader.ReadLine().Split()[0]); /* очень страшная строка. В ней мы делим первую сторку на два числа, 
                                                                           * берём первое и запоминаем. Оно нам понадобится, в отличие от второго.
                                                                           */
            List<int> file = new List<int>(); // Массивы всё ещё для лохов и группирования кнопок, создаём список.
            while(!streamreader.EndOfStream) // Заполняем список.
            {
                file.Add(int.Parse(streamreader.ReadLine()));
            }
            file.Sort(); // Сортируем список.
            int used = 0;
            int users = 0; // Эта переменная в данном случае будет выполнять ещё и функцию индекса для файла.
            do // Добавляем файлы на диск пока следующий файл ещё помещается.
            {
                used += file[users];
                users++;
            }
            while (used < disksize - file[users + 1]);
            streamreader.Close(); // Закрываем поток
            MessageBox.Show($"В архив можно поместить файлы {users} пользователей и при этом ещё останется место для файла объёмом {disksize - used}", 
                "Готово!"); // Выводим результат
        } // Легчайшая

        private void button1_Click(object sender, EventArgs e)/* Тут чисто выбор файла пользователем и занесение его в поле filename.
                                                               * И разблокирование основной кнопки
                                                               * Ничего особо интересного
                                                               */
        {
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    button2.Enabled = true;
                    label1.Text = $"Файл: {filename}";
                }
            }
        }
    }
}
