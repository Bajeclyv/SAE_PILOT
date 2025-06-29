﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD3_BindingBDPension.Model;
using static System.Net.Mime.MediaTypeNames;

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
        private decimal prixTotal;

        private GestionDetails detail; // a revoir la pertinence

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
        public string NomCompletEmploye
        {

            get
            {
                string nom = "";

                using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT nom, prenom FROM employe where numemploye=@numemploye;"))
                {
                    cmdSelect.Parameters.AddWithValue("numemploye", this.NumEmploye);
                    DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                    nom = (String)dt.Rows[0]["nom"] + " " + (String)dt.Rows[0]["prenom"];
                }
                return nom;
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
        public string NomTransport
        {

            get
            {
                string nom = "";

                using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT libelletransport FROM modetransport where numtransport=@numtransport;"))
                {
                    cmdSelect.Parameters.AddWithValue("numtransport", this.NumTransport);
                    DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                    nom = (String)dt.Rows[0]["libelletransport"];
                }
                return nom;
            }
        }
        public string NomRevendeur
        {

            get
            {
                string nom = "";

                using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT raisonsociale FROM revendeur where numrevendeur=@numrevendeur;"))
                {
                    cmdSelect.Parameters.AddWithValue("numrevendeur", this.NumRevendeur);
                    DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                    nom = (String)dt.Rows[0]["raisonsociale"];
                }
                return nom;
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

        public decimal PrixTotal
        {
            get
            {
                decimal total = 0;
                foreach (ProduitCommande pc in this.Detail.LesDetails)
                    if(pc.NumCommande == this.NumCommande)
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
                        (DateTime)dr["datecommande"],
                        (DateTime)dr["datelivraison"]
                    ));
            }
            return lesCommandes;
        }

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
            using (var cmdSelect = new NpgsqlCommand("SELECT * FROM commande;"))
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
                cmdUpdate.Parameters.AddWithValue("numcommande", this.NumCommande);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }
        
        public List<Commande> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
