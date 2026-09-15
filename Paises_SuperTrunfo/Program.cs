using System;
using System.Collections.Generic;

using Paises_SuperTrunfo;

// 1. Instancia o baralho
Baralho baralho = new Baralho();

// 2. Popula com algumas cartas de teste
baralho.AdicionarCarta(new Carta { Nacao = "Brasil", Pib = 1920000000000m, Tamanho = 8515767, Populacao = 214000000, Idh = 0.754f, IsSuperTrunfo = false, TipoCarta = "1A" });
baralho.AdicionarCarta(new Carta { Nacao = "Alemanha", Pib = 4000000000000m, Tamanho = 357022, Populacao = 83000000, Idh = 0.942f, IsSuperTrunfo = false, TipoCarta = "2A" });
baralho.AdicionarCarta(new Carta { Nacao = "Japão", Pib = 4900000000000m, Tamanho = 377975, Populacao = 125000000, Idh = 0.925f, IsSuperTrunfo = false, TipoCarta = "1B" });
baralho.AdicionarCarta(new Carta { Nacao = "Estados Unidos", Pib = 23000000000000m, Tamanho = 9833517, Populacao = 331000000, Idh = 0.921f, IsSuperTrunfo = true, TipoCarta = "ST" });
baralho.AdicionarCarta(new Carta { Nacao = "China", Pib = 18000000000000m, Tamanho = 9596961, Populacao = 1412000000, Idh = 0.788f, IsSuperTrunfo = false, TipoCarta = "3A" });
baralho.AdicionarCarta(new Carta { Nacao = "Índia", Pib = 3700000000000m, Tamanho = 3287263, Populacao = 1428000000, Idh = 0.644f, IsSuperTrunfo = false, TipoCarta = "1C" });
baralho.AdicionarCarta(new Carta { Nacao = "França", Pib = 3000000000000m, Tamanho = 551695, Populacao = 68000000, Idh = 0.903f, IsSuperTrunfo = false, TipoCarta = "2B" });
baralho.AdicionarCarta(new Carta { Nacao = "Reino Unido", Pib = 3400000000000m, Tamanho = 243610, Populacao = 67000000, Idh = 0.929f, IsSuperTrunfo = false, TipoCarta = "3B" });
baralho.AdicionarCarta(new Carta { Nacao = "Itália", Pib = 2200000000000m, Tamanho = 301340, Populacao = 59000000, Idh = 0.895f, IsSuperTrunfo = false, TipoCarta = "4A" });
baralho.AdicionarCarta(new Carta { Nacao = "Canadá", Pib = 2200000000000m, Tamanho = 9984670, Populacao = 40000000, Idh = 0.936f, IsSuperTrunfo = false, TipoCarta = "2C" });
baralho.AdicionarCarta(new Carta { Nacao = "Rússia", Pib = 2000000000000m, Tamanho = 17098242, Populacao = 144000000, Idh = 0.821f, IsSuperTrunfo = false, TipoCarta = "4B" });
baralho.AdicionarCarta(new Carta { Nacao = "Austrália", Pib = 1700000000000m, Tamanho = 7692024, Populacao = 27000000, Idh = 0.946f, IsSuperTrunfo = false, TipoCarta = "1D" });


Console.WriteLine("--- Cartas antes de embaralhar ---");
foreach (var carta in baralho.Cartas)
{
    Console.WriteLine($"{carta.TipoCarta} - {carta.Nacao}");
}

// 3. Embaralha as cartas
baralho.Embaralhar();

Console.WriteLine("\n--- Cartas depois de embaralhar ---");
foreach (var carta in baralho.Cartas)
{
    Console.WriteLine($"{carta.TipoCarta} - {carta.Nacao}");
}

// 4. Cria jogadores e distribui as cartas
List<Jogador> jogadores = new List<Jogador>
            {
                new Jogador { Nome = "Jogador 1" },
                new Jogador { Nome = "Jogador 2" }
            };

baralho.DistribuirCartas(jogadores);

int rodada = 1;

