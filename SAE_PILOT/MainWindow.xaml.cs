using SAE_PILOT.View.UserControls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_PILOT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private UCConnexion UserControlConnexion { get; set; }
        private UCRevendeur UserControlRevendeur { get; set; }
        private UCCommande UserControlCommande { get; set; }
        private UCProduit UserControlProduit { get; set; }



        public MainWindow()
        {
            InitializeComponent();
            UserControlConnexion = new UCConnexion();
            UserControlRevendeur = new UCRevendeur();
            UserControlCommande = new UCCommande();
            UserControlProduit = new UCProduit();
            MainContent.Content = UserControlConnexion;
        }

        private void butRevendeur_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = UserControlRevendeur;
        }

        private void butCommande_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = UserControlCommande;
        }

        private void butProduit_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = UserControlProduit;
        }
    }
}