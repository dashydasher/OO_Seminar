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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for RekordiPage.xaml
    /// </summary>
    public partial class RekordiPage : Page
    {
        public List<Record> records = new List<Record>();
        RecordViewModel rvm = new RecordViewModel();

        public RekordiPage(string _value)
        {
            InitializeComponent();


            var gender = _value.Trim().ToLower();
            rvm.LoadRecordsByGender(gender);
            this.DataContext = rvm;
        }

        public RekordiPage(List<Record> rekordi)
        {
            InitializeComponent();
            records.AddRange(rekordi);
        }
    }
}
