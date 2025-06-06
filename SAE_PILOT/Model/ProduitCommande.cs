using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public class ProduitCommande
    {
        private Commande uneCommande;
        private Produit unProduit;
        private int qteCommande;
        private double prix;

        public ProduitCommande(Commande uneCommande, Produit unProduit, int qteCommande, double prix)
        {
            this.UneCommande = uneCommande;
            this.UnProduit = unProduit;
            this.QteCommande = qteCommande;
            this.Prix = prix;
        }
        public ProduitCommande(Produit unProduit, int qteCommande, double prix)
        {
            this.UnProduit = unProduit;
            this.QteCommande = qteCommande;
            this.Prix = prix;
        }

        public Commande UneCommande
        {
            get
            {
                return this.uneCommande;
            }

            set
            {
                this.uneCommande = value;
            }
        }

        public Produit UnProduit
        {
            get
            {
                return this.unProduit;
            }

            set
            {
                this.unProduit = value;
            }
        }

        public int QteCommande
        {
            get
            {
                return this.qteCommande;
            }

            set
            {
                this.qteCommande = value;
            }
        }

        public double Prix
        {
            get
            {
                return UnProduit.PrixVente * QteCommande;
            }
        }
    }
}
