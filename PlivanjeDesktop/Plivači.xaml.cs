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
    /// Interaction logic for Plivači.xaml
    /// </summary>
    public partial class Plivači : Window
    {

        public List<Swimmer> swimmers = new List<Swimmer>();

        public Plivači(string _value)
        {
            InitializeComponent();
            SwimmerViewModel svm = new SwimmerViewModel();
            var categoryName = _value.Trim().ToLower();
            svm.LoadSwimmers(categoryName);
            this.DataContext = svm;
        }

        //treba riješiti sa SwimmerViewModel
        public Plivači(List<Swimmer> plivači)
        {
            InitializeComponent();
            swimmers.AddRange(plivači);
        }
        

    }
}
