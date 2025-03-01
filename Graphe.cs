using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
/// Représente un graphe composé de nœuds et de liens.
public class Graphe
{
    private Dictionary<int, Noeud> noeuds = new Dictionary<int, Noeud>();
    private int[,] Matriceadjacence;

    /// Ajoute un nœud au graphe.
    public void AjouteNoeud(int id)
    {
        if (!noeuds.ContainsKey(id))
            noeuds[id] = new Noeud(id);
    }
    /// Ajoute un lien entre deux nœuds.
    public void AjouteLien(int id1, int id2)
    {
        if (noeuds.ContainsKey(id1) && noeuds.ContainsKey(id2))
        {
            noeuds[id1].Adjacents.Add(noeuds[id2]);
            noeuds[id2].Adjacents.Add(noeuds[id1]);
        }
    }
    /// Construit la matrice d'adjacence du graphe.
    public void Matrice_Adjacence()
    {
        int size = noeuds.Count;
        Matriceadjacence = new int[size, size];
        foreach (var noeud in noeuds.Values)
        {
            foreach (var adjacent in noeud.Adjacents)
            {
                Matriceadjacence[noeud.IdNoeud - 1, adjacent.IdNoeud - 1] = 1;
                Matriceadjacence[adjacent.IdNoeud - 1, noeud.IdNoeud - 1] = 1;
            }
        }
    }
    /// Parcours en largeur (BFS) à partir d'un nœud donné.
    public void BFS(int start)
    {
        HashSet<int> parcouru = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        parcouru.Add(start);

        while (queue.Count > 0)
        {
            int nodeId = queue.Dequeue();
            Console.Write(nodeId + " ");
            foreach (var adjacent in noeuds[nodeId].Adjacents)
            {
                if (!parcouru.Contains(adjacent.IdNoeud))
                {
                    parcouru.Add(adjacent.IdNoeud);
                    queue.Enqueue(adjacent.IdNoeud);
                }
            }
        }
        Console.WriteLine();
    }

