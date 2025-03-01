using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivinParisVfinale
{   /// Représente un nœud dans un graphe.
    public class Noeud
    {
        /// Identifiant unique du nœud.
        public int IdNoeud { get; set; }
        /// Liste des nœuds adjacents.
        public List<Noeud> Adjacents { get; set; } = new List<Noeud>();
        /// Constructeur pour créer un nœud avec un identifiant donné.
        public Noeud(int idnoeud)
        {
            IdNoeud = idnoeud;
        }
    }
}
