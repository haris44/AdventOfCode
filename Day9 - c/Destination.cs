using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9___c
{
    class Destination
    {
        public string nom;
        public int route;
        public Dictionary<Destination, int> adjacent = new Dictionary<Destination, int>();


        public Destination(string nom)
        {
            this.nom = nom;
        }

        public void AjouterDest(Destination dest, int poids)
        {

            if (!adjacent.ContainsKey(dest))
            {
                adjacent.Add(dest, poids);
                route++;
            }

        }
    }
}
