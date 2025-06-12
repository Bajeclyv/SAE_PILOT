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

namespace SAE_PILOT.View
{
    /// <summary>
    /// Logique d'interaction pour WindowProduit.xaml
    /// </summary>
    public partial class WindowProduit : Window
    {
        private List<Model.Type> types = new List<Model.Type>(); // précision de modèle sinon ambiguïté
        private List<TypePointe> pointes = new List<TypePointe>();
        private List<Categorie> categories = new List<Categorie>();
        private List<Couleur> couleurs = new List<Couleur>();
        public WindowProduit(Produit unProduit)
        {
            this.DataContext = unProduit;
            InitializeComponent();
        }
        private void SelectionCategorie()
        {
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM categorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    categories.Add(new Categorie((Int32)dr["numcategorie"], (CategorieProduit)dr["libellecategorie"]));
                }
            }

        }
        private void SelectionType()
        {
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM type;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    types.Add(new Model.Type((Int32)dr["numtype"], (Int32)dr["numcategorie"], (string)dr["libelletype"]));
                }
            }
        }
        private void SelectionTypePointe()
        {
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM typepointe;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    pointes.Add(new TypePointe((Int32)dr["numtypepointe"], (EpaisseurPointe)dr["libelletypepointe"]));
                }
            }
        }
        private void SelectionCouleur()
        {
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM couleur;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    couleurs.Add(new Couleur((Int32)dr["numcouleur"], (Coloris)dr["libellecouleur"]));
                }
            }
        }

        private void InitComboBox()
        {

        }
    }
}
