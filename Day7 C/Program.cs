using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_C
{
    class Program
    {
        public static Dictionary<string, int> openWith;
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Alexandre\Documents\AdventOfCode\Day7 C\day7.txt");

            openWith = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                string[] mots = line.Split(' ');

                if (mots[0] == "NOT")
                {                  
                    ManipulateFin(mots[3]);
                    openWith[mots[3]] = (ushort)Manipulate(mots[1]);
                }

                else if (mots.Length == 3 && mots[1] == "->")
                {
                    int m1 = 0;
                    int.TryParse(mots[0], out m1);

                    if(m1 == 0)
                    {                       
                        m1 = Manipulate(mots[0]);
                    }

                    ManipulateFin(mots[2]);
                    openWith[mots[2]] = (ushort)m1;
                    
                }
                else if (mots[1] == "OR")
                {
                    int m1 = 0;
                    int m2 = 0;                   
                    int.TryParse(mots[0], out m1);
                    int.TryParse(mots[2], out m2);

                    if (m1 != 0) {
                        
                        m2 = Manipulate(mots[2]);
                    }

                    else if(m2 != 0) {
                        
                        m1 = Manipulate(mots[0]);
                    }
                    else if(m1 == 0 && m2 == 0)
                    {
                        m2 = Manipulate(mots[2]);
                        m1 = Manipulate(mots[0]);
                    }
                    else
                    {
                        throw new Exception();
                    }

                    ManipulateFin(mots[4]);
                    openWith[mots[4]] = (ushort)(m1 | m2);
                  

                }
                else if (mots[1] == "AND")
                {
                    int m1 = 0;
                    int m2 = 0;
                    int.TryParse(mots[0], out m1);
                    int.TryParse(mots[2], out m2);

                    if (m1 != 0)
                    {
                        
                        m2 = Manipulate(mots[2]);
                    }

                    else if (m2 != 0)
                    {
                        
                        m1 = Manipulate(mots[0]);
                    }
                    else if (m1 == 0 && m2 == 0)
                    {
                        m2 = Manipulate(mots[2]);
                        m1 = Manipulate(mots[0]);
                    }
                    else
                    {
                        throw new Exception();
                    }


                    ManipulateFin(mots[4]);
                    openWith[mots[4]] = (ushort)(m1 & m2);


                }
                else if (mots[1] == "RSHIFT")
                {
                    int m2 = 0;
                    int.TryParse(mots[2], out m2);

                    int m1 = 0;
                    
                    m1 = Manipulate(mots[0]);

                    ManipulateFin(mots[4]);
                    openWith[mots[4]] = (ushort)(m1 >> m2);


                }

                else if (mots[1] == "LSHIFT")
                {
                    int m2 = 0;
                    int.TryParse(mots[2], out m2);

                    int m1 = 0;
 
                    m1 = Manipulate(mots[0]);

                    ManipulateFin(mots[4]);
                    openWith[mots[4]] = (ushort)(m1 << m2);

                }
                else
                {
                    throw new Exception();
                } 


            }

            Console.WriteLine(openWith["a"]);
            Console.ReadLine();

        }

        public static void ManipulateFin(string cle)
        {

            if (!openWith.Keys.Contains(cle))
            {
                openWith.Add(cle, 0);
            }
            

        }
        public static int Manipulate(string cle)
        {

            if (!openWith.Keys.Contains(cle))
            {
                return 0;
            }
            else
                return openWith[cle];


        }
    }
}
