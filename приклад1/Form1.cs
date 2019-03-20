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

namespace приклад1
{
    public partial class Form1 : Form
    {
        int N, M;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Output(int[,] matrix) //вывод
        {
            dataGridView1.ColumnCount = M;
            dataGridView1.RowCount = N;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    dataGridView1[j, i].Value = matrix[i, j].ToString();
            }
        }
        private int[,] FromFile(string fname)
        {
            int[,] matrix = new int[0, 0];
            using (StreamReader read = new StreamReader(fname))
            {
                while (!read.EndOfStream)
                {
                    N = Convert.ToInt32(read.ReadLine());
                    M = Convert.ToInt32(read.ReadLine());
                    matrix = new int[N, M];
                    for (int i = 0; i < N; i++)
                    {
                        string tmp = read.ReadLine();
                        var array = tmp.Split(' ');
                        for (int j = 0; j < M; j++)
                            matrix[i, j] = Convert.ToInt32(array[j]);
                    }
                }
            }
            return matrix;
        }
        private int[,] FromKB(string filename="")
        {
           int[,] matrix = new int[0, 0];
            N = Convert.ToInt32(textBox6.Text);
            M = Convert.ToInt32(textBox7.Text);
            matrix = new int[N, M];
            dataGridView1.RowCount=N;
            dataGridView1.ColumnCount=M;
                    //matrix[i, j] = Convert.ToInt32(textBox10.Text[j]);
                    //if(matrix[i,0]>matrix[0,j])
                    //{
                    //    int tmp = matrix[i, 0];
                    //    matrix[i, 0] = matrix[0, j];
                    //    matrix[0, j] = tmp;
                    //}
                    //                    int[] array = new int[42];
                    //for (int i = 0; i < array.Length; i++)
                    //   array[i] = int.Parse(Console.ReadLine());
                    //matrix[i, j] = Convert.ToInt32(dataGridView1[j, i]);
                //matrix[i, j] = Convert.ToInt32(DataGridViewTextBoxCell);
                ////dataGridView1.

                   
                           
            return matrix;
        }
        private int[,] FromRand(string rd)
        {
            int[,]matrix = new int[0, 0];
            int a = Convert.ToInt32(textBox4.Text);
           int b = Convert.ToInt32(textBox5.Text);
           N = Convert.ToInt32(textBox8.Text);
           M = Convert.ToInt32(textBox9.Text);
           matrix = new int[N, M];
            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    matrix[i, j] = rand.Next(a,b);
            }
            return matrix;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //int[,] matrix = FromFile(textBox3.Text.ToString());
            //Output(matrix);
            //textBox1.Text = FindMaximum().ToString();
            //textBox2.Text = FindMinimum().ToString();
            //Graphics(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }
        private int FindMaximum() //maximum
        {
            int max = Convert.ToInt32(dataGridView1[0, 0].Value);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (max < Convert.ToInt32(dataGridView1[j, i].Value))
                        max = Convert.ToInt32(dataGridView1[j, i].Value);
                }
            }
            return Math.Abs(max);
        }
        private int FindByModule(int number, int mod) //по модулю
        {
            /* while (!(number>=0 && number<mod))
            number-=mod;*/
            return number % mod;
        }
        private int FindMinimum() //minimun
        {
            int min = Convert.ToInt32(dataGridView1[0, 0].Value);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (i == j && min > Convert.ToInt32(dataGridView1[j,

                    i].Value))
                        min = Convert.ToInt32(dataGridView1[j, i].Value);
                }
            }
            return FindByModule(Math.Abs(min), 3);
        }
        private void Graphics(int R, int h)
{
float x = 50, y = 50;
Graphics g = pictureBox1.CreateGraphics();
int centerX = pictureBox1.Width/2, 
centerY=pictureBox1.Height/2;
Random r=new Random();
while(R>0)
{
g.DrawEllipse(new Pen(Color.FromArgb(r.Next(255), r.Next(255),r.Next(255), r.Next(255)), 3),new Rectangle(new Point(centerX - R, centerY - R),new Size(2 * R, 2 * R)));
R -= h;
}
}

        private void button2_Click(object sender, EventArgs e)//file input
        {
            //string fn = textBox3.Text.ToString();
         
            //int[,] matrix=new int[0,0];
            //StreamReader read=new StreamReader(fn);
            //while(!read.EndOfStream)
            //{
            //    N = Convert.ToInt32(read.ReadLine());
            //    M = Convert.ToInt32(read.ReadLine());
            //    matrix=new int[N,M];
            //    for(int i=0;i<N;i++)
            //    { 
            //        string tmp = read.ReadLine();
            //    var ar = tmp.Split(' ');
            //          for(int j=0;j<M;j++)
            //                                matrix[i, j] = Convert.ToInt32(ar[j]); 
            //    }
            //} read.Close();
            //dataGridView1.ColumnCount = M;
            //dataGridView1.RowCount = N;
            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < M; j++)
            //        dataGridView1[j, i].Value = matrix[i, j];
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[,] matrix = FromKB();
            Output(matrix);
            textBox1.Text = FindMaximum().ToString();
            textBox2.Text = FindMinimum().ToString();
            Graphics(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }

        private void button2_Click_1(object sender, EventArgs e)//из файла
        {
            int[,] matrix = FromFile(textBox3.Text.ToString());
            Output(matrix);
            textBox1.Text = FindMaximum().ToString();
            textBox2.Text = FindMinimum().ToString();
            Graphics(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }

        private void button3_Click(object sender, EventArgs e)//случайными
        {
            int[,] matrix = FromRand(textBox3.Text.ToString());
            Output(matrix);
            textBox1.Text = FindMaximum().ToString();
            textBox2.Text = FindMinimum().ToString();
            Graphics(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
             int[,] matrix = FromKB();
             for (int i = 0; i < N; i++)
             {
                 for (int j = 0; j < M; j++)
                     matrix[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
             }
             Output(matrix);
             textBox1.Text = FindMaximum().ToString();
             textBox2.Text = FindMinimum().ToString();
             Graphics(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }
    }
}
