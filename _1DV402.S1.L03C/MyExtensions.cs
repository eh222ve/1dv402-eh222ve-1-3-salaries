using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DV402.S1.L03C.Properties;

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
