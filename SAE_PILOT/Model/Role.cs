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
    public enum RoleEmploye { Commercial, ResponsableProduction}
    public class Role : ICrud<Role>
    {
        private int numRole;
        private RoleEmploye libelleRole;

        public Role () { }
        public Role(int numRole, RoleEmploye libelleRole)
        {
            this.NumRole = numRole;
            this.LibelleRole = libelleRole;
        }
        public Role(RoleEmploye libelleRole)
        {
            this.LibelleRole = libelleRole;
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

        public RoleEmploye LibelleRole
        {
            get
            {
                return this.libelleRole;
            }

            set
            {
                this.libelleRole = value;
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

        public List<Role> FindAll()
        {
            List<Role> lesRoles = new List<Role>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM role"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesRoles.Add(new Role((int)dr["numrole"], (RoleEmploye)dr["libellerole"]));
            }

            return lesRoles;
        }

        public List<Role> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
