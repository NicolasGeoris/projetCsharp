using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class Objet
    {
        private string nom;
        public string Nom { get => nom; set => nom = value; }

        public Objet(string nom)
        {
            this.nom = nom;
        }
    }
}
