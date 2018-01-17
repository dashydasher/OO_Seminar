using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plivanje.Models;
using Plivanje.Processors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Remotion.Linq.Collections;
using PlivanjeDesktop.ViewModels;

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for Klubovi.xaml
    /// </summary>
    public partial class Klubovi : Window
    {
        private ObservableCollection<Club> clubs = new ObservableCollection<Club>();

        public Klubovi()
        {
            InitializeComponent();

            var clubViewModel = new ClubViewModel();
            clubViewModel.LoadClubs();
            this.DataContext = clubViewModel;
        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            mi.IsSubmenuOpen = true;
        }

        private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            mi.IsSubmenuOpen = false;
        }

        private void Competition_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Natjecanja n = new Natjecanja();
            n.Show();
            this.Close();
        }

        private void Clubs_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Klubovi k = new Klubovi();
            k.Show();
            this.Close();
        }

        private void Swimmers_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            Plivači p = new Plivači(mi.Header.ToString());
            p.Show();
            this.Close();
        }

        private void Records_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            Rekordi r = new Rekordi(mi.Header.ToString());
            r.Show();
            this.Close();
        }

    }
}
