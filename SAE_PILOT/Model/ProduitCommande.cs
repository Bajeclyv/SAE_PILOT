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
        private int numCommande;
        private int numProduit;
        private int qteCommande;
        private double prix;

        // Peut-être faire une liste observable des produits pour aller récupérer les infos ?
        
        public ProduitCommande() { }
        public ProduitCommande(int numCommande, int numProduit, int qteCommande, double prix)
        {
            this.NumCommande = numCommande;
            this.NumProduit = numProduit;
            this.QteCommande = qteCommande;
        }
        public ProduitCommande(int qteCommande, double prix)
        {
            this.QteCommande = qteCommande;
        }

        public int NumCommande
        {
            get
            {
                return this.numCommande;
            }

            set
            {
                this.numCommande = value;
            }
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

        public decimal Prix
        {
            get
            {
                decimal prix = 0;

                using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT prixvente FROM produit where numproduit=@numproduit;"))
                {
                    cmdSelect.Parameters.AddWithValue("numproduit", this.NumProduit);
                    DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                    prix = (decimal)dt.Rows[0]["prixvente"] * this.QteCommande;
                }
                return Math.Round(prix, 2);
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
            using (var cmdUpdate = new NpgsqlCommand("delete from produitcommande where numproduit = @numproduit;"))
            {
                cmdUpdate.Parameters.AddWithValue("numproduit", this.NumProduit);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public List<ProduitCommande> FindAll()
        {
            List<ProduitCommande> lesPCommande = new List<ProduitCommande>();

            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM produitcommande;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesPCommande.Add(new ProduitCommande(
                        (Int32)dr["numcommande"],
                        (Int32)dr["numproduit"],
                        (Int32)dr["quantitecommande"],
                        (double)dr["prix"])
                    );
            }
            return lesPCommande;
        }

        public List<ProduitCommande> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
