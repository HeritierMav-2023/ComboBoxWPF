using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxWPF
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int IdCategorie { get; set; }

        // Nouvelle propriété affichée dans le DataGrid
        public string NomCategorie { get; set; }
    }

}
