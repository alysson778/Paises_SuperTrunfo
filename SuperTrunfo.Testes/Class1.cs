using Paises_SuperTrunfo;

namespace SuperTrunfo.Testes
{
    [TestClass]
    public sealed class BaralhoTestes
    {
        [TestMethod]
        public void DistribuirCartas_DeveEsvaziarBaralhoEDividirComJogadores()
        {
            // Arrange
            var baralho = new Baralho();
            baralho.AdicionarCarta(new Carta { Nacao = "Brasil" });
            baralho.AdicionarCarta(new Carta { Nacao = "Alemanha" });

            var jogadores = new List<Jogador>
            {
                new Jogador { Nome = "Jogador 1" },
                new Jogador { Nome = "Jogador 2" }
            };

            // Act
            baralho.DistribuirCartas(jogadores);

            // Assert
            Assert.AreEqual(1, jogadores[0].Cartas.Count, "Jogador 1 deve receber 1 carta.");
            Assert.AreEqual(1, jogadores[1].Cartas.Count, "Jogador 2 deve receber 1 carta.");
            Assert.AreEqual(0, baralho.Cartas.Count, "O baralho principal deve ficar vazio.");
        }
    }
}