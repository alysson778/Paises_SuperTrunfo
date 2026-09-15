using System;
using System.Collections.Generic;
using System.Text;

namespace Paises_SuperTrunfo
{
    public class Baralho
    {
        public List<Carta> Cartas { get; set; }
        private Random random;
        public Baralho()
        {
            Cartas = new List<Carta>();
            random = new Random();
        }
        public void AdicionarCarta(Carta carta)
        {
            // Impede a inserção de uma carta vazia/nula no jogo
            if (carta == null)
            {
                throw new ArgumentNullException(nameof(carta), "Não é possível adicionar uma carta nula.");
            }
            Cartas.Add(carta);
        }
        public void Embaralhar()
        {
            // Se tiver 1 ou 0 cartas, não precisa (e nem dá) para embaralhar
            if (Cartas.Count <= 1)
                // Return vazio saí imediatamente do método, sem executar o restante do código
                return;

            int n = Cartas.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                Carta temp = Cartas[i];
                Cartas[i] = Cartas[j];
                Cartas[j] = temp;
            }
        }

     
        public void DistribuirCartas(List<Jogador> jogadores)
        {
            if (jogadores == null || jogadores.Count == 0 || Cartas.Count == 0)
            {
                // Valida se a lista de jogadores existe e tem participantes
                // NameOf Coloca o nome do parâmetro ("jogadores") na exceção. Assim fica mais fácil identificar qual argumento causou o problema
                throw new ArgumentException("A lista de jogadores não pode ser nula ou vazia.", nameof(jogadores));
            }

            if (Cartas.Count < jogadores.Count)
            {
                // Valida se o baralho tem cartas suficientes para pelo menos dar uma para cada
                throw new InvalidOperationException($"Cartas insuficientes ({Cartas.Count}) para o número de jogadores ({jogadores.Count}).");
            }
            int jogadorAtual = 0;

            foreach (var carta in Cartas)
            {
                jogadores[jogadorAtual].Cartas.Add(carta);
                // Alterna entre os jogadores cadastrados
                jogadorAtual = (jogadorAtual + 1) % jogadores.Count;
            }

            // Limpa o baralho principal após entregar as cartas aos jogadores
            Cartas.Clear();
        }
    }
}