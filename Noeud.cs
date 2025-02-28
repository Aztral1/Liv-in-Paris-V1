using System.Collections.Generic;

public class Noeud
{
    public int Id { get; set; }
    public List<Noeud> Adjacents { get; set; } = new List<Noeud>();

    public Noeud(int id)
    {
        Id = id;
    }
}