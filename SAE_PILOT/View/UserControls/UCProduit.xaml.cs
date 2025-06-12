using SAE_PILOT.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_PILOT.View.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UCProduit.xaml
    /// </summary>
    public partial class UCProduit : UserControl
    {
        public UCProduit()
        {
            InitializeComponent();
            this.DataContext = new GestionProduit();
            dgProduit.Items.Filter = RechercherProduit;
        }

        private bool RechercherRevendeur(object obj)
        {
            if (String.IsNullOrEmpty(.Text) && String.IsNullOrEmpty(txtCPRevendeur.Text) && String.IsNullOrEmpty(txtVilleRevendeur.Text))
                return true;

            bool filtreSociale = true;
            bool filtreCP = true;
            bool filtreVille = true;

            Revendeur unRevendeur = obj as Revendeur;

            if (!String.IsNullOrEmpty(txtSociale.Text))
                filtreSociale = unRevendeur.RaisonSociale.StartsWith(txtSociale.Text, StringComparison.OrdinalIgnoreCase);

            if (!String.IsNullOrEmpty(txtCPRevendeur.Text))
                filtreCP = unRevendeur.AdresseCP.ToLower().StartsWith(txtCPRevendeur.Text, StringComparison.OrdinalIgnoreCase);

            if (!String.IsNullOrEmpty(txtVilleRevendeur.Text))
                filtreVille = unRevendeur.AdresseVille.ToLower().StartsWith(txtVilleRevendeur.Text, StringComparison.OrdinalIgnoreCase);

            return filtreSociale && filtreCP && filtreVille;
        }

        private void tbProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgProduit.ItemsSource)?.Refresh();
        }
    }
}
