using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public enum EpaisseurPointe { Grosse, Moyenne, Fine};
    public class TypePointe
    {
        private int numTypePointe;
        private EpaisseurPointe libelleTypePointe;

        public TypePointe () { }
        public TypePointe(int numTypePointe, EpaisseurPointe libelleTypePointe)
        {
            this.NumTypePointe = numTypePointe;
            this.LibelleTypePointe = libelleTypePointe;
        }
        public TypePointe(EpaisseurPointe libelleTypePointe)
        {
            this.LibelleTypePointe = libelleTypePointe;
        }

        public int NumTypePointe
        {
            get
            {
                return this.numTypePointe;
            }

            set
            {
                this.numTypePointe = value;
            }
        }

        public EpaisseurPointe LibelleTypePointe
        {
            get
            {
                return this.libelleTypePointe;
            }

            set
            {
                this.libelleTypePointe = value;
            }
        }
    }
}