    /// Parcours en profondeur (DFS) à partir d'un nœud 
    /// start est l'identifiant du nœud de départ
    public void DFS(int start)
    {
        HashSet<int> parcouru = new HashSet<int>();
        Stack<int> stack = new Stack<int>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            int Idnoeud = stack.Pop();
            if (!parcouru.Contains(Idnoeud))
            {
                Console.Write(Idnoeud + " ");
                parcouru.Add(Idnoeud);
                foreach (var adjacent in noeuds[Idnoeud].Adjacents)
                {
                    stack.Push(adjacent.IdNoeud);
                }
            }
        }
        Console.WriteLine();
    }

    /// Lit un fichier pour construire le graphe.
    public void ReadFile(string cheminfichier)
    {
        using (StreamReader sr = new StreamReader(cheminfichier))
        {
            string ligne;
            while ((ligne = sr.ReadLine()) != null)
            {
                if (ligne.StartsWith("%") || ligne.StartsWith("%%"))
                    continue;

                string[] parties = ligne.Split(' '); ///Sépare chaque ligne en une string
                if (parties.Length == 2)
                {
                    int noeud1 = int.Parse(parties[0]);
                    int noeud2 = int.Parse(parties[1]);

                    AjouteNoeud(noeud1);
                    AjouteNoeud(noeud2);
                    AjouteLien(noeud1, noeud2);
                }
            }
        }
    }

    /// Vérifie si le graphe est connexe.
    /// True si le graphe est connexe, sinon False
    public bool EstConnecté()
    {
        if (noeuds.Count == 0) return false;

        HashSet<int> parcouru = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        int Depart = noeuds.Keys.First();
        queue.Enqueue(Depart);
        parcouru.Add(Depart);

        while (queue.Count > 0)
        {
            int Idnoeud = queue.Dequeue();
            foreach (var adjacent in noeuds[Idnoeud].Adjacents)
            {
                if (!parcouru.Contains(adjacent.IdNoeud))
                {
                    parcouru.Add(adjacent.IdNoeud);
                    queue.Enqueue(adjacent.IdNoeud);
                }
            }
        }

        return parcouru.Count == noeuds.Count;
    }
    /// Vérifie si le graphe contient un cycle.
    /// <returns>True si le graphe contient un cycle, sinon False.</returns>
    public bool Cycleoupas()
    {
        HashSet<int> parcouru = new HashSet<int>();

        foreach (var noeud in noeuds.Keys)
        {
            if (!parcouru.Contains(noeud) && CycleDFS(noeud, parcouru, -1))
            {
                return true;
            }
        }
        return false;
    }

    private bool CycleDFS(int debut, HashSet<int> parcouru, int parent)
    {
        parcouru.Add(debut);

        foreach (var adjacent in noeuds[debut].Adjacents)
        {
            if (!parcouru.Contains(adjacent.IdNoeud))
            {
                if (CycleDFS(adjacent.IdNoeud, parcouru, debut))
                    return true;
            }
            else if (adjacent.IdNoeud != parent) /// Si le voisin est déjà visité mais n'est pas le parent, il y a un cycle
            {
                return true;
            }
        }
        return false;
    }
    /// Retourne l'ordre du graphe (nombre de nœuds).
    ///Nombre de nœuds dans le graphe
    public int Ordre()
    {
        return noeuds.Count;
    }
    /// Retourne la taille du graphe (nombre d'arêtes).
    /// retourne le nombre d'arêtes dans le graphe.
    public int Taille()
    {
        int count = 0;
        foreach (var node in noeuds.Values)
        {
            count += node.Adjacents.Count;
        }
        return count / 2; /// Chaque arête est comptée deux fois
    }

    /// Affiche la matrice d'adjacence du graphe.
    public void AfficherMatriceAdjacence()
    {
        if (Matriceadjacence == null)
        {
            Console.WriteLine("La matrice d'adjacence n'a pas été initialisée.");
            return;
        }

        int size = Matriceadjacence.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(Matriceadjacence[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void DessinerGrapheAvecSkiaSharp(string cheminImage)
    {
        int largeur = 1000; /// Augmenter la largeur pour plus d'espace
        int hauteur = 1000; /// Augmenter la hauteur pour plus d'espace
        

        /// Créer une surface SkiaSharp
        using (var surface = SKSurface.Create(new SKImageInfo(largeur, hauteur)))
        {
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White); // Fond blanc

            /// Définir un style pour les nœuds
            var paintNoeud = new SKPaint
            {
                Color = SKColors.LightBlue,
                IsAntialias = true,
                Style = SKPaintStyle.Fill
            };

            var paintTexte = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 24, /// Augmenter la taille du texte
                IsAntialias = true,
                TextAlign = SKTextAlign.Center
            };

            /// Définir un style pour les liens
            var paintLien = new SKPaint
            {
                Color = SKColors.Black,
                StrokeWidth = 2,
                IsAntialias = true,
                Style = SKPaintStyle.Stroke
            };

            /// Centre du cercle
            int centreX = largeur / 2;
            int centreY = hauteur / 2;
            int rayon = 400; /// Augmenter le rayon pour écarter les boules

            /// Calculer les positions des nœuds en cercle
            int nombreNoeuds = noeuds.Count;
            double angleIncrement = 2 * Math.PI / nombreNoeuds;

            /// Dictionnaire pour stocker les positions des nœuds
            Dictionary<int, SKPoint> positionsNoeuds = new Dictionary<int, SKPoint>();

            int index = 0;
            foreach (var noeud in noeuds.Values)
            {
                double angle = angleIncrement * index;
                int x = (int)(centreX + rayon * Math.Cos(angle));
                int y = (int)(centreY + rayon * Math.Sin(angle));

                /// Stocker la position du nœud
                positionsNoeuds[noeud.IdNoeud] = new SKPoint(x, y);

                index++;
            }

            /// Dessiner les liens
            foreach (var noeud in noeuds.Values)
            {
                var positionNoeud = positionsNoeuds[noeud.IdNoeud];

                foreach (var adjacent in noeud.Adjacents)
                {
                    var positionAdjacent = positionsNoeuds[adjacent.IdNoeud];

                    /// Dessiner une ligne entre les nœuds
                    canvas.DrawLine(positionNoeud, positionAdjacent, paintLien);
                }
            }

            /// Dessiner les nœuds
            foreach (var noeud in noeuds.Values)
            {
                var position = positionsNoeuds[noeud.IdNoeud];

                /// Dessiner un cercle pour le nœud (plus grand)
                canvas.DrawCircle(position, 30, paintNoeud); /// Augmenter le rayon des boules

                /// Ajouter l'identifiant du nœud (centré dans la boule)
                canvas.DrawText(noeud.IdNoeud.ToString(), position.X, position.Y + 8, paintTexte); /// Ajuster la position du texte
            }

            /// Enregistrer l'image dans un fichier
            using (var image = surface.Snapshot())
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = File.OpenWrite(cheminImage))
            {
                data.SaveTo(stream);
            }
        }

        /// Ouvrir l'image automatiquement
        Process.Start(new ProcessStartInfo(cheminImage) { UseShellExecute = true });
        Console.WriteLine($"Graphe dessiné et enregistré dans {cheminImage}");
    }
}
