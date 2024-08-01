using System;

namespace ChessBoard

{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;

	        for(int a = 0; a < n; a++ )
	            {
		            for(int b = 0; b < n; b++)
		                {
			                for(int c = 0; c < n; c++)
				                {
					                for(int d = 0; d < n; d++)
					                    {
						                    if((a + c) % 2 == 0)
                                                {
                                                    Console.Write("*");
                                                }
                                            else
                                                Console.Write(" ");
					                    }		
				                }
                                Console.WriteLine();
		                }
	            }
            }

    }
}
