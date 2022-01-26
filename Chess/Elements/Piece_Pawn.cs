using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Elements
{
    public class Piece_Pawn : Piece_Base
    {
        #region Constructor
        public Piece_Pawn(Image image, Piece_Color color) : base(image, color)
        {
            Moves = new Piece_Move[]
            {
                new Piece_Move(0,-1, false, Move_Type.Special), // al frente solo puede mover, no atacar
                new Piece_Move(0,-2, false, Move_Type.Special), // al frente 2 casilleros solo puede mover, no atacar y se puede realizar si es el primer movimiento del peon
                new Piece_Move(-1,-1, false, Move_Type.Special), // en diagonal solo puede atacar, no mover
                new Piece_Move(1,-1, false, Move_Type.Special), // en diagonal solo puede atacar, no mover
            };
        }
        #endregion
    }
}
