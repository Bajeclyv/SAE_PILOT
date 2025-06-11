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
    public class Employe : ICrud<Employe>
    {
        private int numEmploye;
        private int numRole; 
        private string nom;
        private string prenom;
        private string password;
        private string login;

        // REVOIR LOGIN ET PASSWORD //
        public Employe () { }
        public Employe(int numEmploye, int numRole, string nom, string prenom, string password, string login)
        {
            this.NumEmploye = numEmploye;
            this.NumEmploye = numRole;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Password = password;
            this.Login = login;
        }
        public Employe(int numRole, string nom, string prenom, string password, string login)
        {
            this.NumRole = numRole;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Password = password;
            this.Login = login;
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

        public int NumRole
        {
            get
            {
                return this.numRole;
            }

            set
            {
                this.numRole = value;
            }
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {
                this.prenom = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        public string Login
        {
            get
            {
                return this.login;
            }

            set
            {
                this.login = value;
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
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public List<Employe> FindAll()
        {
            /*List<Employe> lesEmployes = new List<Employe>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM employe"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesEmployes.Add(new Employe(
                        (int)dr["numemploye"],
                        new Role()));
            }

            return lesEmployes;*/
            throw new NotImplementedException();

        }

        public List<Employe> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
