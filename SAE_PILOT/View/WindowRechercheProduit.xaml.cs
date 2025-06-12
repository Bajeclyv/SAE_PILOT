﻿using System;
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
using SAE_PILOT.Model;

namespace SAE_PILOT.View
{
    /// <summary>
    /// Logique d'interaction pour WindowRechercheProduit.xaml
    /// </summary>
    public partial class WindowRechercheProduit : Window
    {
        public WindowRechercheProduit()
        {
            this.DataContext = new GestionProduit();
            InitializeComponent();
        }
    }
}
