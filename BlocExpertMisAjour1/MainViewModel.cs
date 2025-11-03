using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocExpertMisAjour1
{
    public class MainViewModel
    {
        public MedecinViewModel MedecinAvecData { get; set; }
        public MedecinViewModel MedecinSansData { get; set; }

        public MainViewModel()
        {
            MedecinAvecData = new MedecinViewModel
            {
                Nom = "Poulain",
                Prenom = "Stéphane",
                Adresse = "10 Rue du Médecin, 78000 Versailles"
            };

            MedecinSansData = new MedecinViewModel(); // vide
        }
    }
}
