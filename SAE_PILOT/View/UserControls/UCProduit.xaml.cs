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
            string cat = (tbCategorie.SelectedItem as ComboBoxItem)?.Content.ToString();
            string type = (tbType.SelectedItem as ComboBoxItem)?.Content.ToString();
            string pointe = (tbTypePointe.SelectedItem as ComboBoxItem)?.Content.ToString();
            string couleur = (tbCouleur.SelectedItem as ComboBoxItem)?.Content.ToString(); 

            if ((String.IsNullOrEmpty(cat) && String.IsNullOrEmpty(type) && String.IsNullOrEmpty(pointe) && String.IsNullOrEmpty(couleur)))
                return true;

            bool filtreCat = true;
            bool filtreType = true;
            bool filtreTP = true;
            bool filtreCouleur = true;


            Produit unProduit = obj as Produit;

            if (!String.IsNullOrEmpty(cat))
                filtreCat = unProduit.NomCategorie.ToLower().StartsWith(cat, StringComparison.OrdinalIgnoreCase);

            if (!String.IsNullOrEmpty(type))
                filtreType = unProduit.NomType.ToLower().StartsWith(type, StringComparison.OrdinalIgnoreCase);

            if (!String.IsNullOrEmpty(pointe))
            {
                filtreTP = unProduit.NomTypePointe.ToLower().StartsWith(pointe, StringComparison.OrdinalIgnoreCase);
            }

            if (!String.IsNullOrEmpty(couleur))
            {
                // Split(',') : découpe la chaîne selon les virgules
                // Trim() : supprime les espaces avec les mots
                filtreCouleur = unProduit.NomCouleur.ToLower().Split(',').Any(c => c.Trim().ToLower().StartsWith(couleur, StringComparison.OrdinalIgnoreCase));
            }
            return filtreCat && filtreType && filtreTP && filtreCouleur;
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
        private void butSupprimerProduit_Click(object sender, RoutedEventArgs e)
        {
            if (dgProduit.SelectedItem == null)
                MessageBox.Show("Veuillez sélectionner un produit", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                Produit produitSupp = (Produit)dgProduit.SelectedItem;
                try
                {
                    bool persiste = true;
                    int nbCommande = produitSupp.FindNbCommande();
                    if (nbCommande > 0)
                    {
                        MessageBoxResult res = MessageBox.Show($"Attention ce produit est lié à {nbCommande} commande(s). Désirez-vous tout de même supprimer ce produit dans ses {nbCommande} commande(s) ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (res != MessageBoxResult.Yes)
                            persiste = false;
                    }

                    if (persiste)
                    {
                        DeleteCouleurProduit(produitSupp);
                        DeleteProduitCommande(produitSupp);
                        produitSupp.Delete();
                        ((GestionProduit)this.DataContext).LesProduits.Remove(produitSupp);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Le produit n'a pas pu être supprimé.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
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
        private void DeleteCouleurProduit(Produit unProduit)
        {
            CouleurProduit cp = new CouleurProduit();
            cp.NumProduit = unProduit.NumProduit;
            cp.Delete();
        }
        private void DeleteProduitCommande(Produit unProduit)
        {
            ProduitCommande pc = new ProduitCommande();
            pc.NumProduit = unProduit.NumProduit;
            pc.Delete();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(rbFiltre.IsChecked== true)
                rbFiltre.IsChecked = false;
            CollectionViewSource.GetDefaultView(dgProduit.ItemsSource)?.Refresh();
        }

        private void rbFiltre_Checked(object sender, RoutedEventArgs e)
        {
            tbCategorie.SelectedIndex = -1;
            tbType.SelectedIndex = -1;
            tbTypePointe.SelectedIndex = -1;
            tbCouleur.SelectedIndex = -1;
        }
    }
}
