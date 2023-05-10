using System; //entrada e saida
using System.Collections.Generic; //uso de dicionario
using System.Linq; //itera seletivamente sobre coleções


//declaracao dos nós cidades contendo seus nomes suas ditâncias para cidades vizinhas
public class Node {

    //getters e setters
    public string Nome { get; set; }  //separado pois o nome é coletado sozinho pela entrada do usuário e então é associado a um nó e sua distância para adjacentes
    public int Dist { get; set; }

    //construtor
    public Node(string nome, int distancia) {
        Nome = nome;
        Dist = distancia;
    }
}


//implementa o algoritmo
public class Dijkstra {
    public static Tuple<int, List<Node>> CaminhoMinimo(Dictionary<Node, Dictionary<Node, int>> graph, Node origem, Node destino) { 
        //tuple--> estrutura que armazena valores de diferentes tipos (graph, string de nome, string de distancia, etc)
        //1 dicionario --> recebe nós do grafo como chaves
        //2 dicionário --> mapeia vizinho de cada nó e distancia
        //nó origem e nó destino
        
        var distancia = new Dictionary<Node, int>(); //distancia minima para o nó do momento
        var pais = new Dictionary<Node, Node>();     //nós que precedem o caminho mais curto do momento
        var fila = new List<Node>();                 //fila de nós não visitados conforme distancia da origem

        foreach (var node in graph) { //inicializa distancias
            if (node.Key == origem) { //origem eh 0
                distancia[node.Key] = 0;
                fila.Add(node.Key);   //adiciona origem a fila
            } else {                  //os demais sao valor maximo
                distancia[node.Key] = int.MaxValue;
            }
            pais[node.Key] = null;
        }

        while (fila.Count > 0) {    //loop enquanto todos os nós nao forem visitados
            var noatual = fila[0];
            fila.RemoveAt(0);
            //verifica vizinhos, se a distancia ate um vizinho a partir do nó atual for menor que a menor distancia dele anteriormente obtida
            //esse vizinho sera tido como o proximo a ser seguido no caminho, o nó atual será o pai desse vizinho
            foreach (var vizinho in graph[noatual]) {
                var alt = distancia[noatual] + vizinho.Value;
                if (alt < distancia[vizinho.Key]) {
                    distancia[vizinho.Key] = alt; //distancia do vizinho mais proximo eh incorporada
                    pais[vizinho.Key] = noatual;  //pai do vizinho se torna o atual
                    fila.Add(vizinho.Key);        //adiciona vizinho a fila
                }
            }
        }

        //Retorno a partir do destino
        var path = new List<Node>();
        Node atual = destino; //comeca em destino
        while (atual != null) {
            path.Insert(0, atual);
            atual = pais[atual]; //atual eh pai do atual anterior
        }

        //Exibe resultado
        Console.Write("Menor caminho de {0} ate {1}: ", origem.Nome, destino.Nome);
        foreach (var node in path) { 
            Console.Write("{0} --> ", node.Nome); //cidades do caminho
        }
        Console.WriteLine("({0} km)", distancia[destino]); //distancia total percorrida

        return new Tuple<int, List<Node>>(distancia[destino], path); //caminho mais curto de nós(lista) retornado
    }
}

