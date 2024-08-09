using System;

namespace Calc2
{
       class Program
       {
        static string expression;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter expression");
            //expression = Console.ReadLine();
            expression = "22+33*44-55/11";
            Console.WriteLine($"{expression}");
            //char[] delimiters = new char[] {'+', '-', '*', '/' };
            string[] s_numbers = expression.Split('+', '-', '*', '/');
            for(int i = 0; i < s_numbers.Length; i++)
            {
                Console.Write($"{s_numbers[i]} \t");
            }
            Console.WriteLine();
            double[] numbers =new double[s_numbers.Length];
            for (int i = 0; i < s_numbers.Length; i++)
            {
                numbers[i] = Convert.ToDouble(s_numbers[i]);
                Console.Write($"{ numbers[i]} \t");
            }
            Console.WriteLine();
            string[] operators = expression.Split('0', '1', '2', '3', '4', '5', '6', '7', '8', ' ', '.');
            operators = operators.Where(val => val != "").ToArray();
            for (int i = 0; i < operators.Length; i++)
            {
                Console.Write($"{operators[i]} \t");
            }
            for(int i = 0; i < operators.Length; i++) 
                {
                if (operators[i] == "*" || operators[i] == "/")
                    {
                    if (operators[i] == "*")
                        numbers[i] *= numbers[i +1];
                    if(operators[i] == "/")
                        numbers[i] /= numbers[i +1];
                    ShiftLeft(numbers, i + 1);
                    ShiftLef(operators, i );
                    }
                
                }
                PrintStr(operators);
                PrintD(numbers);
            for (int i = 0; i < operators.Length; i++)
            {
                while (operators[i] == "+" || operators[i] == "-")
                {
                    if (operators[i] == "+")
                        numbers[i] += numbers[i + 1];
                    if (operators[i] == "-")
                        numbers[i] -= numbers[i + 1];
                    ShiftLeft(numbers, i + 1);
                    ShiftLef(operators, i);
                }

            }
            PrintStr(operators);
            PrintD(numbers);
            static void PrintD(double[] arr)
            {
                for(int i = 0; i < arr.Length; i++)
                       Console.Write($"{arr[i]} \t");
                Console.WriteLine();
            }
            static void PrintStr(string[] arr)
            {
                for(int i = 0; i < arr.Length; i++)
                    Console.Write($"{arr[i]} \t");
                Console.WriteLine();
            }
            static double[] ShiftLeft(double[] array, int index = 0)
            {
                for(int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[array.Length - 1] = 0;
                return array;
            }
            static string[] ShiftLef(string[] array, int index = 0)
            {
                for(int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[array.Length - 1] = null;
                return array;
            }
            Console.ReadKey();
        }
    }
}
