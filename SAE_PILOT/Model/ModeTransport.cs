using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public enum Mode { UPS, Chronopost, Relais}
    public class ModeTransport
    {
        private int numTransport;
        private Mode libelleTransport;

        public ModeTransport() { }  
        public ModeTransport(int numTransport, Mode libelleTransport)
        {
            this.NumTransport = numTransport;
            this.LibelleTransport = libelleTransport;
        }
        public ModeTransport(Mode libelleTransport)
        {
            this.LibelleTransport = libelleTransport;
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

        public Mode LibelleTransport
        {
            get
            {
                return this.libelleTransport;
            }

            set
            {
                this.libelleTransport = value;
            }
        }
    }
}
