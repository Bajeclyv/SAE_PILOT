using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    //public enum Coloris { Bleu, Rouge, Vert, Noir};
    public class Couleur
    {
        private int numCouleur;
        private string libelleCouleur;

        public Couleur () { }
        public Couleur(int numCouleur, string libelleCouleur)
        {
            this.NumCouleur = numCouleur;
            this.LibelleCouleur = libelleCouleur;
        }
        public Couleur(string libelleCouleur)
        {
            this.LibelleCouleur = libelleCouleur;
        }

        public int NumCouleur
        {
            get
            {
                return this.numCouleur;
            }

            set
            {
                this.numCouleur = value;
            }
        }

        public string LibelleCouleur
        {
            get
            {
                return this.libelleCouleur;
            }

            set
            {
                this.libelleCouleur = value;
            }
        }

    }
}
