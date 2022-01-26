using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Elements
{
    public class Piece_Bishop : Piece_Base
    {
        #region Constructor
        public Piece_Bishop(Image image, Piece_Color color) : base(image, color)
        {
            Moves = new Piece_Move[]
            {
                new Piece_Move(1,1),
                new Piece_Move(-1,1),
                new Piece_Move(1,-1),
                new Piece_Move(-1,-1),
            };
        }
        #endregion
    }
}
