using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using Syncfusion.Windows.Shared;

namespace Books.MVVM.Views
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : ChromelessWindow
    {
        public MainViewModel GetDataContext()
        {
            return this.DataContext as MainViewModel;
        }

        public static HomePage Instance
        {
            get;
            set;
        }
        public HomePage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Instance=this;
        }

        private void BibliothequesClickPage(object sender, RoutedEventArgs e)
        {
            Page.Navigate(new BibliothequesPage());
        }

        private void ChercherClickPage(object sender, RoutedEventArgs e)
        {
            Page.Navigate(new ChercherPage());
        }

        private void Page_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is ChercherPage)
            {
                GetDataContext().OnObjectUpdated("Books");
                Debug.WriteLine("Update books");
            }
            if (e.Content is MesLivresPage)
            {
                GetDataContext().OnObjectUpdated("MesLivresBooks");
                Debug.WriteLine("Update my books");
            }
        }
    }
}
