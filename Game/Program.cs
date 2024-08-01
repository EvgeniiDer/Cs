using System;


namespace Game{
  class Program
    {
    static int x = 0;
    static int y = 0;

    static void Main()
    {
        Console.CursorVisible = false;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.W)
                {
                    y--;
                }
                else if (key == ConsoleKey.S)
                {
                    y++;
                }
                else if (key == ConsoleKey.A)
                {
                    x--;
                }
                else if (key == ConsoleKey.D)
                {
                    x++;
                }

                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("■");
            }

            Thread.Sleep(50);
        }
    }
    }
}

