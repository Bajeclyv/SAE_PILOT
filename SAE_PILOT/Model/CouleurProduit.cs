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
    public class CouleurProduit : ICrud<CouleurProduit>
    {
        private int numCouleur;
        private int numProduit;

        public CouleurProduit() { }
        public CouleurProduit(int numcouleur, int numproduit)
        {
            this.NumCouleur = numcouleur;
            this.NumProduit = numproduit;
        }

        public int NumCouleur
        {
            get
            {
                return this.numCouleur;
            }

            set
            {
                this.numCouleur = value;
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

        public int Create()
        {
            int nb = 0;

            using (var cmdInsert = new NpgsqlCommand("INSERT INTO couleurproduit (numcouleur,numproduit) values (@numcouleur,@numproduit) RETURNING numproduit"))
            {
                cmdInsert.Parameters.AddWithValue("numcouleur", this.NumCouleur);
                cmdInsert.Parameters.AddWithValue("numproduit", this.NumProduit);
                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            nb += 1;
            return nb;
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from couleurproduit where numproduit = @numproduit;"))
            {
                cmdUpdate.Parameters.AddWithValue("numproduit", this.NumProduit);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public List<CouleurProduit> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<CouleurProduit> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("SELECT * FROM couleurproduit WHERE numproduit = @numproduit and numcouleur=@numcouleur"))
            {
                cmdSelect.Parameters.AddWithValue("numproduit", this.NumProduit);
                cmdSelect.Parameters.AddWithValue("numproduit", this.NumCouleur);
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.NumCouleur = (Int32)dt.Rows[0]["nmcouleur"];
                this.NumProduit = (Int32)dt.Rows[0]["numproduit"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("UPDATE couleurproduit SET numcouleur=@numcouleur WHERE numproduit=@numproduit"))
            {
                cmdUpdate.Parameters.AddWithValue("numproduit", this.NumProduit);
                cmdUpdate.Parameters.AddWithValue("numcouleur", this.NumCouleur);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }
    }
}
