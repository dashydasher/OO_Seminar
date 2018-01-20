using System.Collections.Generic;
using Plivanje.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PlivanjeDesktop.ViewModels;
using System.Windows.Data;
using System.Data;
using System.Windows.Media;
using System;

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for Klubovi.xaml
    /// </summary>
    public partial class Klubovi : Window
    {
        private List<Club> clubs = new List<Club>();
        
        ClubViewModel clubViewModel;

        public Klubovi()
        {
            InitializeComponent();

            clubViewModel = new ClubViewModel();
            clubViewModel.LoadClubs();
            this.DataContext = clubViewModel;
            

        }
        public Klubovi(int id, string role)
        {
            InitializeComponent();
            
            var clubViewModel = new ClubViewModel();
            clubViewModel.LoadClubs();
            clubViewModel.LoadCoachesClub(id);
            trenerKlub.Visibility = Visibility.Visible;
            this.DataContext = clubViewModel;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var clubId = datagrid.SelectedIndex;
            if (clubId >= 0)
            {
                try
                {
                    var selectedClub = clubViewModel.clubs.GetRange(clubId, 1)[0];
                    Plivači pl = new Plivači(selectedClub);
                    pl.Show();
                    this.Close();
                }
                catch (Exception exc) { }
            }
        }

        



    }

}
