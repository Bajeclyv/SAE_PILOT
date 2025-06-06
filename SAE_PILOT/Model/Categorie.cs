using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public enum CategorieProduit { Ecole, Bureau, Loisir, HauteEcriture };
    public  class Categorie
    {
        private int numCategorie;
        private CategorieProduit libelleCategorie;

        public Categorie() { }
        public Categorie(int idCategorie, CategorieProduit catProduit)
        {
            this.IdCategorie = idCategorie;
            this.CatProduit = catProduit;
        }
        public Categorie(CategorieProduit catProduit)
        {
            this.CatProduit = catProduit;
        }

        public int IdCategorie
        {
            get
            {
                return this.numCategorie;
            }

            set
            {
                this.numCategorie = value;
            }
        }

        public CategorieProduit CatProduit
        {
            get
            {
                return this.libelleCategorie;
            }

            set
            {
                this.libelleCategorie = value;
            }
        }
    }
}
