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
    public class Revendeur
    {
        private int numReveneur;
        private string raisonSociale;
        private string adresseRue;
        private string adresseCP;
        private string adresseVille;

        private Revendeur () { }
        public Revendeur(int numReveneur, string raisonSociale, 
            string adresseRue, string adresseCP, string adresseVille)
        {
            this.NumReveneur = numReveneur;
            this.RaisonSociale = raisonSociale;
            this.AdresseRue = adresseRue;
            this.AdresseCP = adresseCP;
            this.AdresseVille = adresseVille;
        }
        public Revendeur(string raisonSociale,
            string adresseRue, string adresseCP, string adresseVille)
        {
            this.RaisonSociale = raisonSociale;
            this.AdresseRue = adresseRue;
            this.AdresseCP = adresseCP;
            this.AdresseVille = adresseVille;
        }

        public int NumReveneur
        {
            get
            {
                return this.numReveneur;
            }

            set
            {
                this.numReveneur = value;
            }
        }

        public string RaisonSociale
        {
            get
            {
                return this.raisonSociale;
            }

            set
            {
                this.raisonSociale = value;
            }
        }

        public string AdresseRue
        {
            get
            {
                return this.adresseRue;
            }

            set
            {
                this.adresseRue = value;
            }
        }

        public string AdresseCP
        {
            get
            {
                return this.adresseCP;
            }

            set
            {
                this.adresseCP = value;
            }
        }

        public string AdresseVille
        {
            get
            {
                return this.adresseVille;
            }

            set
            {
                this.adresseVille = value;
            }
        }
        /*
         
         
Colonne	Type	NOT NULL	Défaut	Contraintes	Actions	Commentaire
numrevendeur
raisonsociale
adresserue
adressecp
adresseville
         
         */
        public List<Revendeur> FindAll()
        {
            List<Revendeur> lesRevendeurs = new List<Revendeur>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from revendeur;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesRevendeurs.Add(new Revendeur((Int32)dr["numrevendeur"],
                        (String)dr["raisonsociale"],
                        (String)dr["adresserue"],
                        (String)dr["adressecp"],
                        (String)dr["adresserue"]
                    ));
            }
            return lesRevendeurs;
        }
    }
}
