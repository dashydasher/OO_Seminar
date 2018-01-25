using Plivanje.Processors;
using PlivanjeDesktop.Models;
using PlivanjeDesktop.ViewModels;
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

namespace PlivanjeDesktop.Views
{
    /// <summary>
    /// Interaction logic for PlivačiUtrka.xaml
    /// </summary>
    public partial class PlivačiUtrka : Window
    {
        SwimmerRaceViewModel svm = new SwimmerRaceViewModel();
        public PlivačiUtrka(int raceId)
        {
            InitializeComponent();
            svm.LoadSwimmers(raceId);
            this.DataContext = svm;
        }

        private void Button_Prijavi_Click(object sender, RoutedEventArgs e)
        {
            SwimmerModel selectedSwimmer = (SwimmerModel)datagridSwimmers.SelectedItem;
            var success = svm.addSwimmerToRace(selectedSwimmer.Id);
            if (!success)
            {
                MessageBox.Show("Nije moguće prijaviti plivača. Provjerite poklapa li se spol i kategorija plivača sa spolom i kategorijom utrke.");
                return;
            }

            //Ovo je grozno, popravit ak se može
            PlivačiUtrka pu = new PlivačiUtrka(svm.raceId);
            pu.Show();
            this.Close();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
