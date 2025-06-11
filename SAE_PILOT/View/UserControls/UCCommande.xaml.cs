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
    /// Logique d'interaction pour UCCommande.xaml
    /// </summary>
    public partial class UCCommande : UserControl
    {
        public UCCommande()
        {
            InitializeComponent();
            this.DataContext = new GestionCommande();
        }

        private void btnCreerCommande_Click(object sender, RoutedEventArgs e)
        {
            WindowCommande windowCommande = new WindowCommande();
            windowCommande.ShowDialog();

            if (windowCommande.DialogResult == true)
            {
                if (windowCommande.DataContext is not null)
                {
                    Commande r = windowCommande.DataContext as Commande;
                    r.Create();
                }
            }
        }
    }
}
