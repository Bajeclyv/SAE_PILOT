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
    /// Logique d'interaction pour UCSynthese.xaml
    /// </summary>
    public partial class UCSynthese : UserControl
    {
        public ObservableCollection<Commande> LesCommandes;

        public UCSynthese()
        {
            LesCommandes = new ObservableCollection<Commande>(new Commande().FindAll());
            InitializeComponent();
        }
    }
}
