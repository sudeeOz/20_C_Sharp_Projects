using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator
{
    public partial class Form1 : Form
    {
        bool IsClicked = false;

        string currentOperator = ""; //It matters which button you click on.
        string result = ""; 

        public Form1()
        {
            InitializeComponent();

            button0.Click += NumberButton_Click;
            button1.Click += NumberButton_Click;
            button2.Click += NumberButton_Click;
            button3.Click += NumberButton_Click;
            button4.Click += NumberButton_Click;
            button5.Click += NumberButton_Click;
            button6.Click += NumberButton_Click;
            button7.Click += NumberButton_Click;
            button8.Click += NumberButton_Click;
            button9.Click += NumberButton_Click;

            buttonAdd.Click += OperatorButton_Click;
            buttonSubtract.Click += OperatorButton_Click;
            buttonMultiply.Click += OperatorButton_Click;
            buttonDivide.Click += OperatorButton_Click;

            buttonEqual.Click += EqualsButton_Click;

            buttonClearButton.Click += ClearButton_Click;
            buttonBackSpace.Click += BackspaceButton_Click; 
            
            buttonPercent.Click += PercentButton_Click;

        }
        private void NumberButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            textBox2.Text += button.Text;
        }
            
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            currentOperator = button.Text;
            result = textBox2.Text;
            textBox1.Text = result + " " + currentOperator + " ";
            textBox2.Clear();
        }
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentOperator) || string.IsNullOrEmpty(textBox2.Text))
            {
                return; // No operation to perform
            }
            double num1 = Convert.ToDouble(result);
            double num2 = Convert.ToDouble(textBox2.Text);
            double calculationResult = 0;
            switch (currentOperator)
            {
                case "+":
                    calculationResult = num1 + num2;
                    break;
                case "-":
                    calculationResult = num1 - num2;
                    break;
                case "X":
                    calculationResult = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        calculationResult = num1 / num2;
                    else
                        MessageBox.Show("Cannot divide by zero.");
                    break;
            }
            textBox1.Text += textBox2.Text + " = " + calculationResult.ToString();
            textBox2.Clear();
            currentOperator = "";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            currentOperator = "";
            result = "";
        }
        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            }
        }
        private void PercentButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox2.Text, out double number))
            {
                textBox2.Text = (number / 100).ToString();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
    }
}
