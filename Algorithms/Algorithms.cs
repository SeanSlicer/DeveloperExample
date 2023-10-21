using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n){
            int factorial = 1;

            for (int i = n; i > 1 ; i--) 
            {
                 factorial *= i;
            }
        return factorial;
        }

        public static string FormatSeparators(params string[] items) {
            string returnString = "";
            for (int i = 0; i < items.Length; i++) {
                if (i == items.Length - 1) {
                    returnString += items[i-1] + " and " + items[i];
                }
                else if (i != items.Length - 2) {
                    returnString += items[i] + ", ";
                }
            }
            return returnString;
        }
    }
}