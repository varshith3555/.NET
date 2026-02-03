    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    namespace MyConsoleApp.Day17_M1Prac
    {
        public class StringQues1
        {

            public static void Main()
            {
                string str = Console.ReadLine();

                if (!IsValid(str))
                {
                    Console.WriteLine("Invalid Sentence");
                }
                else
                {
                    string result = WordWand(str);
                    System.Console.WriteLine(result);
                }
            }
            public static bool IsValid(string str)
            {
                foreach(char c in str)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        return false;
                    }

                }
                return true;
            }  
            public static string WordWand(string str)
            {
                string res = "";
                string[] words = str.Split(" ");
            
                    if(words.Length % 2 == 0)
                    {
                        int i=0;
                        int j=words.Length - 1;
                        while (i < j)
                        {
                            var temp = words[i];
                            words[i] = words[j];
                            words[j] = temp;
                            i++;
                            j--;
                        }
                    
                    for(int m=0;m<words.Length;m++)
                    {
                        res += words[m] + " ";
                    }
                }
                else
                {
                    foreach(string c in words)
                    {
                        var a = c.Reverse().ToArray();
                        res += new string(a) + " ";
                    }
                }
                return res;
            }
        }
    }
