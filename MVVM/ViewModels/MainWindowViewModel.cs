using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using Books.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Books.MVVM.ViewModels
{

    
    public partial class MainViewModel : ObservableObject
    {
        #region variable

        public string BooksFilter 
        { 
            get => booksFilter;
            set
            {
                SetProperty(ref booksFilter, value);
                OnPropertyChanged(nameof(Books));
                Debug.WriteLine("Filter changed");
            }
        }


        private Book selectedBook;
        public Book SelectedBook

        {
            get => selectedBook;
            set
            {
                SetProperty(ref selectedBook, value);
                CanAddBook = (value != null && !value.MesLivres);
                CanAddToReadBook = (value != null && !value.ALire);
            }
        }

        public void OnObjectUpdated(string propertyName = "") => OnPropertyChanged(propertyName);


        public ObservableCollection<Book> Books { get => LoadData(); }
        public ObservableCollection<Book> MesLivresBooks 
        {
            get => LoadMesLivresData();
        }

        public ObservableCollection<Book> ALireBooks { get; set; }

        private ObservableCollection<Book> addedBooks;
        public ObservableCollection<Book> AddedBooks
        {
            get => addedBooks;
            set
            {
                SetProperty(ref addedBooks, value);
            }
        }


        private bool canAddBook = false;
        public bool CanAddBook
        {
            get => canAddBook;
            set
            {
                SetProperty(ref canAddBook, value);
                OnClickSearch.NotifyCanExecuteChanged();
            }
        }


        private ObservableCollection<Book> toReadBooks;
        public ObservableCollection<Book> ToReadBooks
        {
            get => toReadBooks;
            set
            {
                SetProperty(ref toReadBooks, value);
            }
        }


        private bool canAddToReadBook = false;
        private ObservableCollection<Book> mesLivresBooks;
        private string booksFilter;

        public bool CanAddToReadBook
        {
            get => canAddToReadBook;
            set
            {
                SetProperty(ref canAddToReadBook, value);
                OnClickToReadSearch.NotifyCanExecuteChanged();
            }
        }


        #endregion

        #region Command


        private bool CanExecuteAddBook()
        {
            return CanAddBook;
        }

        private bool CanExecuteAddToReadBook()
        {
            return CanAddToReadBook;
        }

        public RelayCommand OnClickToReadSearch { get; }
        public RelayCommand OnClickSearch { get; }

        
        #endregion

        #region Constructor


        public MainViewModel()
        {
            AddedBooks = new ObservableCollection<Book>();
            toReadBooks = new ObservableCollection<Book>();
            ALireBooks = new ObservableCollection<Book>();
            OnClickSearch = new RelayCommand(OnClickSearchCommand, CanExecuteAddBook);
            OnClickToReadSearch = new RelayCommand(OnClickToReadSearchCommand, CanExecuteAddToReadBook);

            LoadALireData();
        }
        #endregion
    }

}

