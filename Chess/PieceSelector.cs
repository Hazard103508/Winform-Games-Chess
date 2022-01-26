using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class PieceSelector : Form
    {
        #region Constructor
        /// <summary>
        /// Formulario donde se selecciona la pieza en la cual se convertira el peon
        /// </summary>
        /// <param name="resources">Recursos graficos del juego</param>
        /// <param name="color">Color de la pieza</param>
        public PieceSelector(Elements.Resources resources, Elements.Piece_Color color)
        {
            InitializeComponent();
            this.Color = color;

            if (color == Elements.Piece_Color.White)
            {
                pcQueen.Image = resources.Image_White_Queen;
                pcBishop.Image = resources.Image_White_Bishop;
                pcKnight.Image = resources.Image_White_Knight;
                pcRock.Image = resources.Image_White_Rook;
            }
            else
            {
                pcQueen.Image = resources.Image_Black_Queen;
                pcBishop.Image = resources.Image_Black_Bishop;
                pcKnight.Image = resources.Image_Black_Knight;
                pcRock.Image = resources.Image_Black_Rook;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Color de la pieza
        /// </summary>
        private Elements.Piece_Color Color { get; set; }
        /// <summary>
        /// Pieza seleccionada
        /// </summary>
        public Elements.Piece_Base Selected_Piece { get; set; }
        #endregion

        #region Events
        private void pcQueen_Click(object sender, EventArgs e)
        {
            Selected_Piece = new Elements.Piece_Queen(pcQueen.Image, this.Color);
            Close();
        }

        private void pcBishop_Click(object sender, EventArgs e)
        {
            Selected_Piece = new Elements.Piece_Bishop(pcBishop.Image, this.Color);
            Close();
        }

        private void pcKnight_Click(object sender, EventArgs e)
        {
            Selected_Piece = new Elements.Piece_Knight(pcKnight.Image, this.Color);
            Close();
        }

        private void pcRock_Click(object sender, EventArgs e)
        {
            Selected_Piece = new Elements.Piece_Rook(pcRock.Image, this.Color);
            Close();
        }
        #endregion
    }
}
