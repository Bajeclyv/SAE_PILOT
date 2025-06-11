using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model
{
    public class GestionDetails
    {
        private ObservableCollection<ProduitCommande> lesDetails;

        public GestionDetails()
        {
            //this.LesDetails = new ObservableCollection<ProduitCommande>(new ProduitCommande().FindAll());
        }

        public ObservableCollection<ProduitCommande> LesDetails
        {
            get
            {
                return this.lesDetails;
            }

            set
            {
                this.lesDetails = value;
            }
        }
    }
}
