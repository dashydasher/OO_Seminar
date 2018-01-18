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
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

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
           

        }

        private void Clubs_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Klubovi k = new Klubovi();
            k.Show();
            

        }

        private void Swimmers_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            Plivači p = new Plivači(mi.Header.ToString());
            p.Show();
           

        }

        private void Records_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            Rekordi r = new Rekordi(mi.Header.ToString());
            r.Show();
           

        }

    }
}
