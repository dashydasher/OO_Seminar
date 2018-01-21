﻿using Plivanje.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for KluboviPage.xaml
    /// </summary>
    public partial class KluboviPage : Page
    {
        private List<Club> clubs = new List<Club>();

        ClubViewModel clubViewModel;

        public KluboviPage()
        {
            InitializeComponent();

            clubViewModel = new ClubViewModel();
            clubViewModel.LoadClubs();
            this.DataContext = clubViewModel;


        }
        public KluboviPage(int id, string role)
        {
            InitializeComponent();

            var clubViewModel = new ClubViewModel();
            clubViewModel.LoadClubs();
            clubViewModel.LoadCoachesClub(id);
            this.DataContext = clubViewModel;
            trenerKlub.Visibility = Visibility.Visible;
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
                    PlivačiPage pl = new PlivačiPage(selectedClub);
                    NavigationService navService = NavigationService.GetNavigationService(this);
                    navService.Navigate(pl);

                }
                catch (Exception exc) { }
            }
        }


    }
}
