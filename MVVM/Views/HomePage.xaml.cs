using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {

        public BibliothequesPage bibliothequesPage;
        public ChercherPage chercherPage;
        public static HomePage Instance
        {
            get;
            set;
        }
        public HomePage()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            Instance=this;
            bibliothequesPage = new BibliothequesPage();
            chercherPage = new ChercherPage();
        }

        private void BibliothequesClickPage(object sender, RoutedEventArgs e)
        {
            Page.Navigate(bibliothequesPage);
        }

        private void ChercherClickPage(object sender, RoutedEventArgs e)
        {
            Page.Navigate(chercherPage);
        }



    }
}
