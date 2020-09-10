using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP_3514_CS_Calculator
{
    public partial class Form1 : Form
    {
        string input1 = string.Empty;
        string input2 = string.Empty;
        string method = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearInput(object sender, EventArgs e)
        {
            string identifier = (sender as Button).Text;

            switch (identifier)
            {
                case "C":
                    textBox1.Text = "0";
                    break;
                case "C / A":
                    textBox1.Text = "0";
                    this.input1 = string.Empty;
                    this.input2 = string.Empty;
                    this.method = string.Empty;
                    break;
            }

        }

        private void NumberButtonClick(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = buttonText;
            }
            else
            {
                textBox1.Text += buttonText;
            }

        }

        private void Calculate(object sender, EventArgs e)
        {
            
            this.method = (sender as Button).Text;
            this.input1 = textBox1.Text;
            textBox1.Text = "0";
            
        }

      
        private void SolutionGetter(object sender, EventArgs e)
        {
            try
            {
                this.input2 = textBox1.Text;

                double num1 = Convert.ToDouble(this.input1);
                double num2 = Convert.ToDouble(this.input2);

                double solution;

                switch (this.method)
                {
                    case "+":
                        solution = num1 + num2;
                        break;
                    case "-":
                        solution = num1 - num2;
                        break;
                    case "*":
                        solution = num1 * num2;
                        break;
                    case "/":
                        solution = num1 / num2;
                        break;
                    default: throw new Exception("invalid logic");
                }

                textBox1.Text = solution.ToString();
            }
            catch
            {
                textBox1.Text = "Enter a number";
            }
            
        }

       
    }
}
