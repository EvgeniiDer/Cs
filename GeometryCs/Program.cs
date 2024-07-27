namespace GeometryCs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0)");
            for (uint i = 0; i < 5; i++)
            {
                for (uint j = 0; j < 5; j++)
                {
                    Console.Write('*');
                }
                Console.Write('\n');
            }
            Console.Write('\n');
            Console.Write("1)");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
                }
                Console.Write('\n');
            }
            Console.Write('\n');
            Console.WriteLine("2)");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 5; j > i; j--)
                {
                    Console.Write('*');
                }
                Console.Write('\n');
            }

            Console.WriteLine("3)");
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (j >= i)
                        Console.Write('*');
                    else if (j < i)
                        Console.Write(' ');

                }
                Console.Write('\n');
            }
            Console.Write('\n');
            Console.WriteLine("4)");
            for (int i = 1; i < 6; i++)
            {
                for (int j = 6; j > 0; j--)
                {
                    if (j > i)
                        Console.Write(' ');
                    else if (j <= i)
                        Console.Write('*');
                }
                Console.Write('\n');
            }
            Console.Write('\n');
            Console.WriteLine("5)");
            for (int i = 0; i < 6; i++)
            {
                for (int j = i; j < 6; j++)
                    Console.Write(' ');
                Console.Write('/');
                for (int j = 0; j < i * 2; j++)
                    Console.Write(' ');
                Console.Write('\\');
                Console.Write('\n');
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write(' ');
                Console.Write('\\');
                for (int j = (i + 1) * 2; j < (6) * 2; j++)
                    Console.Write(' ');
                Console.Write('/');
                Console.Write('\n');
            }
            Console.Write('\n');
            Console.WriteLine("6)");
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if ((i % 2) > 0)
                    {
                        if ((j % 2) > 0)
                            Console.Write('+');
                        else
                            Console.Write('-');
                    }
                    else if ((i % 2) == 0)
                    {
                        if ((j % 2) > 0)
                            Console.Write('-');
                        else
                            Console.Write('+');
                    }
                }
                Console.Write('\n');
            }

        }
    }
}
