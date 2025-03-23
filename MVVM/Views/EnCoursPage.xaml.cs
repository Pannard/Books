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
using Books.MVVM.ViewModels;

namespace Books.MVVM.Views
{
    /// <summary>
    /// Logique d'interaction pour EnCoursPage.xaml
    /// </summary>
    public partial class EnCoursPage : Page
    {
        public InfoPage infoPage;
        public EnCoursPage()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            infoPage = new InfoPage();
        }

        private void InfosPage(object sender, RoutedEventArgs e)
        {
            HomePage.Instance.Page.Navigate(infoPage);
        }
    }
}
