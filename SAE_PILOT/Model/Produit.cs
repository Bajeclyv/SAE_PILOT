using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public class Produit
    {
        private int numProduit;
        private TypePointe leTypePointe;
        private Type leType;
        private string codeProduit;
        private string nomProduit;
        private double prixVente;
        private int qteStock;
        private bool disponible;

        public Produit () { }
        public Produit(int numProduit, TypePointe leTypePointe, Type leType, string codeProduit, string nomProduit, 
            double prixVente, int qteStock)
        {
            this.NumProduit = numProduit;
            this.LeTypePointe = leTypePointe;
            this.LeType = leType;
            this.CodeProduit = codeProduit;
            this.NomProduit = nomProduit;
            this.PrixVente = prixVente;
            this.QteStock = qteStock;
            this.Disponible = true;
        }

        public Produit(TypePointe leTypePointe, Type leType, string codeProduit, string nomProduit,
            double prixVente, int qteStock)
        {
            this.LeTypePointe = leTypePointe;
            this.LeType = leType;
            this.CodeProduit = codeProduit;
            this.NomProduit = nomProduit;
            this.PrixVente = prixVente;
            this.QteStock = qteStock;
            this.Disponible = true;
        }

        public int NumProduit
        {
            get
            {
                return this.numProduit;
            }

            set
            {
                this.numProduit = value;
            }
        }

        public TypePointe LeTypePointe
        {
            get
            {
                return this.leTypePointe;
            }

            set
            {
                this.leTypePointe = value;
            }
        }

        public Type LeType
        {
            get
            {
                return this.leType;
            }

            set
            {
                this.leType = value;
            }
        }

        public string CodeProduit
        {
            get
            {
                return this.codeProduit;
            }

            set
            {
                this.codeProduit = value;
            }
        }

        public string NomProduit
        {
            get
            {
                return this.nomProduit;
            }

            set
            {
                this.nomProduit = value;
            }
        }

        public double PrixVente
        {
            get
            {
                return this.prixVente;
            }

            set
            {
                this.prixVente = value;
            }
        }

        public int QteStock
        {
            get
            {
                return this.qteStock;
            }

            set
            {
                this.qteStock = value;
            }
        }

        public bool Disponible
        {
            get
            {
                return this.disponible;
            }

            set
            {
                this.disponible = value;
            }
        }
    }
}
