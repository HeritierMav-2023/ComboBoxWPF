using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionExpanderTrue
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _selectedOption;
        private bool _isExpanded;

        public MainViewModel()
        {
            Options = new ObservableCollection<string> { "Aucun", "Autre" };
            SelectedOption = "Aucun";
            // On veut que l'expander soit ouvert par défaut pour "Aucun"
            IsExpanded = true;
        }

        public ObservableCollection<string> Options { get; }

        public string SelectedOption
        {
            get => _selectedOption;
            set
            {
                if (_selectedOption != value)
                {
                    _selectedOption = value;
                    OnPropertyChanged();
                    // si on change vers "Aucun", forcer l'expander ouvert
                    if (_selectedOption == "Aucun")
                        IsExpanded = true;
                }
            }
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string p = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