public class Program {
    public static void Main() {
        // monta grafo das cidade
        var Arad  = new Node("Arad", int.MaxValue);
        var Zerind  = new Node("Zerind", int.MaxValue);
        var Oradea  = new Node("Oradea", int.MaxValue);
        var Sibiu  = new Node("Sibiu", int.MaxValue);
        var Timisoara  = new Node("Timisoara", int.MaxValue);
        var Lugoj  = new Node("Lugoj", int.MaxValue);
        var Mehadia  = new Node("Mehadia", int.MaxValue);
        var Dobreta  = new Node("Dobreta", int.MaxValue);
        var Craiova  = new Node("Craiova", int.MaxValue);
        var Rimnicu_Vilcea  = new Node("Rimnicu_Vilcea", int.MaxValue);
        var Fagaras  = new Node("Fagaras", int.MaxValue);
        var Pitesti  = new Node("Pitesti", int.MaxValue);
        var Bucharest  = new Node("Bucharest", int.MaxValue);
        var Giurgiu  = new Node("Giurgiu", int.MaxValue);
        var Urziceni  = new Node("Urziceni", int.MaxValue);
        var Hirsova  = new Node("Hirsova", int.MaxValue);
        var Eforie  = new Node("Eforie", int.MaxValue);
        var Vaslui  = new Node("Vaslui", int.MaxValue);
        var Iasi  = new Node("Iasi", int.MaxValue);
        var Neamt  = new Node("Neamt", int.MaxValue);


        var graph = new Dictionary<Node, Dictionary<Node, int>> {
            { Arad, new Dictionary<Node, int> {
                { Zerind, 75 },
                { Timisoara, 118 },
                { Sibiu, 140},
            }},
            { Zerind, new Dictionary<Node, int> {
                { Arad, 75 },
                { Oradea, 71 },
            }},
            { Oradea, new Dictionary<Node, int> {
                { Zerind, 71 },
                { Sibiu, 151 },
            }},
            { Timisoara, new Dictionary<Node, int> {
                { Arad, 118 },
                { Lugoj, 111 },
            }},
            { Lugoj, new Dictionary<Node, int> {
                { Timisoara, 111 },
                { Mehadia, 70 },
            }},
            { Mehadia, new Dictionary<Node, int> {
                { Dobreta, 75 },
                { Lugoj, 70 },
            }},
            { Dobreta, new Dictionary<Node, int> {
                { Mehadia, 75 },
                { Craiova, 120 },
            }},
            { Craiova, new Dictionary<Node, int> {
                { Dobreta, 120 },
                { Rimnicu_Vilcea, 146 },
                { Pitesti, 138 },
            }},
            { Sibiu, new Dictionary<Node, int> {
                { Fagaras, 99 },
                { Rimnicu_Vilcea, 80 },
                { Arad, 140 },
                { Oradea, 151 },
            }},
            { Fagaras, new Dictionary<Node, int> {
                { Sibiu, 99 },
                { Bucharest, 211 },
            }},
            { Rimnicu_Vilcea, new Dictionary<Node, int> {
                { Pitesti, 97 },
                { Craiova, 146 },
                { Sibiu, 80 },
            }},
            { Pitesti, new Dictionary<Node, int> {
                { Rimnicu_Vilcea, 97 },
                { Bucharest, 101 },
                { Craiova, 138 },
            }},
            { Bucharest, new Dictionary<Node, int> {
                { Pitesti, 101 },
                { Fagaras, 211 },
                { Giurgiu, 90 },
                { Urziceni, 85 },
            }},
            { Giurgiu, new Dictionary<Node, int> {
                { Bucharest, 90 },
            }},
            { Urziceni, new Dictionary<Node, int> {
                { Bucharest, 85 },
                { Hirsova, 98 },
                { Vaslui, 142 },
            }},
            { Hirsova, new Dictionary<Node, int> {
                { Urziceni, 98 },
                { Eforie, 86 },
            }},
            { Eforie, new Dictionary<Node, int> {
                { Hirsova, 86 },
            }},
            { Vaslui, new Dictionary<Node, int> {
                { Urziceni, 142 },
                { Iasi, 92 },
            }},
            { Iasi, new Dictionary<Node, int> {
                { Vaslui, 92 },
                { Neamt, 87 },
            }},
            { Neamt, new Dictionary<Node, int> {
                { Iasi, 87 },
            }},
        };

        // insere origem
        Console.Write("Cidade de Origem: ");
        string origem = Console.ReadLine();
        Node noorigem = graph.Keys.FirstOrDefault(node => node.Nome == origem);
        if (noorigem == null) {
            Console.WriteLine("Cidade nao encontrada");
            return;
        }

        //Insere destino
        Console.Write("Cidade Destino: ");
        string destino = Console.ReadLine();
        Node nodestino = graph.Keys.FirstOrDefault(node => node.Nome == destino);
        if (nodestino == null) {
            Console.WriteLine("Cidade nao encontrada");
            return;
        }

        // Roda algoritmo
        Dijkstra.CaminhoMinimo(graph, noorigem, nodestino);

        Console.ReadKey();
    }
}

