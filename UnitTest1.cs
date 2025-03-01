using Xunit;
using LivinParisVfinale;

public class TestUnitaire
{
    [Fact]
    public void AjouteNoeud()
    {
        ///Initialise un graphe
        Graphe graphe = new Graphe();
        graphe.AjouteNoeud(1);
        Assert.Equal(1, graphe.Ordre()); /// Vérifie que l'ordre du graphe est 1 càd si il y a un noeud
    }
    [Fact]
    public void AjouteLien()
    {
        ///Initialise un graphe
        Graphe graphe = new Graphe();
        graphe.AjouteNoeud(1);
        graphe.AjouteNoeud(2);
        graphe.AjouteLien(1, 2);
        Assert.Equal(1, graphe.Taille()); /// Vérifie que la taille du graphe est 1 càd si le lien est bien créé
    }
    [Fact]
    public void EstConnecté()
    {
        ///Nouveau grapphe
        Graphe graphe = new Graphe();
        graphe.AjouteNoeud(1);
        graphe.AjouteNoeud(2);
        graphe.AjouteLien(1, 2); ///Lie les deux noeuds
        bool estConnecté = graphe.EstConnecté();
        ///Doit retourner true
        Assert.True(estConnecté);
    }
    [Fact]
    public void Cycleoupas1()
    {   ///Cas avec cycle
        ///Initialise un graphe
        var graphe = new Graphe();
        graphe.AjouteNoeud(1);
        graphe.AjouteNoeud(2);
        graphe.AjouteNoeud(3);
        graphe.AjouteLien(1, 2);
        graphe.AjouteLien(2, 3);
        graphe.AjouteLien(3, 1); ///Avec cycle
        bool aUnCycle = graphe.Cycleoupas();
        ///Doit retourner true
        Assert.True(aUnCycle);
    }

    [Fact]
    public void Cycleoupas2()
    {///Cas sans cycle
        var graphe = new Graphe();///Initialise un graphe
        graphe.AjouteNoeud(1);
        graphe.AjouteNoeud(2);
        graphe.AjouteLien(1, 2); /// Sans cycle

        bool aUnCycle = graphe.Cycleoupas();

        ///Doit retourner false
        Assert.False(aUnCycle);
    }
    [Fact]
    public void Adjacents1()
    {
        int idNoeud = 1;
        var noeud = new Noeud(idNoeud); ///Construit un noeud
        Assert.Equal(idNoeud, noeud.IdNoeud); /// Vérifie que l'identifiant est correct
        Assert.NotNull(noeud.Adjacents); /// Vérifie que la liste des adjacents est initialisée
        Assert.Empty(noeud.Adjacents); /// Vérifie que la liste des adjacents est vide au départ
    }
    [Fact]
    public void Adjacents2()
    {
        ///Initialise deux noeuds adjacents
        Noeud noeud1 = new Noeud(1);
        Noeud noeud2 = new Noeud(2);
        noeud1.Adjacents.Add(noeud2);
        Assert.Single(noeud1.Adjacents); /// Vérifie qu'il y a un seul nœud adjacent
        Assert.Equal(noeud2, noeud1.Adjacents[0]); /// Vérifie que le nœud adjacent est correct
    }
    [Fact]
    public void Constructeur_DoitInitialiserNoeud1EtNoeud2()
    {
        int noeud1Id = 1;
        int noeud2Id = 2;
        Lien lien = new Lien(noeud1Id, noeud2Id);

        Assert.Equal(noeud1Id, lien.Noeud1); /// Vérifie que Noeud1 est correct
        Assert.Equal(noeud2Id, lien.Noeud2); /// Vérifie que Noeud2 est correct
    }
    [Fact]
    public void Lien_DoitEtreEgalSiNoeudsIdentiques()
    {
        ///Cas noeuds identiques
        ///Construit deux liens
        Lien lien1 = new Lien(1, 2);
        Lien lien2 = new Lien(1, 2);
        Assert.Equal(lien1.Noeud1, lien2.Noeud1); /// Vérifie que Noeud1 est égal
        Assert.Equal(lien1.Noeud2, lien2.Noeud2); /// Vérifie que Noeud2 est égal
    }
    [Fact]
    public void Lien_DoitEtreDifferentSiNoeudsDifferents()
    {   ///Cas noeuds différents
        ///Construit deux liens
        Lien lien1 = new Lien(1, 2);
        Lien lien2 = new Lien(2, 3);
        Assert.NotEqual(lien1.Noeud1, lien2.Noeud1); /// Vérifie que Noeud1 est différent
        Assert.NotEqual(lien1.Noeud2, lien2.Noeud2); /// Vérifie que Noeud2 est différent
    }
}
