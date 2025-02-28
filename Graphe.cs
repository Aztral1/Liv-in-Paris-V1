using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Graphe
{
    private Dictionary<int, Noeud> noeuds = new Dictionary<int, Noeud>();
    private int[,] Matriceadjacence;

    public void AjouteNoeud(int id)
    {
        if (!noeuds.ContainsKey(id))
            noeuds[id] = new Noeud(id);
    }

    public void AjouteLien(int id1, int id2)
    {
        if (noeuds.ContainsKey(id1) && noeuds.ContainsKey(id2))
        {
            noeuds[id1].Adjacents.Add(noeuds[id2]);
            noeuds[id2].Adjacents.Add(noeuds[id1]);
        }
    }

    public void Matrice_Adjacence()
    {
        int size = noeuds.Count;
        Matriceadjacence = new int[size, size];
        foreach (var noeud in noeuds.Values)
        {
            foreach (var adjacent in noeud.Adjacents)
            {
                Matriceadjacence[noeud.Id - 1, adjacent.Id - 1] = 1;
                Matriceadjacence[adjacent.Id - 1, noeud.Id - 1] = 1;
            }
        }
    }

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
            foreach (var neighbor in noeuds[nodeId].Adjacents)
            {
                if (!parcouru.Contains(neighbor.Id))
                {
                    parcouru.Add(neighbor.Id);
                    queue.Enqueue(neighbor.Id);
                }
            }
        }
        Console.WriteLine();
    }

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
                    stack.Push(adjacent.Id);
                }
            }
        }
        Console.WriteLine();
    }

    public void ReadFile(string cheminfichier)
    {
        using (StreamReader sr = new StreamReader(cheminfichier))
        {
            string ligne;
            while ((ligne = sr.ReadLine()) != null)
            {
                if (ligne.StartsWith("%") || ligne.StartsWith("%%"))
                    continue;

                string[] parties = ligne.Split(' ');
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
                if (!parcouru.Contains(adjacent.Id))
                {
                    parcouru.Add(adjacent.Id);
                    queue.Enqueue(adjacent.Id);
                }
            }
        }

        return parcouru.Count == noeuds.Count;
    }

    public bool Cycleoupas()
    {
        HashSet<int> visited = new HashSet<int>();

        foreach (var node in noeuds.Keys)
        {
            if (!visited.Contains(node) && CycleDFS(node, visited, -1))
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
            if (!parcouru.Contains(adjacent.Id))
            {
                if (CycleDFS(adjacent.Id, parcouru, debut))
                    return true;
            }
            else if (adjacent.Id != parent) // Si le voisin est déjà visité mais n'est pas le parent, il y a un cycle
            {
                return true;
            }
        }
        return false;
    }

    public int Ordre()
    {
        return noeuds.Count;
    }

    public int Taille()
    {
        int count = 0;
        foreach (var node in noeuds.Values)
        {
            count += node.Adjacents.Count;
        }
        return count / 2; // Chaque arête est comptée deux fois
    }

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
}