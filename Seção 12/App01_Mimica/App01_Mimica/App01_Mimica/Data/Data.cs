using App01_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App01_Mimica.Data
{
    public static class Data
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras =
        {
            // Fáceis - 1
            new string[] { "Olho", "Língua", "Chinelo", "Milho", "Penalti", "Bola", "Ping-pong" },
            // Médias - 3
            new string[] { "Carpinteiro", "Amarelo", "Limão", "Abelha", "Pedreiro", "Floresta", "Futebol" },
            // Difíceis - 5
            new string[] { "Cisterna", "Lanterna", "Batman", "Superman", "Notebook", "Tentar", "Buscar" },
        };
    }
}
