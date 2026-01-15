using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class MenuLogicActions
    {
        public static void ShowCurrentTime()
        {
            string currentTime = string.Format("Current Time is {0:HH:mm:ss}", DateTime.Now);
            Console.WriteLine(currentTime);
        }

        public static void ShowCurrentDate()
        {
            string currentDate = string.Format("Current Date is {0:dd/MM/yyyy}", DateTime.Now);
            Console.WriteLine(currentDate);
        }

        public static void ShowVersion()
        {
            string versionInfo = "Version: 26.1.4.5940";
            Console.WriteLine(versionInfo);
        }

        public static void CountLowercase()
        {
            Console.WriteLine("Please enter a string:");
            string input = Console.ReadLine();

            int lowercaseCount = 0;

            foreach (char c in input)
            {
                if (char.IsLower(c))
                {
                    lowercaseCount++;
                }
            }

            string message = string.Format("> There are {0} lowercase letters in your text}", lowercaseCount);
            Console.WriteLine(message);
        }
    }
}
