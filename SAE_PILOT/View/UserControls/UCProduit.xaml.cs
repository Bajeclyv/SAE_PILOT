using Npgsql;
using SAE_PILOT.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using TD3_BindingBDPension.Model;

namespace SAE_PILOT.View.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UCProduit.xaml
    /// </summary>
    public partial class UCProduit : UserControl
    {
        ObservableCollection<Produit> LesProduits;
        
        public UCProduit()
        {
            InitializeComponent();
            this.DataContext = new GestionProduit();
            dgProduit.Items.Filter = RechercherProduit;
        }

        private bool RechercherProduit(object obj)
        {
            if (String.IsNullOrEmpty(tbCategorie.Text) && String.IsNullOrEmpty(tbType.Text) && String.IsNullOrEmpty(tbTypePointe.Text) && String.IsNullOrEmpty(tbCouleur.Text))
                return true;

            bool filtreCat = true;
            bool filtreType = true;
            bool filtreTP = true;
            bool filtreCouleur = true;


            Produit unProduit = obj as Produit;

            if (!String.IsNullOrEmpty(tbCategorie.Text))
                filtreCat = unProduit.NomCategorie.ToLower().StartsWith(tbCategorie.Text, StringComparison.OrdinalIgnoreCase);

            if (!String.IsNullOrEmpty(tbType.Text))
                filtreType = unProduit.NomType.ToLower().StartsWith(tbType.Text, StringComparison.OrdinalIgnoreCase);

            if (!String.IsNullOrEmpty(tbTypePointe.Text))
            {
                filtreTP = unProduit.NomTypePointe.ToLower().StartsWith(tbTypePointe.Text, StringComparison.OrdinalIgnoreCase);
            }

            if (!String.IsNullOrEmpty(tbCouleur.Text))
            {
                // Split(',') : découpe la chaîne selon les virgules
                // Trim() : supprime les espaces avec les mots
                filtreCouleur = unProduit.NomCouleur.ToLower().Split(',').Any(c => c.Trim().ToLower().StartsWith(tbCouleur.Text, StringComparison.OrdinalIgnoreCase));
            }

            return filtreCat && filtreType && filtreTP && filtreCouleur;
        }

        private void tbProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgProduit.ItemsSource)?.Refresh();
        }

        private void butCreerProduit_Click(object sender, RoutedEventArgs e)
        {
            Produit unProduit = new Produit();
            List<int> lesNumCouleurs = new List<int>();

            WindowProduit wProduit = new WindowProduit(unProduit);
            bool? result = wProduit.ShowDialog();
            if (result == true)
            {
                try
                {
                    MessageBox.Show($"Catégorie sélectionnée : {unProduit.NumType}, {unProduit.NumTypePointe}");
                    unProduit.NumProduit = unProduit.Create();
                    ((GestionProduit)this.DataContext).LesProduits.Add(unProduit);
                    lesNumCouleurs = SelectionCouleur(wProduit, unProduit);
                    InsertionCouleurProduit(unProduit, lesNumCouleurs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Le produit n'a pas pu être créé.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void butModifierProduit_Click(object sender, RoutedEventArgs e)
        {
            if (dgProduit.SelectedItem == null)
                MessageBox.Show("Veuillez sélectionner un produit", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                Produit produitSelectionne = (Produit)dgProduit.SelectedItem;
                Produit copie = new Produit(produitSelectionne.NumProduit, produitSelectionne.NumTypePointe, produitSelectionne.NumType, produitSelectionne.CodeProduit, produitSelectionne.NomProduit, produitSelectionne.PrixVente, produitSelectionne.QteStock);
                WindowProduit wProduit = new WindowProduit(copie);
                List<int> lesNumCouleurs = new List<int>();

                bool? result = wProduit.ShowDialog();
                if (result == true)
                {
                    try
                    {
                        copie.Update();
                        produitSelectionne.NumProduit = copie.NumProduit;
                        produitSelectionne.NumType = copie.NumType;
                        produitSelectionne.NumTypePointe = copie.NumTypePointe;
                        produitSelectionne.CodeProduit = copie.CodeProduit;
                        produitSelectionne.NomProduit = copie.NomProduit;
                        produitSelectionne.PrixVente = copie.PrixVente;
                        produitSelectionne.QteStock = copie.QteStock;
                        lesNumCouleurs = SelectionCouleur(wProduit, copie);
                        if (!wProduit.gCouleur.Children.OfType<CheckBox>().Any(cb => cb.IsChecked == true))
                            return;
                        else 
                            UpdateCouleurProduit(copie, lesNumCouleurs);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Le produit n'a pas pu être modifié.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    CollectionViewSource.GetDefaultView(dgProduit.ItemsSource)?.Refresh();
                }
            }
        }

         private List<int> SelectionCouleur(WindowProduit wProduit, Produit unProduit)
         {
            List<int> lesNumCouleurs = new List<int>();
            string couleur = "";
            int cle;

            foreach(UIElement uie in wProduit.gCouleur.Children)
            {
                 if(uie is CheckBox cb && cb.IsChecked == true)
                 {
                      couleur = cb.Content.ToString();
                      cle = unProduit.dCouleurs.FirstOrDefault(x => x.Value == couleur).Key;
                      if (cle != 0)
                        lesNumCouleurs.Add(cle);
                 }
                    
            }
            return lesNumCouleurs;
         } 

         private void InsertionCouleurProduit(Produit unProduit, List<int> lesNumCouleurs)
         {
            CouleurProduit cp = new CouleurProduit();
            cp.NumProduit = unProduit.NumProduit;
            foreach(int c in lesNumCouleurs)
            {
                cp.NumCouleur = c;
                cp.Create();
            }
         }
        private void UpdateCouleurProduit(Produit unProduit, List<int> lesNumCouleurs)
        {
            CouleurProduit cp = new CouleurProduit();
            cp.NumProduit = unProduit.NumProduit;
            cp.Delete();
            foreach (int c in lesNumCouleurs)
            {
                cp.NumCouleur = c;
                cp.Create();
            }
            
        }
    }
}
