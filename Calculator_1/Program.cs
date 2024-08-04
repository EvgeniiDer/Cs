using System;
namespace Calculator_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Expression:");
            string input = Console.ReadLine();

            var result = new System.Data.DataTable().Compute(input, "");
            Console.WriteLine("Результат: " + result);
            Console.ReadKey();

        }
    }
}
