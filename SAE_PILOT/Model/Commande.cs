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

        // int numCommande, Employe unEmploye, ModeTransport unTransport, Revendeur unRevendeur, DateTime dateCommande
        public List<Commande> FindAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            
            /*using (NpgsqlCommand cmdSelect = new NpgsqlCommand("" +
                "SELECT *" +
                "FROM commande" +
                "   JOIN"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Commande((Int32)dr["numcommande"],
                        new Employe()
                    ));
            }*/
            return lesCommandes;
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

        public List<Commande> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
