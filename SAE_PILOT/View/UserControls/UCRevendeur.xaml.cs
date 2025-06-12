using SAE_PILOT.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_PILOT.View.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UCRevendeur.xaml
    /// </summary>
    public partial class UCRevendeur : UserControl
    {
        ObservableCollection<Revendeur> LesRevendeurs;
        public UCRevendeur()
        {
            InitializeComponent();
            this.DataContext = new GestionRevendeur();
            dgRevendeur.Items.Filter = RechercherRevendeur;
        }


        private bool RechercherRevendeur(object obj)
        {
            if (String.IsNullOrEmpty(txtSociale.Text) && String.IsNullOrEmpty(txtCPRevendeur.Text) && String.IsNullOrEmpty(txtVilleRevendeur.Text))
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
        private void txtRevendeur_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgRevendeur.ItemsSource)?.Refresh();
        }

        private void butCreerRevendeur_Click(object sender, RoutedEventArgs e)
        {
            Revendeur unRevendeur = new Revendeur();
            WindowRevendeur wRevendeur = new WindowRevendeur(unRevendeur);
            bool? result = wRevendeur.ShowDialog();
            if (result == true)
            {
                try
                {
                    unRevendeur.NumRevendeur = unRevendeur.Create();
                    ((GestionRevendeur)this.DataContext).LesRevendeurs.Add(unRevendeur);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Le revendeur n'a pas pu être créé.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void butModifierRevendeur_Click(object sender, RoutedEventArgs e)
        {
            if (dgRevendeur.SelectedItem == null)
                MessageBox.Show("Veuillez sélectionner un revendeur", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                Revendeur revendeurSelectionne = (Revendeur)dgRevendeur.SelectedItem;
                Revendeur copie = new Revendeur(revendeurSelectionne.NumRevendeur, revendeurSelectionne.RaisonSociale, revendeurSelectionne.AdresseRue, revendeurSelectionne.AdresseCP, revendeurSelectionne.AdresseVille);
                WindowRevendeur wRevendeur = new WindowRevendeur(copie);
                bool? result = wRevendeur.ShowDialog();
                if (result == true)
                {
                    try
                    {
                        copie.Update();
                        revendeurSelectionne.RaisonSociale = copie.RaisonSociale;
                        revendeurSelectionne.AdresseRue = copie.AdresseRue;
                        revendeurSelectionne.AdresseCP = copie.AdresseCP;
                        revendeurSelectionne.AdresseVille = copie.AdresseVille;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Le revendeur n'a pas pu être modifié.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                CollectionViewSource.GetDefaultView(dgRevendeur.ItemsSource)?.Refresh();
            }
        }
    }
}
