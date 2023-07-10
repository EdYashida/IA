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
class DFSL
{
private Graph graph;

 public DFSL(Graph graph){
    this.graph = graph;
 }

 public bool dfs(string origem, string destino, ref int profundidade)
{
    HashSet<string> visitado = new HashSet<string>();
    Stack<string> pilha = new Stack<string>();

    pilha.Push(origem);
    visitado.Add(origem);

    while (pilha.Count > 0) //enquanto pilha ñ estriver vazia
    {
        string cidadeAtual = pilha.Pop();  //verifica cidade atual
        Console.Write(cidadeAtual + " --> ");

        if (cidadeAtual == destino)
        {
            return true; // Nó de destino encontrado
        }

        if (visitado.Count > profundidade) //ultrapassou limite de prof
        {
            visitado.Remove(cidadeAtual);  //retira cidade atual de visitados
        }

        if (visitado.Count < profundidade) //limite de profundidade respeitado
        {
            foreach (string vizinho in graph.vizinhos[cidadeAtual])
            {
                if (!visitado.Contains(vizinho)) //se vizinho não visitado, empilha e visita
                {
                    pilha.Push(vizinho);
                    visitado.Add(vizinho);
                }
            }
        }

        if (pilha.Count == 0 && profundidade > 0) //reinicia busca a cada iteração fracassad, aumentando limite de profundidade
        {
            profundidade++;
            pilha.Push(origem);
            visitado.Clear();
            visitado.Add(origem);
            Console.WriteLine("");
        }
    }

    return false; // Nó de destino não encontrado
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
        int limite = 1;

        // Executa o algoritmo
        DFSL dfs = new DFSL(graph);
        
        bool existeCaminho = dfs.dfs(origem, destino, ref limite);

        Console.WriteLine();
        if (existeCaminho){
            Console.WriteLine("Eh possivel atingir o destino a partir da origem");
        }
        else{
            Console.WriteLine("Nao eh possivel atingir o destino");
        }

    }
}
