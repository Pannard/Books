using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows.Controls;
using Books.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Books.MVVM.ViewModels
{

    
    public class MainViewModel : ObservableObject
    {
        #region variable

        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Book> MesLivresBooks { get; set; }

        private ObservableCollection<Book> addedBooks;
        public ObservableCollection<Book> AddedBooks
        {
            get => addedBooks;
            set
            {
                SetProperty(ref addedBooks, value);
            }
        }

        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                SetProperty(ref selectedBook, value);
                CanAddBook = (value != null && value.MesLivres == 0);
            }
        }

        private bool canAddBook = false;
        public bool CanAddBook
        {
            get => canAddBook;
            set
            {
                if (SetProperty(ref canAddBook, value))
                {
                    OnClickSearch.NotifyCanExecuteChanged();
                }
            }
        }



        #endregion

        #region Command


        private bool CanExecuteAddBook()
        {
            return CanAddBook;
        }

        public RelayCommand OnClickSearch { get; }

        private void OnClickSearchCommand()
        {
            if (SelectedBook == null) return;

            try
            {
                using (var connection = new SQLiteConnection("Data Source=..\\..\\..\\database.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Livre SET MesLivres = 1 WHERE id_livre = @id";
                    command.Parameters.AddWithValue("@id", SelectedBook.Id);

                    command.ExecuteNonQuery();
                }

                // Mettre à jour localement
                SelectedBook.MesLivres = 1;
                LoadMesLivresData(); // Recharger la liste
                CanAddBook = false;  // Désactiver le bouton
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour : {ex.Message}");
            }
        }
        #endregion













        #region Constructor


        public MainViewModel()
        {
            Books = new ObservableCollection<Book>();
            MesLivresBooks = new ObservableCollection<Book>();
            AddedBooks = new ObservableCollection<Book>();

            OnClickSearch = new RelayCommand(OnClickSearchCommand, CanExecuteAddBook);

            LoadData();
            LoadMesLivresData();



        }
        #endregion
        private void LoadData()
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=..\\..\\..\\database.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
            SELECT 
                Livre.id_livre AS LivreId,
                Livre.titre AS LivreTitre, 
                Auteur.Nom AS AuteurNom, 
                Auteur.Prenom AS AuteurPrenom,
                Genre.nom AS GenreNom, 
                Edition.nom AS EditionNom,
                Edition.annee AS EditionAnnee,
                Livre.prix AS prix,
                Livre.page AS page,
                Livre.Lu AS Lu,
                Livre.Encours AS Encours,
                Livre.Whishlist AS Whishlist,
                Livre.MesLivres AS MesLivres,
                Livre.Note AS NoteLivre 
            FROM Livre
            JOIN Auteur ON Livre.id_Auteur = Auteur.id_Auteur
            JOIN Genre ON Livre.id_genre = Genre.id_genre
            JOIN Edition ON Livre.id_edition = Edition.id_edition
            ";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string auteurComplet = $"{reader["AuteurPrenom"]} {reader["AuteurNom"]}";
                            string EditionComplet = $"{reader["EditionNom"]} {reader["EditionAnnee"]}";

                            Books.Add(new Book
                            {
                                Id = Convert.ToInt32(reader["LivreId"]),
                                Titre = reader["LivreTitre"].ToString(),
                                Auteur = auteurComplet,
                                Genre = reader["GenreNom"].ToString(),
                                Edition = EditionComplet,
                                Note = reader["NoteLivre"] != DBNull.Value ? Convert.ToDouble(reader["NoteLivre"]) : (double?)null, // correction du nom
                                Prix = reader["prix"] != DBNull.Value ? Convert.ToSingle(reader["prix"]) : 0f,  // Gestion du cas où 'prix' est null
                                Page = reader["page"] != DBNull.Value ? Convert.ToInt32(reader["page"]) : 0,    // Gestion du cas où 'page' est null
                                Lu = reader["Lu"] != DBNull.Value ? Convert.ToInt32(reader["Lu"]) : 0,
                                Encours = reader["Encours"] != DBNull.Value ? Convert.ToInt32(reader["Encours"]) : 0,
                                Whishlist = reader["Whishlist"] != DBNull.Value ? Convert.ToInt32(reader["Whishlist"]) : 0,
                                MesLivres = reader["MesLivres"] != DBNull.Value ? Convert.ToInt32(reader["MesLivres"]) : 0
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception et éventuellement afficher un message d'erreur
                Console.WriteLine($"Erreur lors du chargement des données : {ex.Message}");
            }
        }




        private void LoadMesLivresData()
        {
            try
            {
                MesLivresBooks.Clear(); // On vide la liste pour éviter les doublons

                using (var connection = new SQLiteConnection("Data Source=..\\..\\..\\database.db"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
            SELECT 
                Livre.id_livre AS LivreId,
                Livre.titre AS LivreTitre, 
                Auteur.Nom AS AuteurNom, 
                Auteur.Prenom AS AuteurPrenom,
                Genre.nom AS GenreNom, 
                Edition.nom AS EditionNom,
                Edition.annee AS EditionAnnee,
                Livre.prix AS prix,
                Livre.page AS page,
                Livre.Lu AS Lu,
                Livre.Encours AS Encours,
                Livre.Whishlist AS Whishlist,
                Livre.MesLivres AS MesLivres,
                Livre.Note AS Note 
            FROM Livre
            JOIN Auteur ON Livre.id_Auteur = Auteur.id_Auteur
            JOIN Genre ON Livre.id_genre = Genre.id_genre
            JOIN Edition ON Livre.id_edition = Edition.id_edition
            WHERE Livre.MesLivres = 1"; // Sélectionne seulement les livres dans "Mes Livres"

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string auteurComplet = $"{reader["AuteurPrenom"]} {reader["AuteurNom"]}";
                            string editionComplet = $"{reader["EditionNom"]} {reader["EditionAnnee"]}";

                            MesLivresBooks.Add(new Book
                            {
                                Id = Convert.ToInt32(reader["LivreId"]),
                                Titre = reader["LivreTitre"].ToString(),
                                Auteur = auteurComplet,
                                Genre = reader["GenreNom"].ToString(),
                                Edition = editionComplet,
                                Note = reader["Note"] != DBNull.Value ? Convert.ToDouble(reader["Note"]) : (double?)null,
                                Prix = reader["prix"] != DBNull.Value ? Convert.ToSingle(reader["prix"]) : 0f,
                                Page = reader["page"] != DBNull.Value ? Convert.ToInt32(reader["page"]) : 0,
                                Lu = Convert.ToInt32(reader["Lu"]),
                                Encours = Convert.ToInt32(reader["Encours"]),
                                Whishlist = Convert.ToInt32(reader["Whishlist"]),
                                MesLivres = Convert.ToInt32(reader["MesLivres"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des données : {ex.Message}");
            }
        }

       
    }

}

