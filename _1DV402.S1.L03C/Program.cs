using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DV402.S1.L03C.Properties;

namespace _1DV402.S1.L03C
{
    class Program
    {
        static void Main()
        {
            MyExtensions.PrettyConsole(Resources.Console_Title);

            do
            {
                int total = ReadInt(Resources.NumberOfSalaries_Prompt, 2);
                int[] salary = ReadSalaries(total);
                ViewResult(salary);
            } while (IsContinuing());
        }

        //Prints out result to Console
        static void ViewResult(int[] salary)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("{0,-15}{1,15:c0}", Resources.Receipt_Average, salary.Average());
            Console.WriteLine("{0,-15}{1,15:c0}", Resources.Receipt_Median, MyExtensions.Median(salary));
            Console.WriteLine("{0,-15}{1,15:c0}", Resources.Receipt_Dispersion, MyExtensions.Dispersion(salary));
            Console.WriteLine("---------------------------------");

            for (int i = 0; i < salary.Length; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("{0, 10}", salary[i]);
            }
            Console.WriteLine();

        }

        //Read salaries to array
        static int[] ReadSalaries(int total)
        {
            int[] count = new int[total];

            int input;
            for (int i = 0; i < total; i++)
            {
                input = ReadInt(String.Format(Resources.Enter_Salary, i + 1));

                count[i] = input;
            }

            return count;
        }

        //Read int after prompt message and check for lowestValue
        static int ReadInt(string prompt, int lowestValue = 1)
        {

            int input = 0;
            while (input < lowestValue)
            {
                Console.Write(prompt);
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input < lowestValue)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    ViewMessage(String.Format(Resources.ArgumentOutOfRange_Error, input, lowestValue), ConsoleColor.Red);
                }
                catch
                {
                    ViewMessage(Resources.Unknown_Error, ConsoleColor.Red);
                }
            }

            return input;
        }

        //Prompt for keyinput - ESC returns false
        static bool IsContinuing()
        {
            ConsoleKeyInfo keyPress;

            ViewMessage(Resources.Continue_Prompt);
            keyPress = Console.ReadKey();

            if (keyPress.Key == ConsoleKey.Escape)
            {
                return false;
            }
            else
            {
                //Clear any information in console before next loop.
                Console.Clear();

                return true;
            }
        }

        //Displays message to user
        static void ViewMessage(string message, ConsoleColor backgroundColor = ConsoleColor.Blue, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            MyExtensions.ChangeColor(backgroundColor, foregroundColor);

            Console.WriteLine(message);

            MyExtensions.ChangeColor(ConsoleColor.White, ConsoleColor.Black);
        }
    }

    public class MyExtensions
    {
        //Calculates median number of array
        public static int Median(int[] count)
        {
            int[] sortedArray = count.OrderBy(i => i).ToArray();
            int salaries = sortedArray.Length;
            int medianSalary;

            if (salaries % 2 == 0)
            {
                medianSalary = ((sortedArray[salaries / 2 - 1]) + (sortedArray[salaries / 2])) / 2;
            }
            else
            {
                medianSalary = sortedArray[salaries / 2];
            }
            return medianSalary;

        }

        //Calculates max - min of int array
        public static int Dispersion(int[] count)
        {
            return count.Max() - count.Min();
        }

        //Changes appearance of console window
        public static void PrettyConsole(string title, ConsoleColor backgroundColor = ConsoleColor.White, ConsoleColor foregroundColor = ConsoleColor.Black)
        {
            Console.Title = title;
            ChangeColor(backgroundColor, foregroundColor);
            Console.Clear();
        }

        //Changes appearance of console text
        public static void ChangeColor(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }
    }
}
