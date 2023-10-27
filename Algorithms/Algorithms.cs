using System;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            int factorial = 1;

            for (int i = n; i > 1; i--)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder returnString = new();

            for (int i = 0; i < items.Length; i++)
            {
                returnString.Append(items[i]);

                if (i < items.Length - 2)
                {
                    returnString.Append(", ");
                }
                else if (i == items.Length - 2)
                {
                    returnString.Append(" and ");
                }
            }

            return returnString.ToString();
        }
    }
}
