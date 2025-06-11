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
    public class Produit : ICrud<Produit>
    {
        private int numProduit;
        private int numTypePointe; 
        private int numType; 
        private string codeProduit;
        private string nomProduit;
        private decimal prixVente;
        private int qteStock;
        private bool disponible;

        public Produit () { }
        public Produit(int numProduit, int numTypePointe, int numType, string codeProduit, string nomProduit, 
            decimal prixVente, int qteStock)
        {
            this.NumProduit = numProduit;
            this.NumTypePointe = numTypePointe;
            this.NumType = numType;
            this.CodeProduit = codeProduit;
            this.NomProduit = nomProduit;
            this.PrixVente = prixVente;
            this.QteStock = qteStock;
            this.Disponible = true;
        }

        public Produit(int numTypePointe, int numType, string codeProduit, string nomProduit,
            decimal prixVente, int qteStock)
        {
            this.NumTypePointe = numTypePointe;
            this.NumType = numType;
            this.CodeProduit = codeProduit;
            this.NomProduit = nomProduit;
            this.PrixVente = prixVente;
            this.QteStock = qteStock;
            this.Disponible = true;
        }
        public Produit(int numProduit, int numTypePointe, int numType, string codeProduit, string nomProduit,
            decimal prixVente, int qteStock, bool disponible)
        {
            this.NumProduit = numProduit;
            this.NumTypePointe = numTypePointe;
            this.NumType = numType;
            this.CodeProduit = codeProduit;
            this.NomProduit = nomProduit;
            this.PrixVente = prixVente;
            this.QteStock = qteStock;
            this.Disponible = disponible;
        }
        public Produit(int numTypePointe, int numType, string codeProduit, string nomProduit,
            decimal prixVente, int qteStock, bool disponible)
        {
            this.NumTypePointe = numTypePointe;
            this.NumType = numType;
            this.CodeProduit = codeProduit;
            this.NomProduit = nomProduit;
            this.PrixVente = prixVente;
            this.QteStock = qteStock;
            this.Disponible = disponible;
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

        public decimal PrixVente
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
            using (var cmdUpdate = new NpgsqlCommand("UPDATE produit SET numtypepointe=@numtypepointe, numtype=@numtype, codeproduit=@codeproduit, " +
               "nomproduit=@nomproduit, prixvente=@prixvente, quantitestock=@qtestock, disponible=@disponible WHERE numproduit=@numproduit"))
            {
                cmdUpdate.Parameters.AddWithValue("numproduit", this.NomProduit);
                cmdUpdate.Parameters.AddWithValue("numtypepointe", this.NumTypePointe);
                cmdUpdate.Parameters.AddWithValue("numtype", this.NumType);
                cmdUpdate.Parameters.AddWithValue("codeproduit", this.CodeProduit);
                cmdUpdate.Parameters.AddWithValue("nomproduit", this.NomProduit);
                cmdUpdate.Parameters.AddWithValue("prixvente", this.PrixVente);
                cmdUpdate.Parameters.AddWithValue("qtestock", this.QteStock);
                cmdUpdate.Parameters.AddWithValue("disponible", this.Disponible);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from produit where numproduit = @numproduit;"))
            {
                cmdUpdate.Parameters.AddWithValue("numproduit", this.NumProduit);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public List<Produit> FindAll()
        {
            List<Produit> lesProduits = new List<Produit>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from produit;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesProduits.Add(new Produit((Int32)dr["numproduit"],
                        (Int32)dr["numtypepointe"], 
                        (Int32)dr["numtype"], 
                        (string)dr["codeproduit"],
                        (string)dr["nomproduit"],
                        (decimal)dr["prixvente"],
                        (int)dr["quantitestock"],
                        (Boolean)dr["disponible"]
                    ));
            }
            return lesProduits;
        }

        public List<Produit> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
