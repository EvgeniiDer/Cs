using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в калькулятор!");

        Console.Write("Введите первое число: ");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите операцию (+, -, *, /): ");
        char operation = Convert.ToChar(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double number2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (operation)
        {
            case '+':
                result = number1 + number2;
                break;
            case '-':
                result = number1 - number2;
                break;
            case '*':
                result = number1 * number2;
                break;
            case '/':
                if (number2 != 0)
                {
                    result = number1 / number2;
                }
                else
                {
                    Console.WriteLine("Ошибка: деление на ноль!");
                    return;
                }
                break;
            default:
                Console.WriteLine("Ошибка: неправильная операция!");
                return;
        }

        Console.WriteLine("Результат: " + result);
    }
}
