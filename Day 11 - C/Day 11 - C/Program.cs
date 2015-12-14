using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11___C
{
    class Program
    {
        public static List<string> lettre = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public static string input = "cqjxxyzz";
        static void Main(string[] args)
        {
            bool suiv = false;
            bool not = false;
            char firstdouble = ' ';
            char secondedouble = ' ';
            string newpass = input;

            while (!(suiv && not && firstdouble != ' ' && secondedouble != ' '))
            {
                newpass = nextPass(newpass);
                suiv = false;
                not = true;
                firstdouble = ' ';
                secondedouble = ' ';
                char prec = ' ';
                char precprec = ' ';

                foreach (var item in newpass)
                {
                    if ((prec != ' ' && precprec != ' ') && (lettre.IndexOf(item.ToString()) == lettre.IndexOf(prec.ToString()) + 1 && lettre.IndexOf(prec.ToString()) == lettre.IndexOf(precprec.ToString()) + 1 && lettre.IndexOf(item.ToString()) >= 2))
                    {
                        suiv = true;
                    }

                    if (item == 'i' || item == 'l' || item == 'o')
                        not = false;

                    if (prec == item)
                    {
                        if (firstdouble == ' ')
                        {
                            firstdouble = item;
                        }
                        else if (item == firstdouble)
                        {

                        }
                        else if (secondedouble == ' ')
                        {
                            secondedouble = item;
                        }

                    }
                    precprec = prec;
                    prec = item;

                }
            }

           Console.WriteLine(newpass);
           Console.ReadLine();
        }
               
       


        public static string nextPass(string letter) {

            var l = ' ';
            int j = 0;
            // j -> Index de la lettre a changer en partant de la fin 
            string finalinput = letter;

            bool ze = true;
            while (ze)
            {
                l = letter[letter.Length - j - 1];
                if (l == 'z') {
                    j++;
                }
                else
                    ze = false;

            }

            for (int i = 0; i <= j; i++)
            {
                finalinput = letter.Remove(letter.Length - i - 1);
            }

            
            finalinput += nextLetter(letter[letter.Length - j - 1].ToString());

            for (int i = 0; i < j; i++)
            {
                finalinput += "a";
            }

            return finalinput;
        }
        public static string nextLetter(string letter)
        {
            int i = lettre.IndexOf(letter);

            if (i == 25)
            {
                i = 0;
            }
            else
            {
                i++;
            }
            return lettre[i];
        }
    }
}
