using System;
using System.Collections.Generic;
using System.Text;

namespace Paises_SuperTrunfo
{
    public class Carta
    {
        public string Nacao { get; set; } = string.Empty;
        public decimal Pib { get; set; }
        public int Tamanho { get; set; }
        public long Populacao { get; set; }
        public float Idh { get; set; }
        public bool IsSuperTrunfo { get; set; }
        public string TipoCarta { get; set; } = string.Empty;

        public decimal ObterValorAtributo(int opcao)
        {
            return opcao switch
            {
                1 => Pib,
                2 => (decimal)Tamanho,
                3 => (decimal)Populacao,
                4 => (decimal)Idh,
                _ => 0m
            };

        }
    }
}