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

namespace Books.MVVM.Views
{
    /// <summary>
    /// Logique d'interaction pour BibliothequesPage.xaml
    /// </summary>
    public partial class BibliothequesPage : Page
    {


        public MesLivresPage mesLivresPage;
        public BibliothequesPage()
        {
            InitializeComponent();
            mesLivresPage = new MesLivresPage();


        }
        private void MesLivresClickPage(object sender, RoutedEventArgs e)
        {
            HomePage.Instance.Page.Navigate(mesLivresPage);
        }

    }
}
