using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9___c
{
    class Program
    {
        public static List<Destination> liste = new List<Destination>();
        public static List<Chemin> listechemin = new List<Chemin>();
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\macpro\documents\visual studio 2015\Projects\Day9 - c\Day9 - c\day9.txt");
            

            foreach (var parser in lines)
            {
                string[] mots = parser.Split(' ');

                Destination encours = Recupdest(mots[0]);
                if (encours == null)
                {
                    encours = new Destination(mots[0]);
                    liste.Add(encours);
                }
                

                encours = Recupdest(mots[2]);
                if (encours == null)
                {
                    encours = new Destination(mots[2]);
                    liste.Add(encours);
                }


            }
            foreach (var parser in lines)
            {
                string[] mots = parser.Split(' ');
                Destination depart = Recupdest(mots[0]);
                Destination arrive = Recupdest(mots[2]);
                int poids = int.Parse(mots[4]);

                depart.AjouterDest(arrive, poids);
                arrive.AjouterDest(depart, poids);
            }

            foreach (var destin in liste)
            {
                
                Chemin ne = new Chemin();
                SearchRoute(destin, liste, ne);
            }

            int i = 0;
            foreach (var chem in listechemin)
            {
                
               Destination precdest = null;
               foreach(var dest in chem.chemin)
                {
                    if (!(precdest == null))
                    {
                        chem.poids += precdest.adjacent[dest];
                    }
                    precdest = dest;
                }
                if (chem.poids > i)
                    i = chem.poids;

            }

            Console.WriteLine(i);
            Console.ReadLine();

        }

        public static void SearchRoute(Destination point, List<Destination> passe, Chemin cheminencours)
        {      
            List<Destination> next = CopyList(passe);
            Chemin nextchemin = CopyListChemin(cheminencours);
            next.Remove(point);
            nextchemin.chemin.Add(point);
                
            if(next.Count == 0)
            {
                listechemin.Add(nextchemin);

            }
            else {
                foreach (var item in next)
                {
                    SearchRoute(item, next, nextchemin);
                }
            }

        }
        public static Destination Recupdest(string nom)
        {

            foreach (var item in liste)
            {
                if (item.nom == nom)
                {
                    return item;
                }
            }

            return null;
            
        }

        public static List<Destination> CopyList(List<Destination> old) {

            List<Destination> ne = new List<Destination>();

            foreach (var item in old)
            {
                ne.Add(item);
            }

            return ne;
        }

        public static Chemin CopyListChemin(Chemin old)
        {
            Chemin ne = new Chemin();
            foreach (var item in old.chemin)
            {
                ne.chemin.Add(item);
            }

            return ne;
        }
    }
}