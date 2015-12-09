using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_C
{
    class Program
    {
        public static Dictionary<string, string> openWith;
        public static Dictionary<string, ushort> finalassoc;
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Alexandre\Documents\AdventOfCode\Day7 C\day7.txt");

            openWith = new Dictionary<string, string>();
            finalassoc = new Dictionary<string, ushort>();

            foreach (var line in lines)
            {
                string[] mots = line.Split(' ');
                string key = mots[mots.Length - 1];

                if (mots.Length == 3 && mots[1] == "->")
                {
                    int m1 = 0;

                    try
                    {
                        m1 = int.Parse(mots[0]);
                        finalassoc.Add(key, (ushort)m1);
                        openWith.Remove(key);
                    }
                    catch
                    {
                        openWith.Add(key, line);
                    }         
                    
                }
                else
                {
                    openWith.Add(key, line);
                }
            }
            foreach (var line in lines)
            {
                string[] mots = line.Split(' ');
                string key = mots[mots.Length - 1];
                if (!finalassoc.ContainsKey(key))
                    resolve(key, line);
               
            }

            // Deuxième partie : 
            ushort deuxieme = finalassoc["a"];
            openWith = new Dictionary<string, string>();
            finalassoc = new Dictionary<string, ushort>();

            foreach (var line in lines)
            {
                string[] mots = line.Split(' ');
                string key = mots[mots.Length - 1];

                if (mots.Length == 3 && mots[1] == "->")
                {
                    int m1 = 0;

                    try
                    {
                        m1 = int.Parse(mots[0]);
                        finalassoc.Add(key, (ushort)m1);
                        openWith.Remove(key);
                    }
                    catch
                    {
                        openWith.Add(key, line);
                    }

                }
                else
                {
                    openWith.Add(key, line);
                }
            }
            finalassoc["b"] = deuxieme;
            foreach (var line in lines)
            {
                string[] mots = line.Split(' ');
                string key = mots[mots.Length - 1];
                if (!finalassoc.ContainsKey(key))
                    resolve(key, line);

            }

            Console.WriteLine(finalassoc["a"]);
            Console.ReadLine();

        }

        public static void resolve(string key,string line)
        {

            string[] mots = line.Split(' ');

            if (mots.Length == 3 && mots[1] == "->")
            {
                int m1 = 0;

                if (m1 == 0)
                {
                    if (!finalassoc.ContainsKey(mots[0]))
                    {
                        resolve(mots[0], openWith[mots[0]]);
                    }
                    m1 = finalassoc[mots[0]];
                }

                finalassoc.Add(key, (ushort)m1);
                openWith.Remove(key);

            }

            else if (mots[0] == "NOT")
            {

                int m1 = 0;
                int.TryParse(mots[0], out m1);

                if(m1 == 0) {
                    if (!finalassoc.ContainsKey(mots[1]))
                    {
                        resolve(mots[1], openWith[mots[1]]);
                    }
                    m1 = finalassoc[mots[1]];
                }
                finalassoc.Add(key, (ushort)~(m1));
                openWith.Remove(key);
            }


            else if (mots[1] == "OR")
            {
                int m1 = 0;
                int m2 = 0;
                int.TryParse(mots[0], out m1);
                int.TryParse(mots[2], out m2);

                if (m1 == 0)
                {
                    if (!finalassoc.ContainsKey(mots[0]))
                    {
                        resolve(mots[0], openWith[mots[0]]);
                    }
                    m1 = finalassoc[mots[0]];
                }

                if (m2 == 0)
                {
                    if (!finalassoc.ContainsKey(mots[2]))
                    {
                        resolve(mots[2], openWith[mots[2]]);
                    }
                    m2 = finalassoc[mots[2]];
                }


                finalassoc.Add(key, (ushort)(m1 | m2));
                openWith.Remove(key);


            }
            else if (mots[1] == "AND")
            {
                int m1 = 0;
                int m2 = 0;
                int.TryParse(mots[0], out m1);
                int.TryParse(mots[2], out m2);

                if (m1 == 0)
                {
                    if (!finalassoc.ContainsKey(mots[0]))
                    {
                        resolve(mots[0], openWith[mots[0]]);
                    }
                    m1 = finalassoc[mots[0]];
                }

                if (m2 == 0)
                {
                    if (!finalassoc.ContainsKey(mots[2]))
                    {
                        resolve(mots[2], openWith[mots[2]]);
                    }
                    m2 = finalassoc[mots[2]];
                }

                finalassoc.Add(key, (ushort)(m1 & m2));
                openWith.Remove(key);


            }
            else if (mots[1] == "RSHIFT")
            {
                int m1 = 0;
                int m2 = 0;
                int.TryParse(mots[2], out m2);               

                if (!finalassoc.ContainsKey(mots[0]))
                {
                    resolve(mots[0], openWith[mots[0]]);
                }
                m1 = finalassoc[mots[0]];

                finalassoc.Add(key, (ushort)(m1 >> m2));
                openWith.Remove(key);

            }

            else if (mots[1] == "LSHIFT")
            {
                int m1 = 0;
                int m2 = 0;
                int.TryParse(mots[2], out m2);

                if (!finalassoc.ContainsKey(mots[0]))
                {
                    resolve(mots[0], openWith[mots[0]]);
                }
                m1 = finalassoc[mots[0]];

                finalassoc.Add(key, (ushort)(m1 << m2));
                openWith.Remove(key);

            }
            else
            {
                throw new Exception();
            }



        }
    }
}
