using System;
using System.Linq;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        // public static int GetFactorial(int n)
        // {
        //     int factorial = 1;

        //     for (int i = n; i > 1; i--)
        //     {
        //         factorial *= i;
        //     }
        //     return factorial;
        // }
        public static int GetFactorial(int n)
        {

            if (n < 0)
            {
                throw new ArgumentException("factorial not defined");
            }
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * GetFactorial(n - 1);

        }


        public static string FormatSeparators(params string[] items)
        {

            if (items == null || items.Length == 0)
            {
                return string.Empty;
            }
            if (items.Length == 1)
            {
                return items[0];

            }
            string lastItem = items.Last();
            string joinedStrings = string.Join(", ", items, 0, items.Length - 1);
            string returnString = joinedStrings + " and " + lastItem;
            return returnString;
        }
    }
}
