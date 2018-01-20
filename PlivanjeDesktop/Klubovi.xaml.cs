using System.Collections.Generic;
using Plivanje.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PlivanjeDesktop.ViewModels;
using System.Windows.Data;
using System.Data;
using System.Windows.Media;

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

            //var buttonTemplate = new FrameworkElementFactory(typeof(Button));
            //buttonTemplate.Name = "plivačiButton";
            //buttonTemplate.Text = "Popis plivača";
            
            //buttonTemplate.AddHandler(
            //    Button.ClickEvent,
            //    new RoutedEventHandler((o, e) => MessageBox.Show("hi"))
            //);
            //datagrid.Columns.Add(new DataGridTextColumn { Header = "Ime kluba", Binding = new Binding("Name") });
            //datagrid.Columns.Add(new DataGridTextColumn { Header = "Adresa kluba", Binding = new Binding("Address") });
            //datagrid.Columns.Add(new DataGridTextColumn { Header = "Mjesto", Binding = new Binding("Place.Name") });
            //datagrid.Columns.Add(new DataGridHyperlinkColumn { Header = "", Binding = new Binding("Place") });
            //datagrid.Columns.Add(new DataGridTemplateColumn { CellTemplate = new DataTemplate() { VisualTree= buttonTemplate } } );
            


        }
        public Klubovi(int id, string role)
        {
            InitializeComponent();
            
            var clubViewModel = new ClubViewModel();
            clubViewModel.LoadClubs(id);
            this.DataContext = clubViewModel;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var clubId = datagrid.SelectedIndex;
            if (clubId >= 0)
            {
                var selectedClub = clubViewModel.clubs.GetRange(clubId, 1)[0];
                Plivači pl = new Plivači(selectedClub);
                pl.Show();
                this.Close();
            }
        }

        



    }

}
