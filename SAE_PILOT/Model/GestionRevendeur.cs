using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public class GestionRevendeur
    {
        private ObservableCollection<Revendeur> lesRevendeurs;

        public GestionRevendeur()
        {
            this.LesRevendeurs = new ObservableCollection<Revendeur>(new Revendeur().FindAll());
        }

        public ObservableCollection<Revendeur> LesRevendeurs
        {
            get
            {
                return this.lesRevendeurs;
            }

            set
            {
                this.lesRevendeurs = value;
            }
        }
    }
}
