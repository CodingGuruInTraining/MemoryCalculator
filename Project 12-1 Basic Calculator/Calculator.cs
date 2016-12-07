using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_14_1_Basic_Calculator
{
    class Calculator
    {
        private decimal input;
        private List<decimal> inputs = new List<decimal>();
        private byte oper;      // 1 = ADD; 2 = SUBTRACT; 3 = MULTIPLY; 4 = DIVIDE
        private decimal total;
        private decimal[] values;
        public bool newInputs;
        public bool newCalculation;
        private decimal currentValue = 0;
        private bool firstInput;

        public Calculator()
        {
            values = new decimal[2];
        }

        public void EnterValue(string value)
        {
            if (isNumeric(value))
            {
                input = Convert.ToDecimal(value);
                inputs.Add(input);
                if (firstInput == false)
                {
                    firstInput = true;
                }
                else
                {

                }
            }
        }
        public void Add(decimal value)
        {
            values[0] = value;
            oper = 1;
        }
        public void Subtract(decimal value)
        {
            values[0] = value;
            oper = 2;
        }
        public void Multiply(decimal value)
        {
            values[0] = value;
            oper = 3;
        }
        public void Divide(decimal value)
        {
            values[0] = value;
            oper = 4;
        }
        public decimal Equals(decimal value)
        {
            values[1] = value;
            switch (oper)
            {
                case 1:
                    total = values[0] + values[1];
                    break;
                case 2:
                    total = values[0] - values[1];
                    break;
                case 3:
                    total = values[0] * values[1];
                    break;
                case 4:
                    total = values[0] / values[1];
                    break;
                default:
                    break;
            }
            return total;
        }
        public decimal Reciprocal(decimal value)
        {
            return 1 / value;
        }
        public decimal SquareRoot(decimal value)
        {
            return (decimal)Math.Sqrt((double)value);
        }
        public void Clear()
        {
            Array.Clear(values, 0, values.Length);
        }
        public bool isNumeric(string input)
        {
            decimal number = 0m;
            if (Decimal.TryParse(input, out number))
                return true;
            else
                return false;
        }
        
    }
}
