using System;
using System.Collections.Generic;

// Grafo
class Graph
{
    //cria dicionario com ajacencias
    public Dictionary<string, List<string>> vizinhos;

    public Graph()
    {
        vizinhos = new Dictionary<string, List<string>>();
    }

    //cria cada no cidade individualmente
    public void Cidade(string cidade){
        vizinhos[cidade] = new List<string>();
    }
     //isso coneta a partida com a chegada e vice verso, assim não precisa declarar a ida e volta de cada adjacencia
    public void Estrada(string from, string to)
    {
        vizinhos[from].Add(to);
        vizinhos[to].Add(from);
    }
}


//DFS
class DFS
{
private Graph graph;

 public DFS(Graph graph){
    this.graph = graph;
 }

 public bool dfs(string origem, string destino){
    HashSet<string> visitado = new HashSet<string>();
    return BuscaProfundidade(origem, destino, visitado);
 }

 private bool BuscaProfundidade(string cidadeAtual, string destino, HashSet<string> visitado){
    visitado.Add(cidadeAtual);
    if (cidadeAtual!=destino){
    Console.Write(cidadeAtual + " --> ");
    }
    else{
        Console.Write(cidadeAtual);
    }

    if(cidadeAtual == destino){
        return true;
    }

    foreach ( string vizinho in graph.vizinhos[cidadeAtual]){
        if(!visitado.Contains(vizinho)){
            if (BuscaProfundidade(vizinho, destino, visitado)){
                return true;
            }
        }
    }

    return false;
 }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar cidades do grafo 
        Graph graph = new Graph();

        graph.Cidade("Arad");
        graph.Cidade("Zerind");
        graph.Cidade("Timisoara");
        graph.Cidade("Sibiu");
        graph.Cidade("Oradea");
        graph.Cidade("Lugoj");
        graph.Cidade("Mehadia");
        graph.Cidade("Dobreta");
        graph.Cidade("Craiova");
        graph.Cidade("Pitesti");
        graph.Cidade("Rimnicu_Vilcea");
        graph.Cidade("Fagaras");
        graph.Cidade("Bucharest");
        graph.Cidade("Urziceni");
        graph.Cidade("Giurgiu");
        graph.Cidade("Hirsova");
        graph.Cidade("Vaslui");
        graph.Cidade("Eforie");
        graph.Cidade("Iasi");
        graph.Cidade("Neamt");

        //estradas
        graph.Estrada("Arad", "Zerind");
        graph.Estrada("Arad", "Timisoara");
        graph.Estrada("Arad", "Sibiu");
        graph.Estrada("Zerind", "Oradea");
        graph.Estrada("Oradea", "Sibiu");
        graph.Estrada("Timisoara", "Lugoj");
        graph.Estrada("Lugoj", "Mehadia");
        graph.Estrada("Mehadia", "Dobreta");
        graph.Estrada("Dobreta", "Craiova");
        graph.Estrada("Craiova", "Pitesti");
        graph.Estrada("Craiova", "Rimnicu_Vilcea");
        graph.Estrada("Sibiu", "Rimnicu_Vilcea");
        graph.Estrada("Sibiu", "Fagaras");
        graph.Estrada("Fagaras", "Bucharest");
        graph.Estrada("Rimnicu_Vilcea", "Pitesti");
        graph.Estrada("Bucharest", "Pitesti");
        graph.Estrada("Bucharest", "Urziceni");
        graph.Estrada("Bucharest", "Giurgiu");
        graph.Estrada("Urziceni", "Hirsova");
        graph.Estrada("Urziceni", "Vaslui");
        graph.Estrada("Hirsova", "Eforie");
        graph.Estrada("Vaslui", "Iasi");
        graph.Estrada("Iasi", "Neamt");

        // Definir os nós de origem e destino
        string origem = "Arad";
        string destino = "Bucharest";

        // Executa o algoritmo
        DFS dfs = new DFS(graph);
        
        bool existeCaminho = dfs.dfs(origem, destino);

        Console.WriteLine();
        if (existeCaminho){
            Console.WriteLine("Eh possível atingir o destino a partir da origem");
        }
        else{
            Console.WriteLine("Nao eh possivel atingir o destino");
        }

    }
}

