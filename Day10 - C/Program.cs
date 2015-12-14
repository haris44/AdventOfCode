using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10___C
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = "1113122113";

            for(int i = 0; i < 50; i++)
            {
                char prec = ' ';
                int j = 0;
                StringBuilder newinput = new StringBuilder();

                foreach (var item in input)
                {
                    if (item == ' ' ) { }
                    else if (prec == ' ')
                    {
                        j++;
                    }
                    else if(item != prec)
                    {

                        newinput.Append(j);
                        newinput.Append(prec);
                        j = 1;
                    }
                    else
                    {
                        j++;
                    }
                    prec = item;
                }

                StringBuilder myString = new StringBuilder();
                myString.Append(newinput);
                myString.Append(j);
                myString.Append(prec);
                input = myString.ToString();

            }

            Console.WriteLine(input.Length);
            Console.ReadLine();
        }
    }
}
