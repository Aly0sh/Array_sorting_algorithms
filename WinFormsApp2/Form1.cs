using System.Diagnostics;

namespace WinFormsApp2
{

    public partial class Form1 : Form
    {

        private List<int> list = new List<int>();
        private Form2 f2;

        public Form1()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void generateList(int x, int y)
        {
            Random rnd = new Random();
            if (list.Count != 0)
            {
                list.Clear();
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(rnd.Next(x, y));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                listBox1.Items.Add("Введите значения в поля для ввода");
                listBox1.Items.Add("--------------------------------------");
            }
            else
            {
                generateList(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
                label3.Text = String.Join(", ", list);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                listBox1.Items.Add("Массив пустой");
                listBox1.Items.Add("--------------------------------------");
            }
            else
            {
                if (radioButton1.Checked)
                {
                    sort1();
                }
                else if (radioButton2.Checked)
                {
                    sort2();
                }
                else if (radioButton3.Checked)
                {
                    sort3();
                }
                else
                {
                    listBox1.Items.Add("Выберите сортировку");
                    listBox1.Items.Add("--------------------------------------");
                }
            }
        }

        private void sort1()
        {
            listBox1.Items.Add("Гномья сортировка");
            listBox1.Items.Add("");
            List<int> list1 = list.ToList();
            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 19; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (list1[j] > list1[j + 1])
                    {
                        list1.Swap(j, j + 1);
                    }
                    else
                    {
                        break;
                    }
                }
                listBox1.Items.Add("Итерация " + (i + 1) + " - " + String.Join(", ", list1));
            }
            timer.Stop();
            listBox1.Items.Add(timer.Elapsed.ToString());
            label5.Text = timer.Elapsed.ToString();
            listBox1.Items.Add("--------------------------------------");
            progressBar1.Value = timer.Elapsed.Milliseconds * 10;
        }

        private void sort2()
        {
            listBox1.Items.Add("Сортировка подсчетом");
            listBox1.Items.Add("");
            List<int> list1;
            List<int> sortedList = new List<int>();
            var timer = new Stopwatch();
            timer.Start();
            list1 = list.ToHashSet().ToList();
            list1.Sort();
            for (int i = 0; i < list1.Count(); i++)
            {
                for (int j = 0; j < list.Count(n => n == list1[i]); j++)
                {
                    sortedList.Add(list1[i]);
                }
                listBox1.Items.Add("Итерация " + (i + 1) + " - " + String.Join(", ", sortedList));
            }
            timer.Stop();
            listBox1.Items.Add(timer.Elapsed.ToString());
            listBox1.Items.Add("--------------------------------------");
            progressBar2.Value = timer.Elapsed.Milliseconds * 10;
            label6.Text = timer.Elapsed.ToString();
        }

        private void sort3()
        {
            listBox1.Items.Add("Шейкерная сортировка со вставками");
            listBox1.Items.Add("");
            int it = 1;
            bool cicle = true;
            bool swaped;
            List<int> list1 = list.ToList();
            var timer = new Stopwatch();
            timer.Start();
            while (cicle)
            {
                swaped = false;
                listBox1.Items.Add("Итерация " + (it) + " - " + String.Join(", ", list1));
                for (int i = 0; i < 19; i++)
                {
                    if (list1[i] > list1[i + 1])
                    {
                        list1.Swap(i, i + 1);
                        swaped = true;
                    }
                }
                if (!swaped)
                {
                    break;
                }
                it++;
                swaped = false;
                listBox1.Items.Add("Итерация " + (it) + " - " + String.Join(", ", list1));
                for (int i = 18; i >= 0; i--)
                {
                    if (list1[i] > list1[i + 1])
                    {
                        list1.Swap(i, i + 1);
                        swaped = true;
                    }
                }
                cicle = swaped;
                it++;
            }
            timer.Stop();
            listBox1.Items.Add(timer.Elapsed.ToString());
            listBox1.Items.Add("--------------------------------------");
            progressBar3.Value = timer.Elapsed.Milliseconds * 10;
            label7.Text = timer.Elapsed.ToString();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-';
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-';
        }

        private void гномьяСортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.Show();
        }

        private void сортировкаПодсчетомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void шейкернаяСортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void итогиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }
    }
}

public static class Extensions
{
    public static void Swap<T>(this List<T> list, int i, int j)
    {
        (list[i], list[j]) = (list[j], list[i]);
    }
}