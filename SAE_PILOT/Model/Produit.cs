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
            using (var cmdUpdate = new NpgsqlCommand("UPDATE produit SET numtypepointe=@letypepointe, numtype=@letype, codeproduit=@codeproduit, " +
               "nomproduit=@nomproduit, prixvente=@prixvente, quantitestock=@qtestock, disponible=@disponible WHERE numproduit=@numproduit"))
            {
                cmdUpdate.Parameters.AddWithValue("numproduit", this.NomProduit);
                cmdUpdate.Parameters.AddWithValue("letypepointe", this.leTypePointe.NumTypePointe);
                cmdUpdate.Parameters.AddWithValue("letype", this.LeType.NumType);
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
            using (var cmdUpdate = new NpgsqlCommand("delete from produit  where numproduit = @numproduit;"))
            {
                cmdUpdate.Parameters.AddWithValue("numproduit", this.NomProduit);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public List<Produit> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Produit> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
