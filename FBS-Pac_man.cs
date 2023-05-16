using System;
using System.Collections.Generic;

// Grafo
class Graph
{
    //cria dicionario com ajacencias
    private Dictionary<string, List<string>> vizinhos;

    public Graph()
    {
        vizinhos = new Dictionary<string, List<string>>();
    }

//conexao entre os pontos
//nós criados quando declarado na chamada do método, não precisando declarar cada nó em singular

    public void Anda(string from, string to)
    {
        //caso o nó nao esteja em vizinhos
        if (!vizinhos.ContainsKey(from))
        //lista de seus vizinho e adiciona ao dicionario vizinhos
            vizinhos[from] = new List<string>();

        if (!vizinhos.ContainsKey(to))
            vizinhos[to] = new List<string>();

//isso coneta a partida com a chegada e vice verso, assim não precisa declarar a ida e volta de cada adjacencia
        vizinhos[from].Add(to);
        vizinhos[to].Add(from);
    }

//awds referente aos movimento de baixo,cima,direita e esquerda que esses botoes normalmente fazem em jogos
    public List<string> GetVizinhos(string awsd)
    {
        return vizinhos[awsd];
    }
}


//BFS
class BFS
{
    public List<string> CaminhoMaisCurto(Graph graph, string origem, string destino)
    {
        //fila de busca e pais
        Queue<string> fila = new Queue<string>();
        Dictionary<string, string> pais = new Dictionary<string, string>();

        fila.Enqueue(origem);
        pais[origem] = null; //comeca só com origem

        while (fila.Count > 0) //percorre nós 
        {
            string posicaoPac = fila.Dequeue(); //verifica posicaoPac(ponto atual)

            if (posicaoPac == destino) //para se tuver atingido destino
                break;

            foreach (string vizinho in graph.GetVizinhos(posicaoPac)) //obtem vizinhos do ponto atual
            {
                if (!pais.ContainsKey(vizinho)) //vizinho nao visitado ainda
                {
                    fila.Enqueue(vizinho); //vizinho entra na fila
                    pais[vizinho] = posicaoPac; //ponto de agora fica marcado como pai
                }
            }
        }

        
        List<string> caminho = new List<string>(); //monta caminho

        string ponto = destino; //comeca do fim
        while (ponto != null)   //loop que para quando chegar na origem
        {
            caminho.Insert(0, ponto); //insere ponto a ponto do caminho
            ponto = pais[ponto];      //ponto se transforma em seu pai para ir voltando
        }

        return caminho;
    }
    public int CalculateDistance(Graph graph, string origem, string destino) //funcao pra verificar o destino mais proximo
    {

        //realiza BFS de modo a contabilizar a distancia entre origem e os destinos
        Queue<string> fila = new Queue<string>();
        Dictionary<string, int> distancia = new Dictionary<string, int>();

        fila.Enqueue(origem);
        distancia[origem] = 0;

        while (fila.Count > 0)
        {
            string posicaoPac = fila.Dequeue();

            if (posicaoPac == destino)
                break;

            foreach (string vizinho in graph.GetVizinhos(posicaoPac))
            {
                if (!distancia.ContainsKey(vizinho))
                {
                    fila.Enqueue(vizinho);
                    distancia[vizinho] = distancia[posicaoPac] + 1; //a cada iteracao é incrementado valor 1 a distancia, assim se tem controle sobre onde eh mais proximo
                }
            }
        }

        if (distancia.ContainsKey(destino))
            return distancia[destino];
        else
            return -1; // se nao for possivle atingir destino com base na origem
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar um grafo de exemplo
        Graph graph = new Graph();

//TRANSIÇÕES ENTRE PONTOS NA MESMA LINHA E PARA PONTOS NA LINHA LOGO ABAIXO
//DECLARAR APENAS 1 VEZ, DIFERENTE DE DIJKISTRA, JA VALE PRA IDA E VOLTA

        //PRMEIRA LINHA A
        graph.Anda("A1", "A2");
        graph.Anda("A1", "B1");
        graph.Anda("A2", "A3");
        graph.Anda("A3", "A4");
        graph.Anda("A4", "B4");
        graph.Anda("A6", "B6");
        graph.Anda("A6", "A7");
        graph.Anda("A7", "A8");
        graph.Anda("A8", "A9");
        graph.Anda("A9", "A10");
        graph.Anda("A10", "A11");
        graph.Anda("A11", "A12");
        graph.Anda("A12", "A13");
        graph.Anda("A13", "B13");
        graph.Anda("A15", "B15");
        graph.Anda("A15", "A16");
        graph.Anda("A16", "A17");
        graph.Anda("A17", "A18");
        graph.Anda("A18", "B18");

        //SEGUNDA LINHA B
        graph.Anda("B1", "C1");
        graph.Anda("B4", "C4");
        graph.Anda("B6", "C6");
        graph.Anda("B13", "C13");
        graph.Anda("B15", "C15");
        graph.Anda("B18", "C18");

        //TERCEIRA LINHA C
        graph.Anda("C1", "D1");
        graph.Anda("C3", "C4");
        graph.Anda("C3", "D3");
        graph.Anda("C4", "C5");
        graph.Anda("C5", "C6");
        graph.Anda("C6", "C7");
        graph.Anda("C6", "D6");
        graph.Anda("C7", "C8");
        graph.Anda("C8", "C9");
        graph.Anda("C9", "C10");
        graph.Anda("C9", "D9");
        graph.Anda("C10", "C11");
        graph.Anda("C10", "D10");
        graph.Anda("C11", "C12");
        graph.Anda("C12", "C13");
        graph.Anda("C13", "C14");
        graph.Anda("C13", "D13");
        graph.Anda("C14", "C15");
        graph.Anda("C15", "C16");
        graph.Anda("C16", "D16");
        graph.Anda("C18", "D18");

        //QUARTA LINHA D
        graph.Anda("D1", "E1");
        graph.Anda("D3", "E3");
        graph.Anda("D6", "E6");
        graph.Anda("D9", "E9");
        graph.Anda("D10", "E10");
        graph.Anda("D13", "E13");
        graph.Anda("D16", "E16");
        graph.Anda("D18", "E18");

        //QUINTA LINHA E
        graph.Anda("E1", "E2");
        graph.Anda("E1", "F1");
        graph.Anda("E2", "E3");
        graph.Anda("E3", "E4");
        graph.Anda("E3", "F3");
        graph.Anda("E4", "E5");
        graph.Anda("E5", "E6");
        graph.Anda("E6", "F6");
        graph.Anda("E8", "E9");
        graph.Anda("E9", "E10");
        graph.Anda("E10", "E11");
        graph.Anda("E13", "F13");
        graph.Anda("E13", "E14");
        graph.Anda("E14", "E15");
        graph.Anda("E15", "E16");
        graph.Anda("E16", "E17");
        graph.Anda("E16", "F16");
        graph.Anda("E17", "E18");
        graph.Anda("E18", "F18");

        //SEXTA LINHA F
        graph.Anda("F1", "G1");
        graph.Anda("F3", "G3");
        graph.Anda("F6", "G6");
        graph.Anda("F13", "G13");
        graph.Anda("F16", "G16");
        graph.Anda("F18", "G18");

        //SETIMA LINHA G
        graph.Anda("G1", "H1");
        graph.Anda("G3", "G4");
        graph.Anda("G4", "G5");
        graph.Anda("G4", "H4");
        graph.Anda("G5", "G6");
        graph.Anda("G6", "H6");
        graph.Anda("G6", "G7");
        graph.Anda("G7", "G8");
        graph.Anda("G8", "G9");
        graph.Anda("G9", "G10");
        graph.Anda("G10", "G11");
        graph.Anda("G11", "G12");
        graph.Anda("G12", "G13");
        graph.Anda("G13", "G14");
        graph.Anda("G13", "H13");
        graph.Anda("G14", "G15");
        graph.Anda("G15", "G16");
        graph.Anda("G15", "H15");
        graph.Anda("G18", "H18");

        //OITAVA LINHA H
        graph.Anda("H1", "I1");
        graph.Anda("H4", "I4");
        graph.Anda("H6", "I6");
        graph.Anda("H13", "I13");
        graph.Anda("H15", "I15");
        graph.Anda("H18", "I18");

        //NONA LINHA I
        graph.Anda("I1", "I2");
        graph.Anda("I2", "A3");
        graph.Anda("I3", "A4");
        graph.Anda("I6", "I7");
        graph.Anda("I7", "I8");
        graph.Anda("I8", "I9");
        graph.Anda("I9", "I10");
        graph.Anda("I10", "I11");
        graph.Anda("I11", "I12");
        graph.Anda("I12", "I13");
        graph.Anda("I15", "I16");
        graph.Anda("I16", "I17");
        graph.Anda("I17", "I18");
        
        

        // Definir os nós de origem e destino
        string origem = "G11";
        string moeda1 = "I18";
        string moeda2 = "A1";

        // Executa o algoritmo
        BFS bfs = new BFS();
        List<String> destinoPerto;
        List<String> destinoLonge;

        //verifica qual o ponto mais proximo e mais distante
        if (bfs.CalculateDistance(graph, origem, moeda1) <= bfs.CalculateDistance(graph, origem, moeda2))
        {
            destinoPerto = bfs.CaminhoMaisCurto(graph, origem, moeda1);
            destinoLonge = bfs.CaminhoMaisCurto(graph, moeda1, moeda2);

        }
        else
        {
            destinoPerto = bfs.CaminhoMaisCurto(graph, origem, moeda2);
            destinoLonge = bfs.CaminhoMaisCurto(graph, moeda2, moeda1);

        }
        //printa :)
        Console.WriteLine("Moeda mais proxima:");
        PrintCaminho(destinoPerto);
        Console.WriteLine();
        Console.WriteLine("Moeda mais distante:");
        PrintCaminho(destinoLonge);

    }

    // Mostra Caminho
    static void PrintCaminho(List<string> caminho) //formata como printar de modo mais bonito
    {
        foreach (string ponto in caminho) // loop para cada ponto do caminho 
        {
            Console.Write(ponto); // printa o ponto da posicao atual
            if (ponto != caminho[caminho.Count - 1]) //verifica se o ponto atual é o ultimo do caminho
                Console.Write(" -> ");
        }
        Console.WriteLine(); //pula linha para proxima chamada do método
    }
}
