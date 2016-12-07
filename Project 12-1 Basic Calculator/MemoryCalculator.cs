using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_14_1_Basic_Calculator
{
    public partial class MemCalc : Form
    {
        public MemCalc()
        {
            InitializeComponent();
        }
        MemoryCalculatorCl calc = new MemoryCalculatorCl();

        private void ButtonClick(object sender, EventArgs e)
        {
            decimal number;
            string operation;
            string inputv;
            string value;
            decimal total;
           

            try
            {
                if (calc.newCalculation == false)
                {
                    // Gets the text value from the clicked button via the sender
                    inputv = (sender as Button).Text;
                    calc.EnterValue(inputv);
                    if (calc.isNumeric(inputv))
                    {
                        number = Convert.ToDecimal(inputv);
                        if (calc.newInputs == false)
                            txtDisplay.Text += number.ToString();
                        else
                        {
                            txtDisplay.Text = number.ToString();
                            calc.newInputs = false;
                        }
                    }
                    else if (inputv == ".")
                        txtDisplay.Text += inputv;
                    else
                    {
                        
                        calc.newInputs = true;
                        if (txtDisplay.Text != "")
                        {
                            number = Convert.ToDecimal(txtDisplay.Text);
                        }
                        else
                        {
                            number = 0;
                            txtDisplay.Text = number.ToString();
                        }
                        switch (inputv)
                        {
                            case "+":
                                calc.Add(number);
                                break;
                            case "-":
                                calc.Subtract(number);
                                break;
                            case "*":
                                calc.Multiply(number);
                                break;
                            case "/":
                                if (number != 0)
                                    calc.Divide(number);
                                break;
                            case "=":
                                total = calc.Equals(number);
                                txtDisplay.Text = total.ToString();
                                break;
                            case "Back":
                                value = number.ToString();
                                txtDisplay.Text = value.Substring(0, value.Length - 1);
                                calc.newInputs = false;
                                break;
                            case "Clear":
                                calc.Clear();
                                txtDisplay.Text = "";
                                break;
                            case "+/-":
                                if (txtDisplay.Text != "")
                                {
                                    number = (Convert.ToDecimal(txtDisplay.Text)) * -1;

                                    txtDisplay.Text = number.ToString();

                                }
                                calc.newInputs = false;
                                break;
                            case "sqt":
                                txtDisplay.Text = (calc.SquareRoot(number)).ToString();
                                break;
                            case "1/X":
                                txtDisplay.Text = (calc.Reciprocal(number)).ToString();
                                break;
                            case "MS":
                                calc.MemoryStore(txtDisplay, lblMemory); 
                                break;
                            case "MC":
                                calc.MemoryClear(txtDisplay, lblMemory);
                                break;
                            case "MR":
                                calc.MemoryRecall(txtDisplay);
                                break;
                            case "M+":
                                calc.MemoryAdd(txtDisplay, lblMemory);
                                break;
                            }
                        
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("A value is needed for calculation", "Missing Value");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Can't divide by 0", "Divide By 0 Attempt");
                txtDisplay.Text = "ERROR";
                calc.newInputs = true;
            }
            catch (Exception)
            {
                MessageBox.Show("An unknown error has occurred", "Error");
            }
                
        }
        private bool isThere(TextBox vtextbox, string vname)
        {
            // Checks if textbox is empty or not
            if (vtextbox.Text == "")
            {
                MessageBox.Show(vname + " is empty. Try again.", "Missing Entry");
                return false;
            }
            return true;
        }

        private bool isNumber(TextBox vtextbox, string vname)
        {
            // Checks if textbox value can be converted correctly
            decimal number = 0;
            if (Decimal.TryParse(vtextbox.Text, out number))
                return true;
            else
            {
                MessageBox.Show(vname + " isn't a number. Try again.", "Incorrect Entry");
                return false;
            }
        }

        private void BasicCalc_KeyDown(object sender, KeyEventArgs e)
        {

            if (calc.isNumeric(e.KeyData.ToString()))
            //if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                button5.PerformClick();
            }
        }

        private void button9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (calc.isNumeric(e.KeyChar.ToString()))
            //if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                button5.PerformClick();
            }
            //if (e.KeyChar == Keys.NumPad5)
            //{
            //    button5.PerformClick();
            //}
        }
    }
}
