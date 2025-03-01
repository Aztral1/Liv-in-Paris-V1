﻿using System;

using System.Collections.Generic;

using System.IO;

using SkiaSharp;

using SkiaSharp.Views.Desktop;

class Program
{
    static void Main(string[] args)
    {
        Graphe graphe = new Graphe();
        string cheminfichier = "C:\\Users\\ywmoy\\OneDrive\\Documents\\ESILV\\Année 2\\Pb scien info\\Association-soc-karate\\soc-karate.mtx"; // Remplace par le chemin réel du fichier

        graphe.ReadFile(cheminfichier);
        graphe.Matrice_Adjacence();

        Console.WriteLine("Matrice d'adjacence :");
        graphe.AfficherMatriceAdjacence();

        Console.WriteLine("Parcours en largeur (BFS) à partir du sommet 1 :");
        graphe.BFS(1);

        Console.WriteLine("Parcours en profondeur (DFS) à partir du sommet 1 :");
        graphe.DFS(1);

        Console.WriteLine("Le graphe est-il connexe ? " + (graphe.EstConnecté() ? "Oui" : "Non"));
        Console.WriteLine("Le graphe contient-il un cycle ? " + (graphe.Cycleoupas() ? "Oui" : "Non"));
        Console.WriteLine("Ordre du graphe (nombre de sommets) : " + graphe.Ordre());
        Console.WriteLine("Taille du graphe (nombre d’arêtes) : " + graphe.Taille());
        string cheminImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "graphe.png");
        graphe.DessinerGrapheAvecSkiaSharp(cheminImage);


    }
}
