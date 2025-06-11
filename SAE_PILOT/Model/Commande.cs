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
    public class Commande : ICrud<Commande>
    {
        private int numCommande;
        private int numEmploye; 
        private int numTransport; 
        private int numRevendeur; 
        private DateTime dateCommande;
        private DateTime? dateLivraison;
        private double prixTotal;

        private GestionDetails detail;

        public Commande () { }
        public Commande(int numCommande, int numEmploye, int numTransport,
            int numRevendeur, DateTime dateCommande)
        {
            this.NumCommande = numCommande;
            this.NumEmploye = numEmploye;
            this.NumTransport = numTransport;
            this.NumRevendeur = numRevendeur;
            this.DateCommande = dateCommande;
            this.DateLivraison = null;
        }
        public Commande(int numCommande, int numEmploye, int numTransport,
                    int numRevendeur, DateTime dateCommande, DateTime dateLivraison)
        {
            this.NumCommande = numCommande;
            this.NumEmploye = numEmploye;
            this.NumTransport = numTransport;
            this.NumRevendeur = numRevendeur;
            this.DateCommande = dateCommande;
            this.DateLivraison = dateLivraison;
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

        public int NumEmploye
        {
            get
            {
                return this.numEmploye;
            }

            set
            {
                this.numEmploye = value;
            }
        }

        public int NumTransport
        {
            get
            {
                return this.numTransport;
            }

            set
            {
                this.numTransport = value;
            }
        }

        public int NumRevendeur
        {
            get
            {
                return this.numRevendeur;
            }

            set
            {
                this.numRevendeur = value;
            }
        }

        public DateTime DateCommande
        {
            get
            {
                return this.dateCommande;
            }

            set
            {
                this.dateCommande = value;
            }
        }

        public DateTime? DateLivraison
        {
            get
            {
                return this.dateLivraison;
            }

            set
            {
                this.dateLivraison = value;
            }
        }

        public GestionDetails Detail
        {
            get
            {
                return this.detail;
            }

            set
            {
                this.detail = value;
            }
        }

        public double PrixTotal1
        {
            get
            {
                double total = 0;
                foreach (ProduitCommande pc in this.Detail.LesDetails)
                    if(pc.UneCommande.NumCommande == this.NumCommande)
                    {
                        total += pc.Prix;
                    }
                return total;
            }
        }

        public void SaisirDateLivraison (DateTime date)
        {
            this.DateLivraison = date;
        }

        public List<Commande> FindAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM commande;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Commande(
                        (Int32)dr["numcommande"],
                        (Int32)dr["numemploye"],
                        (Int32)dr["numtransport"],
                        (Int32)dr["numrevendeur"],
                        DateTime.Parse((string)dr["datecommande"]),
                        DateTime.Parse((string)dr["datelivraison"])
                    ));
            }
            return lesCommandes;
        }

        // int numCommande, Employe unEmploye, ModeTransport unTransport, Revendeur unRevendeur, DateTime dateCommande
        public int Create()
        {
            int nb = 0;
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO commande (numemploye, numtransport, numrevendeur, datecommande) VALUES (@numemploye, @numtransport, @numrevendeur, @datecommande)"))
            {
                cmd.Parameters.AddWithValue("numemploye", this.NumEmploye);
                cmd.Parameters.AddWithValue("numtransport", this.NumTransport);
                cmd.Parameters.AddWithValue("numrevendeur", this.NumRevendeur);
                cmd.Parameters.AddWithValue("datecommande", this.DateCommande.ToShortDateString());
                nb = DataAccess.Instance.ExecuteInsert(cmd);
            }
            this.NumCommande = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("SELECT * FROM commande JOIN employe ON commande.numemploye = employe.numemploye JOIN role ON employe.numrole = role.numrole JOIN revendeur ON commande.numrevendeur = revendeur.numrevendeur;"))
            {
                cmdSelect.Parameters.AddWithValue("numcommande", this.NumCommande);
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.NumEmploye = (int)dt.Rows[0]["numemploye"];
                this.NumTransport = (int)dt.Rows[0]["numtransport"];
                this.NumRevendeur = (int)dt.Rows[0]["numrevendeur"];
                this.DateCommande = DateTime.Parse((string)dt.Rows[0]["datecommande"]);
                this.DateLivraison = DateTime.Parse((string)dt.Rows[0]["datelivraison"]);
            }
        }

        public int Update()
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE commande SET numemploye=@numemploye, numtransport=@numtransport, numrevendeur=@numrevendeur, datecommande=@datecommande WHERE numcommande = @numcommande;"))
            {
                cmd.Parameters.AddWithValue("numemploye", this.NumEmploye);
                cmd.Parameters.AddWithValue("numtransport", this.NumTransport);
                cmd.Parameters.AddWithValue("numrevendeur", this.NumRevendeur);
                cmd.Parameters.AddWithValue("datecommande", this.DateCommande.ToShortDateString());
                return DataAccess.Instance.ExecuteSet(cmd);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from commande  where numcommande = @numcommande;"))
            {
                cmdUpdate.Parameters.AddWithValue("id", this.NumCommande);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public List<Commande> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
