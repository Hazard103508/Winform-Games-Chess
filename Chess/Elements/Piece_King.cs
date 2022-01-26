using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Elements
{
    public class Piece_King : Piece_Base
    {
        #region Constructor
        public Piece_King(Image image, Piece_Color color) : base(image, color)
        {
            Moves = new Piece_Move[]
            {
                new Piece_Move(-1,-1, false),
                new Piece_Move(-1,0, false),
                new Piece_Move(-1,1, false),
                new Piece_Move(0,-1, false),
                new Piece_Move(0,1, false),
                new Piece_Move(1,-1, false),
                new Piece_Move(1,0, false),
                new Piece_Move(1,1, false),
                new Piece_Move(2, 0, false, Move_Type.Special), // enroque
                new Piece_Move(-2, 0, false, Move_Type.Special),// enroque
            };
        }
        #endregion
    }
}
