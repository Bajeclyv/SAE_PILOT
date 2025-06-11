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
        }

        private void butCreerRevendeur_Click(object sender, RoutedEventArgs e)
        {
            WindowRevendeur windowRevendeur = new WindowRevendeur();
            windowRevendeur.ShowDialog();

            if (windowRevendeur.DialogResult == true)
            {
                if (windowRevendeur.LeRevendeur is not null)
                {
                    Revendeur r = windowRevendeur.LeRevendeur;
                    r.Create();
                }
            }
        }

        private void butModifierRevendeur_Click(object sender, RoutedEventArgs e)
        {
            WindowRevendeur windowRevendeur = new WindowRevendeur();
            windowRevendeur.ShowDialog();

            if (windowRevendeur.DialogResult == true)
            {
                if (windowRevendeur.LeRevendeur is not null)
                {
                    Revendeur r = windowRevendeur.LeRevendeur;
                    r.Create();
                }
            }
        }
    }
}
