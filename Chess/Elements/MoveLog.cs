using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Elements
{
    public class ActionLog
    {
        public ActionLog()
        {
            Moves = new List<MoveLog>();
            Removed_Pieces = new List<Piece_Base>();
        }

        /// <summary>
        /// Lista de movimientos realizados en el turno
        /// </summary>
        public List<MoveLog> Moves { get; set; }
        /// <summary>
        /// Pieza eliminada en el turno
        /// </summary>
        public List<Piece_Base> Removed_Pieces { get; set; }
        /// <summary>
        /// Pieza agregada en el turno (Coronacion de peon)
        /// </summary>
        public Piece_Base Added_Piece { get; set; }
    }
    public class MoveLog
    {
        /// <summary>
        /// Pieza que realizo el movimiento
        /// </summary>
        public Piece_Base Piece { get; set; }
        /// <summary>
        /// Coordenada en el tablero a donde estaba la pieza antes del movimiento
        /// </summary>
        public Point Original_Location { get; set; }
        /// <summary>
        /// Coordenada del tablero donde donde se desplazo la pieza
        /// </summary>
        public Point New_Location { get; set; }
    }
}
