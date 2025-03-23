using Books.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.MVVM.ViewModels
{
    public partial class MainViewModel
    {
        /// <summary>
        /// Permesdfsdfsdfsdfsdf
        /// </summary>
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

                OnPropertyChanged(nameof(Books));

                CanAddBook = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour : {ex.Message}");
            }
        }

        private void OnClickToReadSearchCommand()
        {
            if (SelectedBook == null) return;

            try
            {
                using (var connection = new SQLiteConnection("Data Source=..\\..\\..\\database.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Livre SET ALire = 1 WHERE id_livre = @id";
                    command.Parameters.AddWithValue("@id", SelectedBook.Id);

                    command.ExecuteNonQuery();
                }

                // Mettre à jour localement
                SelectedBook.ALire = true;
                LoadALireData(); // Recharger la liste
                CanAddToReadBook = false;  // Désactiver le bouton
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour : {ex.Message}");
            }
        }

        private ObservableCollection<Book> LoadData()
        {
            Debug.WriteLine("Load books from db");

            try
            {
                using (var connection = new SQLiteConnection("Data Source=..\\..\\..\\database.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    $@"
                      
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
                Livre.Alire AS ALire,
                Livre.Note AS Note
                FROM Livre
                JOIN Auteur ON Livre.id_Auteur = Auteur.id_Auteur
                JOIN Genre ON Livre.id_genre = Genre.id_genre
                JOIN Edition ON Livre.id_edition = Edition.id_edition
                WHERE Livre.titre LIKE '%{BooksFilter}%' OR Auteur.Nom LIKE '%{BooksFilter}%' OR Auteur.Prenom LIKE '%{BooksFilter}%'";

                    var Books = new ObservableCollection<Book>(); // On vide la liste pour éviter les doublons

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string auteurComplet = $"{reader["AuteurPrenom"]} {reader["AuteurNom"]}";
                            string editionComplet = $"{reader["EditionNom"]} {reader["EditionAnnee"]}";

                            Books.Add(new Book
                            {
                                Id = Convert.ToInt32(reader["LivreId"]),
                                Titre = reader["LivreTitre"].ToString(),
                                Auteur = auteurComplet,
                                Genre = reader["GenreNom"].ToString(),
                                Edition = editionComplet,
                                Note = reader["Note"] != DBNull.Value ? Convert.ToDouble(reader["Note"]) : (double?)null,
                                Prix = reader["prix"] != DBNull.Value ? Convert.ToSingle(reader["prix"]) : 0f,
                                Page = reader["page"] != DBNull.Value ? Convert.ToInt32(reader["page"]) : 0,
                                Lu = Convert.ToBoolean(reader["Lu"]),
                                Encours = Convert.ToBoolean(reader["Encours"]),
                                Whishlist = Convert.ToBoolean(reader["Whishlist"]),
                                MesLivres = Convert.ToBoolean(reader["MesLivres"]),
                                ALire = Convert.ToBoolean(reader["ALire"])
                            });
                        }
                    }

                    return Books;
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception et éventuellement afficher un message d'erreur
                Console.WriteLine($"Erreur lors du chargement des données : {ex.Message}");
            }

            return new ObservableCollection<Book>();
        }


        private ObservableCollection<Book> LoadMesLivresData()
        {
            Console.WriteLine("Load my books from db");

            try
            {
                var MesLivresBooks = new ObservableCollection<Book>(); // On vide la liste pour éviter les doublons

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
                Livre.Alire AS ALire,
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
                                Lu = Convert.ToBoolean(reader["Lu"]),
                                Encours = Convert.ToBoolean(reader["Encours"]),
                                Whishlist = Convert.ToBoolean(reader["Whishlist"]),
                                MesLivres = Convert.ToBoolean(reader["MesLivres"]),
                                ALire = Convert.ToBoolean(reader["ALire"])
                            });
                        }
                    }
                }

                return MesLivresBooks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des données : {ex.Message}");
            }

            return new ObservableCollection<Book>();
        }

        private void LoadALireData()
        {
            try
            {
                ALireBooks.Clear(); // On vide la liste pour éviter les doublons

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
                Livre.Alire AS ALire,
                Livre.Note AS Note 
            FROM Livre
            JOIN Auteur ON Livre.id_Auteur = Auteur.id_Auteur
            JOIN Genre ON Livre.id_genre = Genre.id_genre
            JOIN Edition ON Livre.id_edition = Edition.id_edition
            WHERE Livre.ALire = 1"; // Sélectionne seulement les livres dans "Mes Livres"

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string auteurComplet = $"{reader["AuteurPrenom"]} {reader["AuteurNom"]}";
                            string editionComplet = $"{reader["EditionNom"]} {reader["EditionAnnee"]}";

                            ALireBooks.Add(new Book
                            {
                                Id = Convert.ToInt32(reader["LivreId"]),
                                Titre = reader["LivreTitre"].ToString(),
                                Auteur = auteurComplet,
                                Genre = reader["GenreNom"].ToString(),
                                Edition = editionComplet,
                                Note = reader["Note"] != DBNull.Value ? Convert.ToDouble(reader["Note"]) : (double?)null,
                                Prix = reader["prix"] != DBNull.Value ? Convert.ToSingle(reader["prix"]) : 0f,
                                Page = reader["page"] != DBNull.Value ? Convert.ToInt32(reader["page"]) : 0,
                                Lu = Convert.ToBoolean(reader["Lu"]),
                                Encours = Convert.ToBoolean(reader["Encours"]),
                                Whishlist = Convert.ToBoolean(reader["Whishlist"]),
                                MesLivres = Convert.ToBoolean(reader["MesLivres"]),
                                ALire = Convert.ToBoolean(reader["ALire"])
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

        public static void UpdateRating(Book book)
        {
            //sdfsd
        }
    }
}
