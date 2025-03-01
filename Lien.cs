
/// Représente un lien entre deux nœuds dans un graphe.
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