// O jogo continua enquanto AMBOS tiverem cartas
while (jogadores[0].Cartas.Count > 0 && jogadores[1].Cartas.Count > 0)
{
    Console.WriteLine($"\n================ RODADA {rodada} ================");
    Console.WriteLine($"Placar de cartas -> J1: {jogadores[0].Cartas.Count} | J2: {jogadores[1].Cartas.Count}");
    /*
    foreach (var carta in jogadores[0].Cartas)
    {
        Console.WriteLine($"{carta.TipoCarta} - {carta.Nacao} - U$ {carta.Pib} - {carta.Tamanho} - {carta.Populacao} - {carta.Idh}");
    }
    */
    Console.WriteLine($"\nCarta do Jogador 1: {jogadores[0].Cartas[0].TipoCarta} - {jogadores[0].Cartas[0].Nacao} - PIB  U$ {jogadores[0].Cartas[0].Pib} - Extensão Territorial {jogadores[0].Cartas[0].Tamanho} - População {jogadores[0].Cartas[0].Populacao} - IDH {jogadores[0].Cartas[0].Idh}");

    // Seleciona as cartas que vão pro final do baralho do vencedor
    Carta cartaJogador1 = jogadores[0].Cartas[0];
    Carta cartaJogador2 = jogadores[1].Cartas[0];

    // Remove do topo da mão
    jogadores[0].Cartas.RemoveAt(0);
    jogadores[1].Cartas.RemoveAt(0);


    int opcao; // Declarada fora para ser vista pelo restante do código

    while (true)
    {
        Console.WriteLine("\n---- Escolha um dos atributos ----");
        Console.WriteLine("""
        1 - PIB 
        2 - Tamanho do território
        3 - População
        4 - IDH
        """);

        try
        {
            opcao = int.Parse(Console.ReadLine()); // Aqui ela recebe o valor do usuário

            if (opcao >= 1 && opcao <= 4)
            {
                break; // Valor correto digitado, sai do loop e continua a rodada
            }

            Console.WriteLine("Opção inválida! Escolha apenas de 1 a 4.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida! Digite apenas o número da opção.");
        }
    }

        if (cartaJogador1.IsSuperTrunfo || cartaJogador2.IsSuperTrunfo)
    {

        char TipoCartaJogador1 = cartaJogador1.TipoCarta[^1];
        char TipoCartaJogador2 = cartaJogador2.TipoCarta[^1];
        if (TipoCartaJogador1 == 'T')
        {
            if (TipoCartaJogador2 == 'A')
            {
                Console.WriteLine($"\nO Jogador 2 venceu! (Super Trunfo perde para carta A - {cartaJogador2.TipoCarta})");

                // Jogador 2 Recebe as cartas
                jogadores[1].Cartas.Add(cartaJogador1);
                jogadores[1].Cartas.Add(cartaJogador2);
            }
            else
            {
                Console.WriteLine("\nO Jogador 1 venceu com o Super Trunfo!");
                // Jogador 1 Recebe as cartas
                jogadores[0].Cartas.Add(cartaJogador2);
                jogadores[0].Cartas.Add(cartaJogador1);
            }
        }
        else if (TipoCartaJogador2 == 'T')
        {
            if (TipoCartaJogador1 == 'A')
            {
                Console.WriteLine($"\nO Jogador 1 venceu! (Super Trunfo perde para carta A - {cartaJogador1.TipoCarta})");                    // Jogador 1 Recebe as cartas
                jogadores[0].Cartas.Add(cartaJogador2);
                jogadores[0].Cartas.Add(cartaJogador1);
            }
            else
            {
                Console.WriteLine("\nO Jogador 2 venceu com o Super Trunfo!");
                // Jogador 2 Recebe as cartas
                jogadores[1].Cartas.Add(cartaJogador1);
                jogadores[1].Cartas.Add(cartaJogador2);

            }
        }
    }

    else
    {
        Decimal AtributoJogador1;
        Decimal AtributoJogador2;
        AtributoJogador1 = cartaJogador1.ObterValorAtributo(opcao);
        AtributoJogador2 = cartaJogador2.ObterValorAtributo(opcao);

        Console.WriteLine($"\n{cartaJogador1.Nacao} {AtributoJogador1} X {cartaJogador2.Nacao} {AtributoJogador2}");

        Console.WriteLine("");

        if (AtributoJogador1 > AtributoJogador2)
        {
            Console.WriteLine("O Jogador 1 venceu!");
            // Jogador 1 Recebe as cartas
            jogadores[0].Cartas.Add(cartaJogador2);
            jogadores[0].Cartas.Add(cartaJogador1);

        }
        else
        {
            Console.WriteLine("O Jogador 2 venceu!");
            // Jogador 2 Recebe as cartas
            jogadores[1].Cartas.Add(cartaJogador2);
            jogadores[1].Cartas.Add(cartaJogador1);
        }
    }
    rodada++;
}

// Quando o while termina, alguém ficou com 0 cartas:
Console.WriteLine("\n================ FIM DE JOGO ================");
if (jogadores[0].Cartas.Count > 0)
{
    Console.WriteLine($"PARABÉNS! {jogadores[0].Nome} venceu a partida e conquistou todas as cartas!");
}
else
{
    Console.WriteLine($"PARABÉNS! {jogadores[1].Nome} venceu a partida e conquistou todas as cartas!");
}

Console.WriteLine("\nDigite algo para sair ");
Console.ReadLine();