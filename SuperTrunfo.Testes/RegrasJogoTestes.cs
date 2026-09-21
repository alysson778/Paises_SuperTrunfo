using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paises_SuperTrunfo;

namespace SuperTrunfo.Testes
{
    [TestClass]
    public sealed class RegrasJogoTestes
    {
        private LogicaDoJogo logica = null!;

        // Mini baralho de teste: só as 3 cartas necessárias
        // Os PIBs foram escolhidos para o teste provar a REGRA do Super Trunfo, e não só o valor do atributo:
        // carta A (1000) < Super Trunfo (3000) < carta B (5000)
        private Carta superTrunfo = null!;
        private Carta cartaA = null!;
        private Carta cartaB = null!;

        [TestInitialize]
        public void Preparar()
        {
            logica = new LogicaDoJogo();

            superTrunfo = new Carta { Nacao = "Estados Unidos", Pib = 3000m, IsSuperTrunfo = true, TipoCarta = "ST" };
            cartaA = new Carta { Nacao = "Brasil", Pib = 1000m, IsSuperTrunfo = false, TipoCarta = "1A" };
            cartaB = new Carta { Nacao = "Japão", Pib = 5000m, IsSuperTrunfo = false, TipoCarta = "1B" };
        }

        [TestMethod]
        public void MaiorAtributo_Jogador1_DeveVencer()
        {
            // Act: Japão (PIB 5000) contra Brasil (PIB 1000), atributo 1 = PIB
            logica.VerificarCartas(cartaB, cartaA, 1);

            // Assert
            Assert.AreEqual(2, logica.Jogadores[0].Cartas.Count, "Jogador 1 deveria ter vencido.");
            Assert.AreEqual(0, logica.Jogadores[1].Cartas.Count);
        }

        [TestMethod]
        public void MaiorAtributo_Jogador2_DeveVencer()
        {
            // Act: Brasil (PIB 1000) contra Japão (PIB 5000)
            logica.VerificarCartas(cartaA, cartaB, 1);

            // Assert
            Assert.AreEqual(0, logica.Jogadores[0].Cartas.Count);
            Assert.AreEqual(2, logica.Jogadores[1].Cartas.Count, "Jogador 2 deveria ter vencido.");
        }

        [TestMethod]
        public void SuperTrunfo_DevePerderParaCartaA()
        {
            // Act
            logica.VerificarCartas(superTrunfo, cartaA, 1);

            // Assert: quem tinha a carta A (Jogador 2) leva as duas cartas
            Assert.AreEqual(0, logica.Jogadores[0].Cartas.Count);
            Assert.AreEqual(2, logica.Jogadores[1].Cartas.Count, "A carta A deveria vencer o Super Trunfo.");
        }

        [TestMethod]
        public void SuperTrunfo_DeveVencerCartaB()
        {
            // Act: o PIB da carta B é maior, mas o Super Trunfo vence mesmo assim
            logica.VerificarCartas(superTrunfo, cartaB, 1);

            // Assert: quem tinha o Super Trunfo (Jogador 1) leva as duas cartas
            Assert.AreEqual(2, logica.Jogadores[0].Cartas.Count, "O Super Trunfo deveria vencer a carta B.");
            Assert.AreEqual(0, logica.Jogadores[1].Cartas.Count);
        }
        [TestMethod]
        public void Empate_CadaJogadorDeveFicarComASuaCarta()
        {
            // Act: duas cartas com o mesmo PIB
            var cartaB2 = new Carta { Nacao = "Alemanha", Pib = 5000m, TipoCarta = "2B" };
            logica.VerificarCartas(cartaB, cartaB2, 1);

            // Assert
            Assert.AreEqual(1, logica.Jogadores[0].Cartas.Count);
            Assert.AreEqual(1, logica.Jogadores[1].Cartas.Count);
        }
    }
}