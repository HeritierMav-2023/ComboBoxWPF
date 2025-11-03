using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BlocExpertMisAjour1
{
    public class MedecinViewModel : INotifyPropertyChanged
    {
        private string _nom;
        private string _prenom;
        private string _adresse;
        private bool _hasData;

        public string Nom
        {
            get => _nom;
            set { _nom = value; OnPropertyChanged(); UpdateHasData(); }
        }

        public string Prenom
        {
            get => _prenom;
            set { _prenom = value; OnPropertyChanged(); UpdateHasData(); }
        }

        public string Adresse
        {
            get => _adresse;
            set { _adresse = value; OnPropertyChanged(); UpdateHasData(); }
        }

        public bool HasData
        {
            get => _hasData;
            private set { _hasData = value; OnPropertyChanged(); }
        }

        private void UpdateHasData()
        {
            HasData = !string.IsNullOrWhiteSpace(Nom)
                   || !string.IsNullOrWhiteSpace(Prenom)
                   || !string.IsNullOrWhiteSpace(Adresse);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    /*
     Fonctionnement

    Tant que Nom, Prénom et Adresse sont vides → la grille rouge est cachée (Visibility.Collapsed).

    Dès qu’un champ contient une donnée → la grille devient visible.

    Tout repose sur le HasData du ViewModel, ce qui garde ton code clair et 100 % MVVM.
     */

    
}
