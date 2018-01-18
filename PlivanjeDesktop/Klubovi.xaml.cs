using System.Collections.Generic;
using Plivanje.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PlivanjeDesktop.ViewModels;

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for Klubovi.xaml
    /// </summary>
    public partial class Klubovi : Window
    {
        private List<Club> clubs = new List<Club>();
        int id = 0;

        public Klubovi()
        {
            InitializeComponent();

            var clubViewModel = new ClubViewModel();
            clubViewModel.LoadClubs(id);
            this.DataContext = clubViewModel;
        }
        public Klubovi(int idd, string role)
        {
            InitializeComponent();

            id = idd;
            var clubViewModel = new ClubViewModel();
            clubViewModel.LoadClubs(id);
            this.DataContext = clubViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            var grid = sender as Button;
        }
        
    }

}
