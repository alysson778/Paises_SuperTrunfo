using System;
using System.Collections.Generic;
using System.Text;

namespace Paises_SuperTrunfo
{
        public class Jogador
        {
            public string Nome { get; set; }

            public List<Carta> Cartas { get; set; }

            public Jogador()
            {
                Cartas = new List<Carta>();
            }
        }
    }
}
