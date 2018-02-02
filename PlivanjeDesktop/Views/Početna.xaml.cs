using PlivanjeDesktop.Models;
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

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Početna : Window
    {

        public static Početna referenca;
        public Početna()
        {
            InitializeComponent();

            if (UserModel.role == null)
            {
                Login.Visibility = Visibility.Visible;
            }

            referenca = this;

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
            NatjecanjaPage n = new NatjecanjaPage();
            Main.Content = n;            
        }

        private void Clubs_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            KluboviPage k = new KluboviPage();
            Main.Content = k;
        }

        private void Swimmers_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            PlivačiPage p = new PlivačiPage(mi.Header.ToString());
            Main.Content = p;
        }

        private void Records_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            RekordiPage r = new RekordiPage(mi.Header.ToString());
            Main.Content = r;
        }



        private void PrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            PrijavaPage p = new PrijavaPage();
            Main.Content = p;

        }

        private void OdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            UserModel.role = null;
            Logout.Visibility = Visibility.Collapsed;
            Login.Visibility = Visibility.Visible;
            PrijavaPage p = new PrijavaPage();
            Main.Content = p;
        }
    }
}
