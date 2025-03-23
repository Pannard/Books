using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.MVVM.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Genre { get; set; }
        public string Edition { get; set; } // Edition complète (nom + année)
        public int Page { get; set; }
        public float Prix { get; set; }
        public double? Note { get; set; } // Nullable double pour la note
        public int Lu { get; set; }
        public int Encours { get; set; }
        public int Whishlist { get; set; }
        public int MesLivres { get; set; }

        public int ALire { get; set; }
       
    }
}
