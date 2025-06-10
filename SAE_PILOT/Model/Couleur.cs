using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public enum Coloris { Bleu, Rouge, Vert, Noir};
    public class Couleur
    {
        private int numCouleur;
        private Coloris libelleCouleur;

        public Couleur () { }
        public Couleur(int numCouleur, Coloris libelleCouleur)
        {
            this.NumCouleur = numCouleur;
            this.LibelleCouleur = libelleCouleur;
        }
        public Couleur(Coloris libelleCouleur)
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

        public Coloris LibelleCouleur
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
