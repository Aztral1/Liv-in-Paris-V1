using System;
using System.Collections.Generic;
using System.IO;

class Node
{
    public int Id { get; set; }
    public List<Node> Neighbors { get; set; } = new List<Node>();

    public Node(int id)
    {
        Id = id;
    }
}

class Graph
{
    private Dictionary<int, Node> nodes = new Dictionary<int, Node>();
    private int[,] adjacencyMatrix;

    public void AddNode(int id)
    {
        if (!nodes.ContainsKey(id))
            nodes[id] = new Node(id);
    }

    public void AddEdge(int id1, int id2)
    {
        if (nodes.ContainsKey(id1) && nodes.ContainsKey(id2))
        {
            nodes[id1].Neighbors.Add(nodes[id2]);
            nodes[id2].Neighbors.Add(nodes[id1]);
        }
    }

    public void BuildAdjacencyMatrix()
    {
        int size = nodes.Count;
        adjacencyMatrix = new int[size, size];
        foreach (var node in nodes.Values)
        {
            foreach (var neighbor in node.Neighbors)
            {
                adjacencyMatrix[node.Id - 1, neighbor.Id - 1] = 1;
                adjacencyMatrix[neighbor.Id - 1, node.Id - 1] = 1;
            }
        }
    }

    public void BFS(int start)
    {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int nodeId = queue.Dequeue();
            Console.Write(nodeId + " ");
            foreach (var neighbor in nodes[nodeId].Neighbors)
            {
                if (!visited.Contains(neighbor.Id))
                {
                    visited.Add(neighbor.Id);
                    queue.Enqueue(neighbor.Id);
                }
            }
        }
        Console.WriteLine();
    }

    public void DFS(int start)
    {
        HashSet<int> visited = new HashSet<int>();
        Stack<int> stack = new Stack<int>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            int nodeId = stack.Pop();
            if (!visited.Contains(nodeId))
            {
                Console.Write(nodeId + " ");
                visited.Add(nodeId);
                foreach (var neighbor in nodes[nodeId].Neighbors)
                {
                    stack.Push(neighbor.Id);
                }
            }
        }
        Console.WriteLine();
    }

    public void LoadFromFile(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("%") || line.StartsWith("%%"))
                    continue;

                string[] parts = line.Split(' ');
                if (parts.Length == 2)
                {
                    int node1 = int.Parse(parts[0]);
                    int node2 = int.Parse(parts[1]);

                    AddNode(node1);
                    AddNode(node2);
                    AddEdge(node1, node2);
                }
            }
        }
    }

    public bool IsConnected()
    {
        if (nodes.Count == 0) return false;

        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        int startNode = nodes.Keys.First();
        queue.Enqueue(startNode);
        visited.Add(startNode);

        while (queue.Count > 0)
        {
            int nodeId = queue.Dequeue();
            foreach (var neighbor in nodes[nodeId].Neighbors)
            {
                if (!visited.Contains(neighbor.Id))
                {
                    visited.Add(neighbor.Id);
                    queue.Enqueue(neighbor.Id);
                }
            }
        }

        return visited.Count == nodes.Count;
    }


    public bool HasCycle()
    {
        HashSet<int> visited = new HashSet<int>();

        foreach (var node in nodes.Keys)
        {
            if (!visited.Contains(node) && HasCycleDFS(node, visited, -1))
            {
                return true;
            }
        }
        return false;
    }

    private bool HasCycleDFS(int current, HashSet<int> visited, int parent)
    {
        visited.Add(current);

        foreach (var neighbor in nodes[current].Neighbors)
        {
            if (!visited.Contains(neighbor.Id))
            {
                if (HasCycleDFS(neighbor.Id, visited, current))
                    return true;
            }
            else if (neighbor.Id != parent) // Si le voisin est déjà visité mais n'est pas le parent, il y a un cycle
            {
                return true;
            }
        }
        return false;
    }


    public int GetOrder()
    {
        return nodes.Count;
    }


    public int GetSize()
    {
        int count = 0;
        foreach (var node in nodes.Values)
        {
            count += node.Neighbors.Count;
        }
        return count / 2; // Chaque arête est comptée deux fois
    }

}



class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        string filePath = "C:\\Users\\ywmoy\\source\\repos\\Liv'in Paris VCamile\\Liv'in Paris VCamile\\bin\\Association-soc-karate.zip"; // Remplace par le chemin réel du fichier

        graph.LoadFromFile(filePath);
        graph.BuildAdjacencyMatrix();

        Console.WriteLine("Parcours en largeur (BFS) à partir du sommet 1 :");
        graph.BFS(1);

        Console.WriteLine("Parcours en profondeur (DFS) à partir du sommet 1 :");
        graph.DFS(1);

        Console.WriteLine("Le graphe est-il connexe ? " + (graph.IsConnected() ? "Oui" : "Non"));
        Console.WriteLine("Le graphe contient-il un cycle ? " + (graph.HasCycle() ? "Oui" : "Non"));
        Console.WriteLine("Ordre du graphe (nombre de sommets) : " + graph.GetOrder());
        Console.WriteLine("Taille du graphe (nombre d’arêtes) : " + graph.GetSize());

    }
}
