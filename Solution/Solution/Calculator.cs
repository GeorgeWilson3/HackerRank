using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public interface AdvancedArithmetic
    {
        int divisorSum(int n);
    }

    class Calculator : AdvancedArithmetic
    {

        public int divisorSum(int n)
        {
            int result = 0;

            for (int i = n; i > 0; i--)
            {
                if (n % i == 0)
                {
                    result += i;
                }
            }

            return result;
        }

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
