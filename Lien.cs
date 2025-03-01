using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// Représente un lien entre deux nœuds dans un graphe.
namespace LivinParisVfinale
{
    public class Lien
    {
        /// Identifiant du premier nœud    
        public int Noeud1 { get; set; }
        /// Identifiant du deuxième nœud.
        public int Noeud2 { get; set; }
        public Lien(int noeud1, int noeud2)
        {
            Noeud1 = noeud1;
            Noeud2 = noeud2;
        }
    }
}
