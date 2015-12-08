using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_C
{
    class Program
    {
        public static Dictionary<string, ushort> openWith;
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"c:\users\macpro\documents\visual studio 2015\Projects\Day7 C\Day7 C\day7.txt");

            openWith = new Dictionary<string, ushort>();

            foreach (var line in lines)
            {
                string[] mots = line.Split(' ');
                ushort int16NotB = 0;

                if (mots[0] == "NOT")
                {
                    Manipulate(mots[1]);
                    Manipulate(mots[3]);
                    ushort b = (byte)openWith[mots[1]];

                    if (mots[3] == "a" || mots[3] == "lx" || mots[3] == "lw")
                    {
                        bool lol;
                    }

                    int16NotB = (ushort)~b;

                    openWith[mots[3]] = int16NotB;
                }
                else if (mots.Length == 3)
                {
                    try {
                        Manipulate(mots[2]);
                        openWith[mots[2]] = ushort.Parse(mots[0]);
                    }
                    catch
                    {
                        Manipulate(mots[2]);

                        if (mots[2] == "a" || mots[2] == "lx" || mots[2] == "lw")
                        {
                            bool lol;
                        }

                        Manipulate(mots[0]);
                        openWith[mots[2]] = openWith[mots[0]];
                    }
                }
                else if (mots[1] == "OR")
                {
                    byte m1 = 0;
                    byte m2 = 0;                   
                    byte.TryParse(mots[0], out m1);
                    byte.TryParse(mots[2], out m2);

                    if (m1 != 0) {
                        Manipulate(mots[2]);
                        m2 = (byte)openWith[mots[2]];                        
                    }

                    else if(m2 != 0) {
                        Manipulate(mots[0]);
                        m1 = (byte)openWith[mots[0]];
                    }
                    else if(m1 == 0 && m2 == 0)
                    {
                        Manipulate(mots[2]);
                        m2 = (byte)openWith[mots[2]];
                        Manipulate(mots[0]);
                        m1 = (byte)openWith[mots[0]];
                    }


                    if (mots[0] == "a" || mots[4] == "lx" || mots[4] == "lw")
                    {
                        bool lol;
                    }

                    Manipulate(mots[4]);
                    openWith[mots[4]] = (ushort)(m1 | m2);
                  

                }
                else if (mots[1] == "AND")
                {
                    byte m1 = 0;
                    byte m2 = 0;
                    byte.TryParse(mots[0], out m1);
                    byte.TryParse(mots[2], out m2);

                    if (m1 != 0)
                    {
                        Manipulate(mots[2]);
                        m2 = (byte)openWith[mots[2]];
                    }

                    else if (m2 != 0)
                    {
                        Manipulate(mots[0]);
                        m1 = (byte)openWith[mots[0]];
                    }
                    else if (m1 == 0 && m2 == 0)
                    {
                        Manipulate(mots[2]);
                        m2 = (byte)openWith[mots[2]];
                        Manipulate(mots[0]);
                        m1 = (byte)openWith[mots[0]];
                    }

                    if (mots[0] == "a" || mots[4] == "lv" || mots[4] == "lw")
                    {
                        bool lol;
                    }

                    Manipulate(mots[4]);
                    openWith[mots[4]] = (ushort)(m1 & m2);


                }
                else if (mots[1] == "RSHIFT")
                {
                    byte m2 = 0;
                    byte.TryParse(mots[2], out m2);

                    byte m1 = 0;
                    Manipulate(mots[0]);
                    m1 = (byte)openWith[mots[0]];

                    Manipulate(mots[4]);
                    openWith[mots[4]] = (ushort)(m1 >> m2);


                }

                else if (mots[1] == "LSHIFT")
                {
                    byte m2 = 0;
                    byte.TryParse(mots[2], out m2);

                    byte m1 = 0;
                    Manipulate(mots[0]);
                    m1 = (byte)openWith[mots[0]];


                    Manipulate(mots[4]);
                    openWith[mots[4]] = (ushort)(m1 << m2);

                    if (mots[0] == "a" || mots[4] == "lv")
                    {
                        bool lol;
                    }
                }
                else
                {
                    throw new Exception();
                }

        


            }

            Console.WriteLine(openWith["a"].ToString());
            Console.ReadLine();

        }

        public static void Manipulate(string cle)
        {

            if (!openWith.Keys.Contains(cle))
            {
                openWith.Add(cle, 0);
            }
            

        }
    }
}
