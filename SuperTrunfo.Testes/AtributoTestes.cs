
using Paises_SuperTrunfo;

namespace SuperTrunfo.Testes
{
    [TestClass]
    public sealed class AtributoTestes
    {
        [TestMethod]
        public void ObterValorAtributo_Opcao1_DeveRetornarPib()
        {
            // Arrange (Preparação)
            var carta = new Carta { Nacao = "Brasil", Pib = 1920000000000m };

            // Act (Ação)
            decimal resultado = carta.ObterValorAtributo(1);

            // Assert (Verificação)
            Assert.AreEqual(1920000000000m, resultado);
        }

        [TestMethod]
        public void ObterValorAtributo_Opcao2_DeveRetornarTamanho()
        {
            // Arrange
            var carta = new Carta { Nacao = "Brasil", Tamanho = 8515767 };

            // Act
            decimal resultado = carta.ObterValorAtributo(2);

            // Assert
            Assert.AreEqual(8515767m, resultado);
        }
    }
}