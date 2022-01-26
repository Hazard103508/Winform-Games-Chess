using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Elements
{
    /// <summary>
    /// Clase con la informacion de un jugador de la partida
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Instancia a un juegador
        /// </summary>
        /// <param name="color">Color de fichas a utilizar</param>
        /// <param name="type">Tipo de jugador</param>
        public Player(Piece_Color color, Player_Type type, int number)
        {
            this.Color = color;
            this.Type = type;
            this.Number = number;
        }

        /// <summary>
        /// Color de fichas que utiliza el jugador
        /// </summary>
        public Piece_Color Color { get; set; }
        /// <summary>
        /// Tipo de jugador
        /// </summary>
        public Player_Type Type { get; set; }
        /// <summary>
        /// Numero de jugador
        /// </summary>
        public int Number { get; set; }
    }

    public enum Player_Type
    {
        Cpu,
        Human
    }
}
