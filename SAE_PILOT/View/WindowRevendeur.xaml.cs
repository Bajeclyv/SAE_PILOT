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
using System.Windows.Shapes;

namespace SAE_PILOT.View
{
    /// <summary>
    /// Logique d'interaction pour WindowRevendeur.xaml
    /// </summary>
    public partial class WindowRevendeur : Window
    {
        public Revendeur LeRevendeur;

        public WindowRevendeur()
        {
            this.LeRevendeur = new Revendeur();
            this.DataContext = this.LeRevendeur;
            InitializeComponent();
        }

        private void butValiderRevendeur_Click(object sender, RoutedEventArgs e)
        {
            LeRevendeur = (Revendeur)this.DataContext;
            this.DialogResult = true;
        }
    }
}
