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
using PlivanjeDesktop.Models;
using Plivanje.Models;
using PlivanjeDesktop.ViewModels;

namespace PlivanjeDesktop.Views
{
    /// <summary>
    /// Interaction logic for ZapisRezultataUtrke.xaml
    /// </summary>
    public partial class ZapisRezultataUtrke : Window
    {
        SwimmerResultViewModel srvm = new SwimmerResultViewModel();

        public ZapisRezultataUtrke(int idSwimmer, int idRace)
        {
            InitializeComponent();
            srvm.LoadRace(idSwimmer, idRace);
            this.DataContext = srvm;
            
        }

        private void Button_Unesi(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbResult.Text))
            {
                MessageBox.Show("Potrebno je unijeti rezultat.");
                return;
            }
            if (String.IsNullOrEmpty(tbScore.Text))
            {
                MessageBox.Show("Potrebno je unijeti bodove.");
                return;
            }
            string result = srvm.UpdateSwimmerRace(tbResult.Text, tbScore.Text);
            MessageBox.Show(result);
            this.Close();
        }
    }
}
