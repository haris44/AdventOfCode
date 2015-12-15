using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12___C
{
    class objet
    {
        string illegal = "red";
        bool moins = false;
        string numencours;
        double total;
        public objet inobjet == null; 

    public bool verifyillegal(char now, char prec, char precprec)
    {
            if ("" + precprec + prec + now == illegal)
                return false;
            else
                return true;
    }

    public void checkcarac(char c)
    {

        if (Char.IsNumber(c))
        {
            numencours += c;
        }
        else if (c == '-')
        {
            moins = true;
        }
        else
        {
            if (numencours != "")
            {
                if (moins)
                    total -= (double.Parse(numencours));
                else
                {
                    total += (double.Parse(numencours));
                }
                numencours = "";
                moins = false;
            }
            else
            {
                numencours = "";
                moins = false;
            }

        }
      }
    }


}
