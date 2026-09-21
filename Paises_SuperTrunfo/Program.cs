using System;
using System.Collections.Generic;

using Paises_SuperTrunfo;

// 1. Instancia o baralho e a lógica do jogo
Baralho baralho = new Baralho();
LogicaDoJogo logicaDoJogo = new LogicaDoJogo();

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






logicaDoJogo.IniciarJogo(baralho);