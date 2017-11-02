using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Printer
    {
        /**
        *    Name: PrintArray
        *    Print each element of the generic array on a new line. Do not return anything.
        *    @param A generic array
        **/
        // Write your code here

        public void PrintArray<T>(T toPrint)
        {
            Console.WriteLine(toPrint);
        }

    }
}
