using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public enum RoleEmploye { Commercial, ResponsableProduction}
    public class Role
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
    }
}
