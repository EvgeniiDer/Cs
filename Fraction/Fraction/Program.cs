using System;

namespace Net8{
    class MyProgram{
        static void Main(string[] argv)
        {

            Fraction A = new Fraction( 2, 1, 2);
            Fraction B = new Fraction( 3, 1, 5);
            Console.WriteLine(A < B);

            
        }
    }
}