using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD3_BindingBDPension.Model;

namespace SAE_PILOT.Model
{
    public class ProduitCommande : ICrud<ProduitCommande>
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
        }
        public ProduitCommande(int qteCommande, double prix)
        {
            this.QteCommande = qteCommande;
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

        public int Create()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public List<ProduitCommande> FindAll()
        {
            //List<ProduitCommande> lesProduitsCommande = new List<ProduitCommande>();
            throw new NotImplementedException();
        }

        public List<ProduitCommande> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
