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
        private Employe unEmploye;
        private ModeTransport unTransport;
        private Revendeur unRevendeur;
        private DateTime dateCommande;
        private DateTime? dateLivraison;

        private ProduitCommande detail;

        public Commande () { }
        public Commande(int numCommande, Employe unEmploye, ModeTransport unTransport,
            Revendeur unRevendeur, DateTime dateCommande)
        {
            this.NumCommande = numCommande;
            this.UnEmploye = unEmploye;
            this.UnTransport = unTransport;
            this.UnRevendeur = unRevendeur;
            this.DateCommande = dateCommande;
            this.DateLivraison = null;
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

        public Employe UnEmploye
        {
            get
            {
                return this.unEmploye;
            }

            set
            {
                this.unEmploye = value;
            }
        }

        public ModeTransport UnTransport
        {
            get
            {
                return this.unTransport;
            }

            set
            {
                this.unTransport = value;
            }
        }

        public Revendeur UnRevendeur
        {
            get
            {
                return this.unRevendeur;
            }

            set
            {
                this.unRevendeur = value;
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

        public ProduitCommande Detail
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

        public double PrixTotal
        {
            get
            {
                // Récuperer liste des produits d'une commande et faire la somme //
                // Somme  des prix pour laquelle les id de commande sont identiques //
                return Math.Round(Detail.QteCommande * Detail.Prix, 2); 
            }
        }

        public void SaisirDateLivraison (DateTime date)
        {
            this.DateLivraison = date;
        }

        public List<Commande> FindAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM commande JOIN employe ON commande.numemploye = employe.numemploye JOIN role ON employe.numrole = role.numrole JOIN revendeur ON commande.numrevendeur = revendeur.numrevendeur;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Commande(
                        (Int32)dr["numcommande"],
                        new Employe((Int32)dr["employe.numemploye"], new Role((int)dr["role.numrole"], (RoleEmploye)dr["libellerole"]), (string)dr["nom"], (string)dr["prenom"], (string)dr["password"], (string)dr["login"]),
                        new ModeTransport((int)dr["modetransport.numtransport"], (Mode)dr["libelletransport"]),
                        new Revendeur((int)dr["revendeur.numrevendeur"], (string)dr["raisonsociale"], (string)dr["adresserue"], (string)dr["adressecp"], (string)dr["adresseville"]),
                        DateTime.Parse((string)dr["datecommande"])
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
                cmd.Parameters.AddWithValue("numemploye", this.UnEmploye.NumEmploye);
                cmd.Parameters.AddWithValue("numtransport", this.UnTransport.NumTransport);
                cmd.Parameters.AddWithValue("numrevendeur", this.UnRevendeur.NumReveneur);
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
                this.UnEmploye.NumEmploye = (int)dt.Rows[0]["numemploye"];
                this.UnTransport.NumTransport = (int)dt.Rows[0]["numtransport"];
                this.UnRevendeur.NumReveneur = (int)dt.Rows[0]["numrevendeur"];
                this.DateCommande = DateTime.Parse((string)dt.Rows[0]["datecommande"]);
                this.DateLivraison = DateTime.Parse((string)dt.Rows[0]["datelivraison"]);
            }
        }

        public int Update()
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE commande SET numemploye=@numemploye, numtransport=@numtransport, numrevendeur=@numrevendeur, datecommande=@datecommande WHERE numcommande = @numcommande;"))
            {
                cmd.Parameters.AddWithValue("numemploye", this.UnEmploye.NumEmploye);
                cmd.Parameters.AddWithValue("numtransport", this.UnTransport.NumTransport);
                cmd.Parameters.AddWithValue("numrevendeur", this.UnRevendeur.NumReveneur);
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
