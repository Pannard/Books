using Books.MVVM.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.MVVM.Models
{
    public class Book : ObservableObject
    {

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Genre { get; set; }
        public string Edition { get; set; } // Edition complète (nom + année)
        public int Page { get; set; }
        public float Prix { get; set; }
        public double? Note { get; set; } // Nullable double pour la note
        public double? NewNote 
        {
            get => Note;
            set
            {
                Note = value;
                MainViewModel.UpdateRating(this);
            }
        } // Nullable double pour la note
        public bool Lu { get; set; }
        public bool Encours { get; set; }
        public bool Whishlist { get; set; }
        public bool MesLivres { get; set; }

        public bool ALire { get; set; }
    }
}
