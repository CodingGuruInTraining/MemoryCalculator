using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_14_1_Basic_Calculator
{
    class MemoryCalculatorCl : Calculator
    {
        
        public decimal storedValue;


        public void MemoryStore (TextBox vtextbox, Label mlabel)
{
            Decimal displayValue = Convert.ToDecimal(vtextbox.Text);
            storedValue = displayValue;
            mlabel.Text = "M";
}
        public void MemoryRecall(TextBox vtextbox)
        {
            vtextbox.Text = storedValue.ToString();
        }
        public void MemoryClear(TextBox vtextbox, Label mlabel)
        {
            storedValue = default(decimal);
            mlabel.Text = "";
            vtextbox.Text = "";
        }
        public void MemoryAdd(TextBox vtextbox, Label mlabel)
        {
            storedValue += Convert.ToDecimal(vtextbox.Text);
            mlabel.Text = "M";
        }

    }
}
