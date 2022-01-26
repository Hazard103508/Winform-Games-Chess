using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Elements
{
    public class Piece_Queen : Piece_Base
    {
        #region Constructor
        public Piece_Queen(Image image, Piece_Color color) : base(image, color)
        {
            Moves = new Piece_Move[]
            {
                new Piece_Move(0,1),
                new Piece_Move(0,-1),
                new Piece_Move(1,0),
                new Piece_Move(-1,0),
                new Piece_Move(1,1),
                new Piece_Move(-1,1),
                new Piece_Move(1,-1),
                new Piece_Move(-1,-1),
            };
        }
        #endregion
    }
}
