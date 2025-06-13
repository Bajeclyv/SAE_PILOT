using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD3_BindingBDPension.Model;

namespace SAE_PILOT.Model
{
    public class Revendeur : ICrud<Revendeur>
    {
        private int numRevendeur;
        private string raisonSociale;
        private string adresseRue;
        private string adresseCP;
        private string adresseVille;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Revendeur () { }
        public Revendeur(int numRevendeur, string raisonSociale, 
            string adresseRue, string adresseCP, string adresseVille)
        {
            this.NumRevendeur = numRevendeur;
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

        public int NumRevendeur
        {
            get
            {
                return this.numRevendeur;
            }

            set
            {
                this.numRevendeur = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumRevendeur)));
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
                this.raisonSociale = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RaisonSociale)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AdresseRue)));
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
                Regex rg = new Regex(@"^[0-9]{5}$");
                if (!rg.IsMatch(value))
                    throw new ArgumentException("code postal invalide");
                this.adresseCP = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AdresseCP)));
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
                this.adresseVille = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AdresseVille)));
            }
        }

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
                        (String)dr["adresseville"]
                    ));
            }
            return lesRevendeurs;
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("INSERT INTO revendeur (raisonsociale,adresserue,adressecp,adresseville) values (@raisonsociale,@adresserue,@adressecp,@adresseville) RETURNING numrevendeur"))
            {
                cmdInsert.Parameters.AddWithValue("raisonsociale", this.RaisonSociale);
                cmdInsert.Parameters.AddWithValue("adresserue", this.AdresseRue);
                cmdInsert.Parameters.AddWithValue("adressecp", this.AdresseCP);
                cmdInsert.Parameters.AddWithValue("adresseville", this.AdresseVille);
                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            this.NumRevendeur = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("SELECT * FROM revendeur WHERE numrevendeur = @numrevendeur"))
            {
                cmdSelect.Parameters.AddWithValue("numrevendeur", this.NumRevendeur);
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.RaisonSociale = (String)dt.Rows[0]["raisonsociale"];
                this.AdresseRue = (String)dt.Rows[0]["adresserue"];
                this.AdresseCP = (String)dt.Rows[0]["adressecp"];
                this.AdresseVille = (String)dt.Rows[0]["adresseville"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("UPDATE revendeur SET raisonsociale=@raisonsociale, adresserue=@adresserue, adressecp=@adressecp, adresseville=@adresseville WHERE numrevendeur=@numrevendeur"))
            {
                cmdUpdate.Parameters.AddWithValue("numrevendeur", this.NumRevendeur);
                cmdUpdate.Parameters.AddWithValue("raisonsociale", this.RaisonSociale);
                cmdUpdate.Parameters.AddWithValue("adresserue", this.AdresseRue);
                cmdUpdate.Parameters.AddWithValue("adressecp", this.AdresseCP);
                cmdUpdate.Parameters.AddWithValue("adresseville", this.AdresseVille);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from revendeur where numrevendeur = @numrevendeur;"))
            {
                cmdUpdate.Parameters.AddWithValue("id", this.NumRevendeur);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public List<Revendeur> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
