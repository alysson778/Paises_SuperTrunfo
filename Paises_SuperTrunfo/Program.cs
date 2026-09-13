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

            Console.WriteLine("\n--- Cartas do Jogador 1 ---");
            foreach (var carta in jogadores[0].Cartas)
            {
                Console.WriteLine($"{carta.TipoCarta} - {carta.Nacao}");
            }
        
   
