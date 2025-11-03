using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlocExpert
{
    public class MaViewModel : INotifyPropertyChanged
    {
        // ... autres propriétés et implémentation de INotifyPropertyChanged

        private string _medecinNom;
        private string _medecinPrenom;
        private string _medecinAdresse;

        // Propriété qui indique si les informations sont présentes (Nom, Prénom, Adresse)
        public bool HasMedecinDetails
        {
            get
            {
                // Retourne true si au moins le Nom, le Prénom OU l'Adresse sont non vides/non nulles
                // Ajustez la condition si vous exigez que TOUTES les informations soient remplies.
                return !string.IsNullOrWhiteSpace(_medecinNom) ||
                       !string.IsNullOrWhiteSpace(_medecinPrenom) ||
                       !string.IsNullOrWhiteSpace(_medecinAdresse);
            }
        }

        // Mettez à jour HasMedecinDetails (et notifiez l'UI) lors de la modification des propriétés dépendantes.
        public string MedecinNom
        {
            get => _medecinNom;
            set
            {
                if (_medecinNom != value)
                {
                    _medecinNom = value;
                    OnPropertyChanged(nameof(MedecinNom));
                    OnPropertyChanged(nameof(HasMedecinDetails)); // Notifier le changement pour la colonne
                }
            }
        }

        public string MedecinPrenom
        {
            get => _medecinPrenom;
            set
            {
                if (_medecinPrenom != value)
                {
                    _medecinPrenom = value;
                    OnPropertyChanged(nameof(MedecinPrenom));
                    OnPropertyChanged(nameof(HasMedecinDetails)); // Notifier le changement pour la colonne
                }
            }
        }

        public string MedecinAdresse
        {
            get => _medecinAdresse;
            set
            {
                if (_medecinAdresse != value)
                {
                    _medecinAdresse = value;
                    OnPropertyChanged(nameof(MedecinAdresse));
                    OnPropertyChanged(nameof(HasMedecinDetails)); // Notifier le changement pour la colonne
                }
            }
        }

        public MaViewModel()
        {
            //MedecinNom = "Poulain";
            //MedecinPrenom = "Jean";
            //MedecinAdresse = "10 Rue du Médecin, 78000 Versailles";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // ... Implémentation similaire pour MedecinPrenom et MedecinAdresse ...

        // Vous devrez appeler OnPropertyChanged(nameof(HasMedecinDetails)); chaque fois que les données changent.
    }
}
