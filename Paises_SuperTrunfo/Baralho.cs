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
            Cartas.Add(carta);
        }
        public void Embaralhar()
        {
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
                return;

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