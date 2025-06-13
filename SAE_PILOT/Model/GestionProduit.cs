using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TD3_BindingBDPension.Model;

namespace SAE_PILOT.Model
{
    public class GestionProduit
    {
        private ObservableCollection<Produit> lesProduits;

        public GestionProduit()
        {
            this.LesProduits = new ObservableCollection<Produit>(new Produit().FindAll());
        }

        public ObservableCollection<Produit> LesProduits
        {
            get
            {
                return this.lesProduits;
            }

            set
            {
                this.lesProduits = value;
            }
        }
    }
}
