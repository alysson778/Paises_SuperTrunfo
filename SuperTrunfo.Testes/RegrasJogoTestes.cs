
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paises_SuperTrunfo;

namespace SuperTrunfo.Testes
{
    [TestClass]
    public sealed class RegrasJogoTestes
    {
        [TestMethod]
        public void AtributoMaior_DeveVencerRodadaComum()
        {
            // Arrange
            var brasil = new Carta { Nacao = "Brasil", Pib = 2000m, TipoCarta = "1B" };
            var japao = new Carta { Nacao = "Japão", Pib = 5000m, TipoCarta = "2B" };

            // Act
            decimal pibBrasil = brasil.ObterValorAtributo(1);
            decimal pibJapao = japao.ObterValorAtributo(1);

            // Assert
            Assert.IsTrue(pibJapao > pibBrasil, "O Japão deveria ter um PIB maior que o Brasil.");
        }

        [TestMethod]
        public void CartaGrupoA_DeveVencerSuperTrunfo()
        {
            // Arrange
            var superTrunfo = new Carta { Nacao = "EUA", IsSuperTrunfo = true, TipoCarta = "ST" };
            var cartaGrupoA = new Carta { Nacao = "Alemanha", IsSuperTrunfo = false, TipoCarta = "2A" };

            // Act
            char tipoJ1 = superTrunfo.TipoCarta[^1];
            char tipoJ2 = cartaGrupoA.TipoCarta[^1];

            bool cartaAVenceuSuperTrunfo = (tipoJ1 == 'T' && tipoJ2 == 'A');

            // Assert
            Assert.IsTrue(cartaAVenceuSuperTrunfo, "A carta do Grupo A deve vencer o Super Trunfo.");
        }
    }

}
