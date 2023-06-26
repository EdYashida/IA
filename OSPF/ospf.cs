using System; //entrada e saida
using System.Collections.Generic; //uso de dicionario
using System.Linq; //itera seletivamente sobre coleções


//declaracao dos nós cidades contendo seus nomes suas ditâncias para cidades vizinhas
public class Node {

    //getters e setters
    public string Nome { get; set; }  //separado pois o nome é coletado sozinho pela entrada do usuário e então é associado a um nó e sua distância para adjacentes
    public int Band { get; set; }

    //construtor
    public Node(string nome, int banda) {
        Nome = nome;
        Band = banda;
    }
}


//implementa o algoritmo
public class Dijkstra {
    public static Tuple<int, List<Node>> CaminhoMinimo(Dictionary<Node, Dictionary<Node, int>> graph, Node origem, Node destino) { 
        //tuple--> estrutura que armazena valores de diferentes tipos (graph, string de nome, string de distancia, etc)
        //1 dicionario --> recebe nós do grafo como chaves
        //2 dicionário --> mapeia vizinho de cada nó e distancia
        //nó origem e nó destino
        
        var banda = new Dictionary<Node, int>(); //distancia minima para o nó do momento
        var pais = new Dictionary<Node, Node>();     //nós que precedem o caminho mais curto do momento
        var fila = new List<Node>();                 //fila de nós não visitados conforme distancia da origem

        foreach (var node in graph) { //inicializa distancias
            if (node.Key == origem) { //origem eh 0
                banda[node.Key] = 0;
                fila.Add(node.Key);   //adiciona origem a fila
            } else {                  //os demais sao valor maximo
                banda[node.Key] = int.MaxValue;
            }
            pais[node.Key] = null;
        }

        while (fila.Count > 0) {    //loop enquanto todos os nós nao forem visitados
            var noatual = fila[0];
            fila.RemoveAt(0);
            //verifica vizinhos, se a distancia ate um vizinho a partir do nó atual for menor que a menor distancia dele anteriormente obtida
            //esse vizinho sera tido como o proximo a ser seguido no caminho, o nó atual será o pai desse vizinho
            foreach (var vizinho in graph[noatual]) {
                var alt = banda[noatual] + (100000000/vizinho.Value); //aplica formula encontrada em: https://www.linkedin.com/pulse/how-open-shortest-path-first-ospf-uses-dijkstras-algorithm-kumar/
                if (alt < banda[vizinho.Key]) {
                    banda[vizinho.Key] = alt; //distancia do vizinho mais proximo eh incorporada
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
        Console.WriteLine("Custo total: ({0})", banda[destino]); //distancia total percorrida

        return new Tuple<int, List<Node>>(banda[destino], path); //caminho mais curto de nós(lista) retornado
    }
}

public class Program {
    public static void Main() {
        // monta grafo dos equipamentos
        var Eduardo  = new Node("Eduardo", int.MaxValue);
        var Hs  = new Node("Hs", int.MaxValue);
        var Gabriel  = new Node("Gabriel", int.MaxValue);
        var Gallo  = new Node("Gallo", int.MaxValue);
        var Joao  = new Node("Joao", int.MaxValue);
        var Gafa  = new Node("Gafa", int.MaxValue);
        var Faria  = new Node("Faria", int.MaxValue);
        var McLovin  = new Node("McLovin", int.MaxValue);
        var Leonardo  = new Node("Leonardo", int.MaxValue);
        var Cerebro  = new Node("Cerebro", int.MaxValue);
        var Icaro  = new Node("Icaro", int.MaxValue);
        var Palermo  = new Node("Palermo", int.MaxValue);
        var Pedro  = new Node("Pedro", int.MaxValue);
        var Foguinho  = new Node("Foguinho", int.MaxValue);
        var Vitor  = new Node("Vitor", int.MaxValue);
        var Ratinho  = new Node("Ratinho", int.MaxValue);
        var Lucas  = new Node("Lucas", int.MaxValue);
        var Nelson  = new Node("Nelson", int.MaxValue);
        var Gustavo  = new Node("Gustavo", int.MaxValue);
        var Romas  = new Node("Romas", int.MaxValue);
        var Oswaldo  = new Node("Oswaldo", int.MaxValue);
        var Cria  = new Node("Cria", int.MaxValue);
        var Marcio  = new Node("Marcio", int.MaxValue);
        var Cross  = new Node("Cross", int.MaxValue);
        var Matheus  = new Node("Matheus", int.MaxValue);
        var Benni  = new Node("Benni", int.MaxValue);
        var Yasuo  = new Node("Yasuo", int.MaxValue);
        var Lillia  = new Node("Lillia", int.MaxValue);
        var Temmo  = new Node("Temmo", int.MaxValue);
        var Sova  = new Node("Sova", int.MaxValue);


        var graph = new Dictionary<Node, Dictionary<Node, int>> {
            { Eduardo, new Dictionary<Node, int> {
                { Hs, 50000000 },
                { Lillia, 17500000 },
                { Gallo, 28000000},
                { Leonardo, 38000000},
            }},
            { Hs, new Dictionary<Node, int> {
                { Eduardo, 50000000 },
            }},
            { Gabriel, new Dictionary<Node, int> {
                { Eduardo, 28000000 },
                { Leonardo, 42000000 },
                { Gallo, 48500000 },
                { Temmo, 12000000 },
                { Gafa, 30000000 },
            }},
            { Gallo, new Dictionary<Node, int> {
                { Gabriel, 48500000 },
                { Sova, 35500000 },
                { Joao, 25600000 },
            }},
            { Joao, new Dictionary<Node, int> {
                { Gallo, 25600000 },
                { Pedro, 34100000 },
                { Yasuo, 65000000 },
                { Gafa, 48300000 },
            }},
            { Gafa, new Dictionary<Node, int> {
                { Gabriel, 30000000 },
                { Joao, 48300000 },
                { Faria, 49000000 },
                { Lucas, 24000000 },
            }},
            { Faria, new Dictionary<Node, int> {
                { Leonardo, 22000000 },
                { Cerebro, 33000000 },
                { Gafa, 49000000 },
                { McLovin, 69000000 },
            }},
            { McLovin, new Dictionary<Node, int> {
                { Faria, 69000000 },
                { Romas, 40000000 },
            }},
            { Leonardo, new Dictionary<Node, int> {
                { Gabriel, 42000000 },
                { Eduardo, 38000000 },
                { Cerebro, 10101010 },
                { Faria, 22000000 },
            }},
            { Cerebro, new Dictionary<Node, int> {
                { Leonardo, 10101010 },
                { Faria, 33000000 },
            }},
            { Icaro, new Dictionary<Node, int> {
                { Oswaldo, 23000000 },
                { Palermo, 53000000 },
            }},
            { Palermo, new Dictionary<Node, int> {
                { Icaro, 53000000 },
                { Ratinho, 44000000 },
                { Benni, 23400000 },
            }},
            { Pedro, new Dictionary<Node, int> {
                { Foguinho, 12300000 },
                { Joao, 34100000 },
            }},
            { Foguinho, new Dictionary<Node, int> {
                { Pedro, 12300000 },
                { Sova, 62300000 },
            }},
            { Vitor, new Dictionary<Node, int> {
                { Ratinho, 9900000 },
                { Marcio, 5300000 },
                { Matheus, 23900000 },
                { Gustavo, 80100000 },
            }},
            { Ratinho, new Dictionary<Node, int> {
                { Vitor, 9900000 },
                { Palermo, 44000000 },
            }},
            { Lucas, new Dictionary<Node, int> {
                { Gafa, 24000000 },
                { Nelson, 11000000 },
                { Matheus, 21000000 },
            }},
            { Nelson, new Dictionary<Node, int> {
                { Lucas, 11000000 },
                { Romas, 31000000 },
            }},
            { Gustavo, new Dictionary<Node, int> {
                { Romas, 41000000 },
                { Cross, 2000000 },
                { Vitor, 9900000 },
            }},
            { Romas, new Dictionary<Node, int> {
                { Nelson, 31000000 },
                { McLovin, 40000000 },
                { Gustavo, 41000000 },
            }},
            { Oswaldo, new Dictionary<Node, int> {
                { Cria, 11100000 },
                { Icaro, 22000000 },
            }},
            { Cria, new Dictionary<Node, int> {
                { Benni, 88000000 },
                { Oswaldo, 11100000 },
            }},
            { Marcio, new Dictionary<Node, int> {
                { Cross, 9100000 },
                { Vitor, 5300000 },
            }},
            { Cross, new Dictionary<Node, int> {
                { Marcio, 9100000 },
                { Gustavo, 2000000 },
            }},
            { Matheus, new Dictionary<Node, int> {
                { Lucas, 21000000 },
                { Benni, 81400000 },
                { Vitor, 23900000 },
            }},
            { Benni, new Dictionary<Node, int> {
                { Matheus, 81400000 },
                { Cria, 88000000 },
                { Palermo, 23400000 },
            }},
            { Yasuo, new Dictionary<Node, int> {
                { Joao, 65000000 },
            }},
            { Lillia, new Dictionary<Node, int> {
                { Eduardo, 17500000 },
                { Temmo, 24400000 },
            }},
            { Temmo, new Dictionary<Node, int> {
                { Lillia, 24400000 },
                { Gallo, 12000000 },
            }},
            { Sova, new Dictionary<Node, int> {
                { Gallo, 35500000 },
                { Foguinho, 62300000 },
            }},
        };

        // insere origem
        Console.Write("Dispositivo de Origem: ");
        string origem = Console.ReadLine();
        Node noorigem = graph.Keys.FirstOrDefault(node => node.Nome == origem);
        if (noorigem == null) {
            Console.WriteLine("Dispositivo nao encontrado");
            return;
        }

        //Insere destino
        Console.Write("Dispositivo Destino: ");
        string destino = Console.ReadLine();
        Node nodestino = graph.Keys.FirstOrDefault(node => node.Nome == destino);
        if (nodestino == null) {
            Console.WriteLine("Dispositivo nao encontrado");
            return;
        }

        // Roda algoritmo
        Dijkstra.CaminhoMinimo(graph, noorigem, nodestino);

        Console.ReadKey();
    }
}

