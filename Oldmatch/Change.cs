using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Match
{
    public class Change
    {
        //3
        //AbcDefs
        //long_and
        //longAnd
        static void Main(string[] args)
        {

            StreamReader reader = File.OpenText(@"F:\ceshi\change1.in");
            StreamWriter writer = File.CreateText(@"F:\ceshi\change1.out");
            int n = int.Parse(reader.ReadLine());

            string[] words = new string[n];

            for (int i = 0; i < n; i++)
            {
                string word = reader.ReadLine();
                char head = word.ToCharArray()[0];

                char[] desChars;

                string RegexLower = "^[a-z]+$";
                string RegexLowerhua = "^[a-z_]+$";
                string RegexUpper = "^[A-Z]+$";

                //找不到'_' 是A
                if (word.IndexOf('_') == -1)
                {
                    //longAnd
                    if (Regex.IsMatch(head.ToString(), RegexLower))
                    {
                        desChars = new char[wordChars.Length + wordChars.Length];
                        int k = 0;
                        for (int j = 0; j < wordChars.Length; j++)
                        {
                            if (Regex.IsMatch(wordChars[j].ToString(), RegexUpper))
                            {
                                desChars[k] = '_';
                                desChars[k + 1] = Convert.ToChar(wordChars[j].ToString().ToLower());
                                k++;
                            }
                            else
                            {
                                desChars[k] = wordChars[j];
                            }
                            k++;

                        }
                        words[i] = new string(desChars);
                    }
                    else
                    {
                        words[i] = "Error";
                    }
                }
                else //找到是B
                {
                    //  //long_and
                    if (Regex.IsMatch(word, RegexLowerhua))
                    {
                        desChars = new char[wordChars.Length];
                        int k = 0;
                        bool isTan = false;
                        for (int j = 0; j < wordChars.Length; j++)
                        {
                            if (wordChars[j] == '_')
                            {
                                //desChars[k] = wordChars[j];
                                isTan = true;
                                k--;
                            }
                            else
                            {
                                if (isTan)
                                {
                                    desChars[k] = Convert.ToChar(wordChars[j].ToString().ToUpper());
                                    isTan = false;
                                }
                                else
                                {
                                    desChars[k] = wordChars[j];
                                }

                            }
                            k++;
                        }
                        words[i] = new string(desChars);
                    }
                    else
                    {
                        words[i] = "Error";
                    }
                }
            }

            foreach (string word in words)
            {
                string result = word.Replace("\0", "");
                writer.WriteLine(result);
            }

            reader.Close();
            writer.Close();
        }


        static void Main(string[] args)
        {

            StreamReader reader = File.OpenText("change.in");
            StreamWriter writer = File.CreateText("change.out");
            int n = int.Parse(reader.ReadLine());
            int[] type = new int[n];
            string[] array = new string[n];


            for (int i = 0; i < n; i++)
            {
                string line = reader.ReadLine();

                array[i] = line;
                //0 error  1 A  2B 
                type[i] = IsError(line);

            }

            for (int i = 0; i < n; i++)
            {
                if (type[i] == 1)
                {
                    string t1 = ChangeToB(array[i]);

                    writer.WriteLine(t1);
                }
                else if (type[i] == 2)
                {
                    string t2 = ChangeToA(array[i]);
                    writer.WriteLine(t2);
                }
                else
                {
                    writer.WriteLine("Error");
                }
            }

            reader.Close();
            writer.Close();
        }

        private static string ChangeToB(string p)
        {
            //longAnd  long_and  A 
            while (IsOK(p))
            {
                for (int i = 0; i < p.Count(); i++)
                {
                    if (p[i] >= 65 && p[i] <= 91)
                    {
                        p = p.Substring(0, i) + "_" + p.Substring(i, 1).ToLower() + p.Substring(i + 1);
                        break;
                    }
                }
            }

            return p;

        }

        private static bool IsOK(string temp)
        {

            for (int i = 0; i < temp.Count(); i++)
            {
                if (temp[i] >= 65 && temp[i] <= 91)
                {
                    return true;
                }
            }
            return false;
        }



        private static string ChangeToA(string p)
        {
            while (p.IndexOf("_") != -1)
            {
                int v1 = p.IndexOf("_");
                //long
                p = p.Substring(0, v1) + p.Substring(v1 + 1, 1).ToUpper() + p.Substring(v1 + 2);
            }
            return p;
        }

        private static int IsError(string line)
        {
            int vizhi = Asc(line.First().ToString());
            if (vizhi >= 97 && vizhi <= 123)
            {
                if (line.IndexOf("_") == -1)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            return 0;

        }


        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("Character is not valid.");
            }

        }


    }
}
