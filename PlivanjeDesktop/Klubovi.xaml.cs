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
        ClubViewModel clubViewModel;

        public Klubovi()
        {
            InitializeComponent();

            clubViewModel = new ClubViewModel();
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

        //private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var lv = sender as TextBlock;
        //    var curItem = ((ListBoxItem)listView.ContainerFromElement((TextBlock)sender));
        //    listView.SelectedItem = (ListBoxItem)curItem;
        //    MessageBox.Show($"Selected index = {listView.SelectedIndex}");
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var grid = sender as Button;
            var gv = grid.Parent as GridView;
            
            var curItem = ((ListBoxItem)listView.ContainerFromElement((Button)sender));
            listView.SelectedItem = (ListBoxItem)curItem;

            var selectedClub = clubViewModel.clubs.GetRange(listView.SelectedIndex, 1)[0];
            var svm = new SwimmerViewModel();
            var plivači = svm.LoadSwimmersByClub(selectedClub.Id);
            Plivači pl = new Plivači(plivači);
            pl.Show();
            this.Close();
        }



    }

}
