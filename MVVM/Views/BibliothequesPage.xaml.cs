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
    /// Logique d'interaction pour BibliothequesPage.xaml
    /// </summary>
    public partial class BibliothequesPage : Page
    {
        public MesLivresPage mesLivresPage;
        public ALirePage aLirePage;
        public EnCoursPage enCoursPage;
        public LuPage luPage;
        public WishlistPage wishlistPage;
        
        public BibliothequesPage()
        {
            InitializeComponent();
            mesLivresPage = new MesLivresPage();
            aLirePage = new ALirePage();
            enCoursPage = new EnCoursPage();
            luPage = new LuPage();
            wishlistPage = new WishlistPage();
          

        }
        private void MesLivresClickPage(object sender, RoutedEventArgs e)
        {
            HomePage.Instance.Page.Navigate(mesLivresPage);
        }
        private void ALirePage(object sender, RoutedEventArgs e)
        {
            HomePage.Instance.Page.Navigate(aLirePage);
            
        }
        private void EnCoursPage(object sender, RoutedEventArgs e)
        {
            HomePage.Instance.Page.Navigate(enCoursPage);
        }
        private void LuPage(object sender, RoutedEventArgs e)
        {
            HomePage.Instance.Page.Navigate(luPage);
        }
        private void WishlistPage(object sender, RoutedEventArgs e)
        {
            HomePage.Instance.Page.Navigate(wishlistPage);
        }
    }
}
