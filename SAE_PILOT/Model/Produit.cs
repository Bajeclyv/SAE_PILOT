using Npgsql;
using SAE_PILOT.View.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
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
        public Dictionary<int, string> dCategories { get; set; }
        public Dictionary<int, string> dTypes { get; set; }
        public Dictionary<int, string> dPointes { get; set; }
        public Dictionary<int, string> dCouleurs { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Produit ()
        {
            ChargerDictionnaires();
        }
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
            ChargerDictionnaires();
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
            ChargerDictionnaires();
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
            ChargerDictionnaires();
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumProduit)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumTypePointe)));

            }
        }
        public string NomTypePointe
        {
            get
            {
                string nom = "";

                using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT libelletypepointe FROM typepointe where numtypepointe=@numtypepointe;"))
                {
                    cmdSelect.Parameters.AddWithValue("numtypepointe", this.NumTypePointe);
                    DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                    nom = (String)dt.Rows[0]["libelletypepointe"];
                }
                return nom;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomTypePointe)));
            }
        }
        public string NomType
        {
            get
            {
                string nom = "";

                using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT libelletype FROM type where numtype=@numtype;"))
                {
                    cmdSelect.Parameters.AddWithValue("numtype", this.NumType);
                    DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                    nom = (String)dt.Rows[0]["libelletype"];
                }
                return nom;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomType)));
            }
        }

        public string NomCouleur
        {
            get
            {
                List<string> lesCouleurs = new List<string>();
                string couleur = "";

                using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT libellecouleur FROM couleur c " +
                    "join couleurproduit cp on c.numcouleur=cp.numcouleur " +
                    "join produit p on cp.numproduit=p.numproduit " +
                    "where cp.numproduit=@numproduit;"))
                {
                    cmdSelect.Parameters.AddWithValue("numproduit", this.NumProduit);
                    DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                    foreach (DataRow dr in dt.Rows)
                    {
                        lesCouleurs.Add(dr["libellecouleur"].ToString());
                    }
                    foreach (string c in lesCouleurs)
                    {
                        if (couleur != "")
                            couleur += ", ";

                        couleur += c;
                    }
                }
                return couleur;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomCouleur)));
            }
        }
        public string NomCategorie
        {
            get
            {
                string nom = "";

                using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT libellecategorie FROM type t " +
                    "join categorie c on c.numcategorie=t.numcategorie " +
                    "join produit p on p.numtype=t.numtype " +
                    "where p.numproduit=@numproduit;"))
                {
                    cmdSelect.Parameters.AddWithValue("numproduit", this.NumProduit);
                    DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                    nom = (String)dt.Rows[0]["libellecategorie"];
                }
                return nom;
            }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomCategorie)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumType)));

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
                this.codeProduit = value.ToUpper();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CodeProduit)));
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
                this.nomProduit = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomProduit)));

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PrixVente)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QteStock)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disponible)));
            }
        }

        public int Create()
        {
            int nb = 0;

            using (var cmdInsert = new NpgsqlCommand("INSERT INTO produit (numtypepointe,numtype,codeproduit,nomproduit,prixvente,quantitestock,disponible) values (@numtypepointe,@numtype,@codeproduit, @nomproduit, @prixvente, @qtestock, @disponible) RETURNING numproduit"))
            {
                cmdInsert.Parameters.AddWithValue("numtypepointe", this.NumTypePointe);
                cmdInsert.Parameters.AddWithValue("numtype", this.NumType);
                cmdInsert.Parameters.AddWithValue("codeproduit", this.CodeProduit);
                cmdInsert.Parameters.AddWithValue("nomproduit", this.NomProduit);
                cmdInsert.Parameters.AddWithValue("prixvente", this.PrixVente);
                cmdInsert.Parameters.AddWithValue("qtestock", this.QteStock);
                cmdInsert.Parameters.AddWithValue("disponible", this.Disponible);
                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            this.NumProduit = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("SELECT * FROM produit WHERE numproduit = @numproduit"))
            {
                cmdSelect.Parameters.AddWithValue("numproduit", this.NumProduit);
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.NumTypePointe = (Int32)dt.Rows[0]["numtypepointe"];
                this.NumType = (Int32)dt.Rows[0]["numtype"];
                this.CodeProduit = (String)dt.Rows[0]["codeproduit"];
                this.NomProduit = (String)dt.Rows[0]["nomproduit"];
                this.PrixVente = (decimal)dt.Rows[0]["prixvente"];
                this.QteStock = (Int32)dt.Rows[0]["quantitestock"];
                this.Disponible = (Boolean)dt.Rows[0]["disponible"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("UPDATE produit SET numtypepointe=@numtypepointe, numtype=@numtype, codeproduit=@codeproduit, " +
               "nomproduit=@nomproduit, prixvente=@prixvente, quantitestock=@qtestock, disponible=@disponible WHERE numproduit=@numproduit"))
            {
                cmdUpdate.Parameters.AddWithValue("numproduit", this.NumProduit);
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

        private void ChargerDictionnaires()
        {
            ChargerCategorie();
            ChargerCouleur();
            ChargerType();
            ChargerTypePointe();
        }

        private Dictionary<int, string> ChargerCategorie()
        {
            dCategories = new Dictionary<int, string>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select numcategorie, libellecategorie from categorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    dCategories.Add((Int32)dr["numcategorie"], (string)dr["libellecategorie"]);
                }
            }
            return dCategories;
        }
        private Dictionary<int, string> ChargerType()
        {
            dTypes = new Dictionary<int, string>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select numtype, libelletype from type;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    dTypes.Add((Int32)dr["numtype"], (string)dr["libelletype"]);
                }
            }
            return dTypes;
        }
        private Dictionary<int, string> ChargerTypePointe()
        {
            dPointes = new Dictionary<int, string>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select numtypepointe, libelletypepointe from typepointe;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    dPointes.Add((Int32)dr["numtypepointe"], (string)dr["libelletypepointe"]);
                }
            }
            return dPointes;
        }
        private Dictionary<int, string> ChargerCouleur()
        {
            dCouleurs = new Dictionary<int, string>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select numcouleur, libellecouleur from couleur;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    dCouleurs.Add((Int32)dr["numcouleur"], (string)dr["libellecouleur"]);
                }
            }
            return dCouleurs;
        }
    }
}
