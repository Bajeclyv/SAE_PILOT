using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SAE_PILOT.Model;

namespace SAE_PILOT.View
{
    /// <summary>
    /// Logique d'interaction pour WindowCommande.xaml
    /// </summary>
    public partial class WindowCommande : Window
    {
        Commande laCommande;
        ObservableCollection<ProduitCommande> lesProduits;
        public WindowCommande()
        {
            laCommande = new Commande();
            this.DataContext = laCommande;
            this.lesProduits = laCommande.Detail.LesDetails;
            InitializeComponent();
        }

        private void butAjouterProduit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
