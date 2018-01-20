using Plivanje.Models;
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

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Utrke : Window
    {
    

        public List<Race> races = new List<Race>();
        RaceViewModel rvm = new RaceViewModel();
        public Utrke(Competition competition)
        {
            InitializeComponent();
            rvm.LoadRacesByCompetition(competition.Name);
            this.DataContext = rvm;
        }

    }
}
