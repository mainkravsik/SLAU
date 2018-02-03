using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CHM11
{
    public partial class Form1 : Form
    {
        Label[,] L;
        double[,] A;
        double[] B;
        double[,] UL;
        int n;
        int m1;
        int m2;
        int m3;
        int Ypos = 0;
        bool a;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            groupBox2.Parent = panel1.Parent;
            groupBox2.Left = 0;
            groupBox2.Top = 0;

            panel1.Left = 0;

            panel1.Top = groupBox2.Height;
            panel1.Height = groupBox1.Height - groupBox2.Height;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        public static void WriteIteration(string shapka, double[] O, int count, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            lab.Text = shapka;
            lab.Width = 100;
            lab.Height = 13;

            for (int j = 0; j < count; j++)
            {
                Label label = new Label();

                label.Parent = panel;
                label.Left = 180 + (200 * j) + 20;
                label.Top = Y0;
                label.Text = "X[" + Convert.ToString(j + 1) + "] = " + Convert.ToString(O[j]);
                label.Width = 200;
                label.Height = 13;
            }
            Y0 += 20;

        }

        public static void WriteLine(string shapka, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            
            lab.Text = shapka;
            lab.Width = 300;
            lab.Height = 13;

            Y0 += 50;
        }

        public static void WriteStroka(string shapka, double[] O, int count, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            Y0 += 50;
            lab.Text = shapka;
            lab.Width = 50;
            lab.Height = 13;

                for (int j = 0; j < count; j++)
                {
                    Label label = new Label();

                    label.Parent = panel;
                    label.Left = (50 * j) + 20;
                    label.Top = Y0;
                    label.Text = Convert.ToString(O[j]);
                    label.Width = 50;
                    label.Height = 13;
                }
                Y0 += 20;

        }

        public static void WriteMass(string shapka, double[,] O, int count, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            Y0 += 20;
            lab.Text = shapka;
            lab.Width = 70;
            lab.Height = 13;
            for (int i = 0; i < count; i++)
            {
                Y0 += 25;
                for (int j = 0; j < count; j++)
                {
                    
                    Label label = new Label();

                    label.Parent = panel;
                    label.Left = (50 * j) + 20;
                    label.Top = Y0 ;
                    label.Text = Convert.ToString(O[i,j]) + "  X" + Convert.ToString(j + 1);
                    label.Width = 50;
                    label.Height = 13;
                }
            }

            Y0 += 50;
        }


        public static void WriteSLAU(string shapka, double[,] O, double[] Otv, int count, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 70;
            lab.Top = Y0;
            Y0 += 20;
            lab.Text = shapka;
            lab.Width = 70;
            lab.Height = 13;
            for (int i = 0; i < count; i++)
            {
                Y0 += 25;
                for (int j = 0; j <= count + 1; j++)
                {

                    Label label = new Label();

                    label.Parent = panel;
                    label.Left = (50 * j) + 20;
                    label.Top = Y0;
                    if (j < count)
                    {
                        label.Text = Convert.ToString(O[i, j]) + "  X" + Convert.ToString(j + 1);
                    }
                    else if (j == count)
                    {
                        label.Text = " = ";
                    }
                    else if (j > count)
                    {
                        label.Text = Convert.ToString(Otv[i]);
                    }
                    label.Width = 50;
                    label.Height = 13;
                }
            }

            Y0 += 50;
        }

        static double SUMU(int i, int j, double[,] UL)
        {
            double SUM = 0;
            for (int k = 0; k <= i; k++)
            {
                SUM += (UL[i, k] * UL[k, j]);
                
            }
            return SUM;
        }

        static double SUML(int i, int j, double[,] UL)
        {
            double SUM = 0;
            for (int k = 0; k < j; k++)
            {
                SUM += (UL[i, k] * UL[k, j]);
            }
            return SUM;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text) > 1)
            {
                a = true;
                n = Convert.ToInt32(textBox1.Text);
                A = new double[n, n];
                B = new double[n];
                UL = new double[n, n];
                L = new Label[n, n + 1];
                m1 = 0;
                m2 = 0;
                m3 = 0;

                groupBox2.Visible = true;
                button3.Visible = true;
                button3.Enabled = true;
                textBox2.Enabled = true;
                textBox2.Text = "";
                label2.Text = "Элемент [1,1] =";
                textBox2.Focus();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Введите корректное число элементов!");
                textBox1.Focus();

            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Ypos = 0;
            panel1.Controls.Clear();
            WriteSLAU("СЛАУ = ", A, B, n, ref Ypos, ref panel1);
            n = Convert.ToInt32(textBox1.Text);
            
            UL = new double[n, n];
            bool BB = true;

            double[,] LL = new double[n, n];
            double[,] U = new double[n, n];
            

             for (int i = 0; i < n; i++)
             {
                for (int j = 0; j < n; j++)
                {
                    U[0, i] = A[0, i];
                    LL[i, 0] = A[i, 0] / U[0, 0];
                    double sum = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += LL[i, k] * U[k, j];
                    }
                    U[i, j] = A[i, j] - sum;
                    if (Double.IsNaN(U[i, j]))
                    {
                        BB = false;
                        break;
                        
                    }
                    if (i > j)
                    {
                        LL[j, i] = 0;
                    }
                    else
                    {
                        sum = 0;
                        for (int k = 0; k < i; k++)
                        {
                            sum += LL[j, k] * U[k, i];
                        }
                        LL[j, i] = (A[j, i] - sum) / U[i, i]; 

                        if (Double.IsNaN(LL[i, j]))
                        {
                            BB = false;
                            break;
                        }
                    }
                }

            }

             if (BB)
             {
                 double[] Y = new double[n];
                 double[] X = new double[n];
                
                 double[] suma = new double[3];
                 suma[0] = 1;
                 suma[1] = 0;
                 suma[2] = 7;
                 double sumat = 0;
                
                 sumat = 0;
                 for (int i = 0; i < n; i++)
                 {
                     Y[i] = 0;
                     X[i] = 0;
                 }
                 for (int i = 0; i < n; i++)
                 {
                     sumat = 0;
                     for (int k = 0; k <= i - 1; k++)
                     {
                         sumat += LL[i, k] * Y[k];
                     }
                     Y[i] = 1 / LL[i, i] * (B[i] - sumat);

                 }

                 for (int i = n - 1; i >= 0; i--)
                 {
                     sumat = 0;

                     for (int k = i + 1; k < n; k++)
                     {
                         sumat += U[i, k] * X[k];

                     }
                     X[i] = (Y[i] - (sumat)) / U[i, i];


                 }
                 

                 for (int i = 0; i < n; i++)
                 {
                     Y[i] = 0;
                 }

                 for (int i = 0; i < n; i++)
                 {
                     for (int j = i; j < n; j++)
                     {
                         Y[i] += U[i, j];
                     }
                 }
                 
                 WriteLine("____МЕТОД_LU_РАЗЛОЖЕНИЯ_____", ref Ypos, ref panel1);
                
                 WriteMass("Массив U", U, n, ref Ypos, ref panel1);

                 WriteMass("Массив L", LL, n, ref Ypos, ref panel1);

                 WriteStroka("Ответ: ", X, n, ref Ypos, ref panel1);
             }
             else MessageBox.Show("Данную СЛАУ невозможно решить методом LU - разложения!");
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

            if (number == 13)
            {
                button1_Click_1(this, EventArgs.Empty);
            }
        }

        static int Len(string s, char ch)
        {
            int k = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == ch)
                {
                    k += 1;
                }
            }

            return k;
        }

        static bool Ce(string s)
        {
            bool T = true;
            for (int i = 1; i <= s.Length - 1; i++)
            {
                if (s[i] == '-')
                {
                    T = false;
                }
            }
            return T;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox2.Text[0] != ',' && textBox2.Text[textBox2.Text.Length - 1] != ',')
                {
                    if (Len(textBox2.Text, ',') <= 1 && Ce(textBox2.Text))
                    {
                        if (textBox2.Text != "" && textBox2.Text != "-")
                        {
                            if (a)
                            {
                                L[m1, m2] = new Label();

                                L[m1, m2].Parent = panel1;
                                L[m1, m2].Left = (50 * m2) + 20;
                                L[m1, m2].Top = 100 + 25 * m1;
                                string str;
                                if (Convert.ToDouble(textBox2.Text) >= 0)
                                {
                                    str = "+";
                                }
                                else
                                {
                                    str = "-";
                                }
                                double g = Convert.ToDouble(textBox2.Text);
                                if (m2 > n - 1 || (m2 == 0 && g >= 0)) {L[m1, m2].Text = "   " + Convert.ToString(Math.Abs(Convert.ToDouble(textBox2.Text))) + "x" + Convert.ToString(m2 + 1); }
                                else L[m1, m2].Text = str + "   " + Convert.ToString(Math.Abs(Convert.ToDouble(textBox2.Text))) + "x" + Convert.ToString(m2 + 1); 
                                L[m1, m2].Width = 50;
                                A[m1, m2] = Convert.ToDouble(textBox2.Text);


                                if (m1 == n - 1 && m2 == n - 1)
                                {


                                    label2.Text = "Элемент b[" + Convert.ToString(m3 + 1) + "] =";

                                    for (int i = 0; i <= n - 1; i++)
                                    {
                                        Label LL = new Label();
                                        LL.Parent = panel1;
                                        LL.Left = 50 * n + 20;
                                        LL.Top = 100 + 25 * i;
                                        LL.Text = "=";
                                        LL.Width = 10;
                                    }
                                    a = false;
                                }
                                else

                                    if (m2 == n - 1 && m1 != n - 1)
                                    {
                                        m2 = 0;
                                        m1 += 1;
                                        label2.Text = "Элемент [" + Convert.ToString(m1 + 1) + "," + Convert.ToString(m2 + 1) + "]=";
                                    }
                                    else
                                    {
                                        m2 += 1;
                                        label2.Text = "Элемент [" + Convert.ToString(m1 + 1) + "," + Convert.ToString(m2 + 1) + "]=";

                                    }



                                textBox2.Focus();
                                textBox2.Text = "";

                            }
                            else
                            {
                                L[m3, n] = new Label();
                                L[m3, n].Parent = panel1;
                                L[m3, n].Left = 50 * n + 50;
                                L[m3, n].Top = 100 + 25 * m3;
                                L[m3, n].Text = textBox2.Text;
                                L[m3, n].Width = 40;
                                B[m3] = Convert.ToDouble(textBox2.Text);


                                if (m3 == n - 1)
                                {
                                    label2.Text = "Элемент [1,1] =";
                                    button3.Enabled = false;
                                    groupBox2.Visible = false;
                                    textBox2.Enabled = false;
                                    button2.Enabled = true;
                                    button5.Enabled = true;
                                    button6.Enabled = true;
                                    button7.Enabled = true;
                                    button8.Enabled = true;
                                }
                                else
                                {
                                    m3 += 1;
                                    label2.Text = "Элемент b[" + Convert.ToString(m3 + 1) + "] =";

                                    textBox2.Focus();
                                    textBox2.Text = "";

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите элемент!");
                        }
                    }
                    else
                    {
                        textBox2.Text = "";
                        MessageBox.Show("Не корректный формат данных, эжжи!!!");
                        textBox2.Focus();
                    }
                }
                else
                {
                    textBox2.Text = "";
                    MessageBox.Show("Не корректный формат данных, эжжи!!!");
                    textBox2.Focus();
                }
            }
            else
            {
                textBox2.Text = "";
                MessageBox.Show("Не корректный формат данных, эжжи!!!");
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                button3_Click_1(this, EventArgs.Empty);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ypos = 0;
            panel1.Controls.Clear();
            groupBox2.Visible = false;
            button3.Visible = false;
            textBox2.Enabled = false;
            button1.Enabled = true;
            textBox1.Focus();
            button2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Left = 0;
            
            panel1.Top = groupBox2.Height;
            panel1.Height = groupBox1.Height - groupBox2.Height;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ypos = 0;
            panel1.Controls.Clear();
            WriteSLAU("СЛАУ = ", A, B, n, ref Ypos, ref panel1);
            double tmp;
            double[] X = new double[n];
            double[,] AA = new double[n, n + 1];
            bool BB = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    AA[i,j] = A[i,j];
                }
            }
            for (int j = 0; j < n; j++)
            {
                AA[j, n] = B[j];
            }

                for (int i = 0; i < n; i++)
                {
                    tmp = AA[i, i];
                    for (int j = n; j >= i; j--)
                    {
                        AA[i, j] /= tmp;
                    }
                    for (int j = i + 1; j < n; j++)
                    {
                        tmp = AA[j, i];
                        for (int k = n; k >= i; k--)
                        {
                            AA[j, k] -= tmp * AA[i, k];
                        }
                    }
                }


            X[n - 1] = AA[n - 1,n];
            for (int i = n - 2; i >= 0; i--)
            {
                X[i] = AA[i,n];
                for (int j = i + 1; j < n; j++)
                {
                    X[i] -= AA[i,j] * X[j];
                    if (Double.IsNaN(X[i]))
                    {
                        BB = false;
                        break;
                    }
                }
            }

            if (BB)
            {
                WriteLine("______МЕТОД_ГАУСА_______", ref Ypos, ref panel1);
                WriteStroka("Ответ: ", X, n, ref Ypos, ref panel1);
            }
            else MessageBox.Show("Данную СЛАУ невозможно решить методом Гауса!");


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ypos = 0;
            panel1.Controls.Clear();
            WriteSLAU("СЛАУ = ", A, B, n, ref Ypos, ref panel1);

            double eps = .000001;
            double max;
            double[] X = new double[n];
            double[,] AA = new double[n,n];


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    AA[i, j] = A[i, j];
                }
                X[i] = B[i];
            }

            
            int max_i;
            double lead, a_div_lead;
            for (int k = 0; k < n; k++)
            {
                max = 0;
                max_i = -1;
                for (int i = k; i < n; i++)
                {
                    if (Math.Abs(AA[i,k]) > max)
                    {
                        max = Math.Abs(AA[i,k]);
                        max_i = i;
                    }
                }
                if (max_i == -1 || Math.Abs(AA[max_i,k]) < eps)
                {
                    
                    MessageBox.Show("Определитель равен 0");
                    break;
                }
                lead = AA[k,k];
                for (int j = k; j < n; j++)
                    AA[k,j] /= lead;
                X[k] /= lead;
                for (int i = 0; i < n; i++)
                {
                    a_div_lead = AA[i,k] / AA[k,k];
                    if (i != k)
                    {
                        for (int j = k; j < n; j++)
                            AA[i,j] -= AA[k,j] * a_div_lead;
                        X[i] -= X[k] * a_div_lead;
                    }
                }

               

            }

           

            WriteLine("____МЕТОД_ЖАРДАНА-ГАУСА_____", ref Ypos, ref panel1);
            WriteStroka("Ответ: ", X, n, ref Ypos, ref panel1);


       

        }

        public static bool diag_element_max(double[] mas, int pos, int n)
        {
            bool BB = true;
            for (int i = 0; i < pos; i++)
            {
                if (Math.Abs(mas[i]) >= Math.Abs(mas[pos]))
                {
                    BB = false; break;
                }
            }
            for (int i = pos + 1; i < n; i++)
            {
                if (Math.Abs(mas[i]) >= Math.Abs(mas[pos]))
                {
                    BB = false; break;
                }
            }

                return BB;
        }

        public static bool DXEPS(double[] X, double[] Xpred, double eps, int n)
        {
            bool p = false;
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(X[i] - Xpred[i]) <= eps)
                {
                    p = true;
                }
                else 
                {
                    p = false;
                }
                for (int j = 0; j < n; j++)
                {
                }
            }
            return p;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool[] At = new bool[n];
            double[] aa = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    aa[j] = A[i, j];
                }
               At[i] = diag_element_max(aa, i, n);
            }
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (At[i] == false)
                {
                    k++;
                }
            }
            if (k > 0)
            {

                MessageBox.Show("ай-яй-яй, надо ввести правильно!");

            }
            else
            {
                Ypos = 0;
                panel1.Controls.Clear();
                WriteSLAU("СЛАУ = ", A, B, n, ref Ypos, ref panel1);
                WriteLine("___МЕТОД_ПРОСТОЙ_ИТЕРЕЦИИ___", ref Ypos, ref panel1);
                double[] Xpred = new double[n];
                double[] X = new double[n];
                int iter = 0;
                 for (int i = 0; i < n; i++)
                 {
                     X[i] = 0;
                     Xpred[i] = 0;
                 }

                 while (true)
                 {
                     iter++;
                     for (int i = 0; i < n; i++)
                     {
                         X[i] = 0;
                         
                         for (int j = 0; j < i; j++)
                         {
                             X[i] += Xpred[j]  * (-A[i, j]/ A[i, i]);
                         }
                         for (int j = i + 1; j < n; j++)
                         {
                             X[i] += Xpred[j] * (-A[i, j] / A[i, i]);
                         }
                         X[i] += B[i] / A[i, i];
                         
                     }
                     WriteIteration("Итериция " + Convert.ToString(iter) + " : ",X, n, ref Ypos, ref panel1);
                     if (DXEPS(X, Xpred, 0.001, n)) { break; }
                     else if (iter > 20)
                     {
                         WriteLine("Совершено более 20 итераций!", ref Ypos, ref panel1);
                         break;
                     }
                     else
                     {
                         for (int u = 0; u < n; u++)
                         {
                             Xpred[u] = X[u];
                         }
                     }
                 }

                 
                 WriteStroka("Ответ: ", X, n, ref Ypos, ref panel1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool[] XXX = new bool[n];
            bool[] At = new bool[n];
            double[] aa = new double[n];
            for (int i = 0; i < n; i++)
            {
                XXX[i] = false;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    aa[j] = A[i, j];
                }
                At[i] = diag_element_max(aa, i, n);
            }
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (At[i] == false)
                {
                    k++;
                }
            }
            if (k > 0)
            {

                MessageBox.Show("ай-яй-яй, надо ввести правильно!");

            }
            else
            {
                Ypos = 0;
                panel1.Controls.Clear();
                WriteSLAU("СЛАУ = ", A, B, n, ref Ypos, ref panel1);
                WriteLine("_______МЕТОД_ЗЕЙДЕЛЯ________", ref Ypos, ref panel1);
                double[] Xpred = new double[n];
                double[] X = new double[n];
                int iter = 0;
                for (int i = 0; i < n; i++)
                {
                    X[i] = 0;
                    Xpred[i] = 0;
                }

                while (true)
                {
                    iter++;
                    for (int i = 0; i < n; i++)
                    {
              
                        X[i] = 0;

                        for (int j = 0; j < i; j++)
                        {
                            if (XXX[j])
                            {
                                X[i] += X[j] * (-A[i, j] / A[i, i]);
                            }
                            else
                            {
                                X[i] += Xpred[j] * (-A[i, j] / A[i, i]);
                            }
                           
                        }
                        for (int j = i + 1; j < n; j++)
                        {
                            if (XXX[j])
                            {
                                X[i] += X[j] * (-A[i, j] / A[i, i]);
                            }
                            else
                            {
                                X[i] += Xpred[j] * (-A[i, j] / A[i, i]);
                            }
                            
                        }
                        X[i] += B[i] / A[i, i];

                        XXX[i] = true;

                    }
                    WriteIteration("Итериция " + Convert.ToString(iter) + " : ", X, n, ref Ypos, ref panel1);
                    if (DXEPS(X, Xpred, 0.001, n)) { break; }
                    else
                    {
                        for (int u = 0; u < n; u++)
                        {
                            Xpred[u] = X[u];
                            XXX[u] = false;
                        }
                    }
                }

                
                WriteStroka("Ответ: ", X, n, ref Ypos, ref panel1);
            }
        }


    }
}
