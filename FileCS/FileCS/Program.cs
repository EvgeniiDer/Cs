using System;
using System.ComponentModel;
using System.IO;
using System.Net;
namespace FileCS{
    class MyClass{
        public static int count = 0;
        static void Main(string [] argv)
        {
            const string OUTFILE = "201 ready.txt";
            const string INFILE = "201 RAW.txt";
            List<int> distance = new List<int>();
            
            
            string text;
            FileStream fs = new FileStream(INFILE, FileMode.Open);// Дает возможность контролировать каретку в тестковом файле
            StreamReader sr = new StreamReader(fs);
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
                                    if(word.Count % 2 == 0 && word.Count >= 2)
                                    {
                                        for(int j = word.Count - 1; j < word.Count; j++)
                                            {
                                                distance.Add(Distance(text, word[j - 1], word[j]));
                                                
                                            }                          
                                    }
                                }
                        }
                    }
                    fs.Seek(0, SeekOrigin.Begin);//Возврат каретки на начало текста
                    List<int> emptyLines = new List<int>();
                    int emptyCount = 0;
                    while((text = sr.ReadLine()) != null)//Поиск пустой строки
                    {
                        emptyCount++;
                         if(text == "")
                         {
                           emptyLines.Add(emptyCount);
                         }
                         
                    }
                    StreamWriter sw = new StreamWriter(OUTFILE);
                    for(int j = 0, i = 1; j < word.Count - 1; i++, j += 2) // Закргузка измененого текста в файл
                        {   if(emptyLines.Contains(i))
                            {
                                sw.WriteLine();
                                j-=2;
                            }
                            else{
                                sw.WriteLine($"{word[j + 1]}{new string(' ', distance[count++])} {word[j]}");
                            }
                        }
                    sw.Close();
        }
        static public int Distance(string  _line, string _words1, string _words2)// Считывает колличество пустых символов между словами
        {
            int index1 = _line.IndexOf(_words1);
            int index2 = _line.IndexOf(_words2);
            
            if(index1 != -1 && index2 != -1)
            {
                int distance = index2 -(index1 +_words1.Length);
                return distance;
            }else{
               return -1; 
            }
            
        }
    }
}