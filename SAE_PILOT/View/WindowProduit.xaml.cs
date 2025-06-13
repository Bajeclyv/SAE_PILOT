using Npgsql;
using SAE_PILOT.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TD3_BindingBDPension.Model;
using static System.Net.Mime.MediaTypeNames;

namespace SAE_PILOT.View
{
    /// <summary>
    /// Logique d'interaction pour WindowProduit.xaml
    /// </summary>
    public partial class WindowProduit : Window
    {
        public WindowProduit(Produit unProduit)
        {
            InitializeComponent();
            this.DataContext = unProduit;
        }

        private void butValiderProduit_Click(object sender, RoutedEventArgs e)
        {
                bool ok = true;
                foreach (UIElement uie in panelProduit.Children)
                {
                    if (uie is TextBox)
                    {
                        TextBox txt = (TextBox)uie;
                        txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    }

                    if (Validation.GetHasError(uie))
                        ok = false;
                }
                if (!ok)
                    MessageBox.Show(this, "Erreur de saisie.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    DialogResult = true;
        }
    }
}
