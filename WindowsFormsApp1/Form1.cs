using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLibrary.Mathematics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double[,] matrix = new double[3,3];
        double[] x = new double[3];
        public Form1()
        {
            InitializeComponent();
        }
        void onlyNumber(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!(Char.IsDigit(number) || Char.IsControl(number) || Char.IsPunctuation(number)))
            {
                e.Handled = true;
            }
        }
        private void button_calculate_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                try
                {
                    matrix = new double[3, 3]
                    {
                    {double.Parse(textBox1.Text),double.Parse(textBox2.Text),double.Parse(textBox3.Text) },
                    {double.Parse(textBox4.Text),double.Parse(textBox5.Text),double.Parse(textBox6.Text) },
                    {double.Parse(textBox7.Text),double.Parse(textBox8.Text),double.Parse(textBox9.Text) }
                    };
                    x = new double[3] { double.Parse(textBox10.Text), double.Parse(textBox11.Text), double.Parse(textBox12.Text) };
                    
                    double[] answers = new double[3];

                    if (comboBox1.SelectedIndex == 0)
                    {
                        try
                        {
                            answers = SystemOfLinearAlgebraicEquations.GaussianMethod(matrix, x);
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Неможливо обчислити методом Гаусса", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            answers = SystemOfLinearAlgebraicEquations.MethodOfSimpleIteration(matrix, x);
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Ітераційний процес не збігається - дану СЛАР неможливо обрахувати методом простих ітерацій", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    
                    textBox_res1.Text = answers[0].ToString();
                    textBox_res2.Text = answers[1].ToString();
                    textBox_res3.Text = answers[2].ToString();
                }
                catch
                {
                    MessageBox.Show("Можливо деякі комірки пусті, або містять у собі некоректне значення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Оберіть метод", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
