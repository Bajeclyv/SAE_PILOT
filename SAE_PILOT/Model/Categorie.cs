using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    //public enum CategorieProduit { Ecole, Bureau, Loisir, HauteEcriture };
    public  class Categorie
    {
        private int numCategorie;
        private string libelleCategorie;

        public Categorie() { }
        public Categorie(int idCategorie, string catProduit)
        {
            this.IdCategorie = idCategorie;
            this.CatProduit = catProduit;
        }
        public Categorie(string catProduit)
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

        public string CatProduit
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
