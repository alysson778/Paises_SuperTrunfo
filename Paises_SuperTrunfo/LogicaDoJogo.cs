using System;
using System.Collections.Generic;
using System.Text;

namespace Paises_SuperTrunfo
{
    public class LogicaDoJogo
    {
        List<Jogador> jogadores = new List<Jogador>
            {
                new Jogador { Nome = "Jogador 1" },
                new Jogador { Nome = "Jogador 2" }
            };

        int opcao;


        
     public void MostrarBaralho(Baralho baralho) 
     {
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

     }

        public void VerificarCartas(Carta cartaJogador1, Carta cartaJogador2, int opcao)
        {
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
        }
        public void Rodadas()
        {
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


                 // Declarada fora para ser vista pelo restante do código

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
                VerificarCartas(cartaJogador1,cartaJogador2,opcao);
                
             
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
        }
        public void IniciarJogo(Baralho baralho)
        {
            MostrarBaralho(baralho);
            baralho.DistribuirCartas(jogadores);
            Rodadas();
        }
    }
}
