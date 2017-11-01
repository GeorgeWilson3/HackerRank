using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Calculator
    {

        public int power(int n, int p)
        {
            int result = 0;

            if (n < 0 || p < 0)
            {
                throw new System.ArgumentException("n and p should be non-negative");
            }
            else
            {
                result = Convert.ToInt32(Math.Pow(n, p));
            }

            return result;
        }
    }
}
