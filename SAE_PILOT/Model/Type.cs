using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public class Type
    {
        private int numType;
        private int numCategorie; 
        private string libelleType;

        public Type () { }
        public Type(int numType, int numCategorie, string libelleType)
        {
            this.NumType = numType;
            this.NumCategorie = numCategorie;
            this.LibelleType = libelleType;
        }
        public Type(Categorie uneCategorie, string libelleType)
        {
            this.UneCategorie = uneCategorie;
            this.LibelleType = libelleType;
        }

        public int NumType
        {
            get
            {
                return this.numType;
            }

            set
            {
                this.numType = value;
            }
        }

        public int NumCategorie
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

        public string LibelleType
        {
            get
            {
                return this.libelleType;
            }

            set
            {
                this.libelleType = value;
            }
        }
    }
}
