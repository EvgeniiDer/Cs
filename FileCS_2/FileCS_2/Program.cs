using System;
using System.IO;
namespace FileCpp_2
{
    class MainClss{
        static void Main(string[]argv)
        {
            const string INFILE = "201 RAW.txt";
            const string OUTFILE = "201.dhcpd.txt";
            List<int> distance = new List<int>();
            string text;
            StreamReader sr = new StreamReader(INFILE);
            string[] words;
            List<string> word = new List<string>();
            while((text = sr.ReadLine()) != null)
                {
                    words = text.Split(' ');
                        for(int i = 0; i < words.Length; i++)
                        {
                            if(!string.IsNullOrWhiteSpace(words[i]))
                                {
                                    word.Add(words[i]);
                                    
                                }
                        }
                    }
                    StreamWriter sw = new StreamWriter(OUTFILE);
                    for(int j = 0, i = 1; j < word.Count - 1;i++,j += 2) 
                        {   
                            sw.Write($"host-{i}\n{{\n\thardware ethernet\t{word[j + 1]};\n");
                            sw.Write($"\tfixed-address\t\t{word[j]};\n}}\n");
                        }
                    sw.Close();
        }
    }
}