using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public class Employe
    {
        private int numEmploye;
        private Role unRole;
        private string nom;
        private string prenom;
        private string password;
        private string login;

        // REVOIR LOGIN ET PASSWORD //
        public Employe () { }
        public Employe(int numEmploye, Role unRole, string nom, string prenom, string password, string login)
        {
            this.NumEmploye = numEmploye;
            this.UnRole = unRole;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Password = password;
            this.Login = login;
        }
        public Employe(Role unRole, string nom, string prenom, string password, string login)
        {
            this.UnRole = unRole;
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

        public Role UnRole
        {
            get
            {
                return this.unRole;
            }

            set
            {
                this.unRole = value;
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
    }
}
