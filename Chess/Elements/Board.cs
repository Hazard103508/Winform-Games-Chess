using Game.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Elements
{
    /// <summary>
    /// Informacion del tablero de juego
    /// </summary>
    public class Board : Sprite
    {
        #region Constructor
        public Board(Image whiteTileImage, Image blackTileImage, Image moveTileImage, int tileSize) : base(null, new Point())
        {
            this.TileSize = tileSize;
            this.Move_Image = moveTileImage;
            this.Image_BlackTiles = blackTileImage;
            this.Image_WhiteTiles = whiteTileImage;

            Cells = new BoardCell[8, 8];

            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    int _x = (x * this.TileSize) + 5 * (x + 1);
                    int _y = (y * this.TileSize) + 5 * (y + 1);

                    Cells[x, y] = new BoardCell()
                    {
                        ScreenPosition = new Point(_x, _y),
                    };
                    // indica la posision en pantalla que cada celda del tablero
                }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Tamaño de cada celda
        /// </summary>
        private int TileSize { get; set; }
        /// <summary>
        /// Celda negra del tablero
        /// </summary>
        public Image Image_BlackTiles { get; set; }
        /// <summary>
        /// Celda blanca del tablero
        /// </summary>
        public Image Image_WhiteTiles { get; set; }
        /// <summary>
        /// Imagen a dibujar en celdas que permiten el movimiento de la pieza
        /// </summary>
        private Image Move_Image { get; set; }
        /// <summary>
        /// Informacion de las celdas del tablero
        /// </summary>
        public BoardCell[,] Cells { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Desmarca las celdas que permiten movimiento
        /// </summary>
        public void Clear_EnabledMoves()
        {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    Cells[x, y].CanMove = false;
        }
        /// <summary>
        /// Dibuja todos los sprites en pantalla
        /// </summary>
        /// <param name="drawHandler">controlador de dibujado</param>
        public override void Draw(DrawHandler drawHandler)
        {
            drawHandler.Draw(this.Image, this.Position);

            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    Image _tile = (x + y) % 2 == 0 ? this.Image_WhiteTiles : this.Image_BlackTiles;
                    drawHandler.Draw(_tile, Cells[x, y].ScreenPosition);

                    if (Cells[x, y].CanMove)
                        drawHandler.Draw(this.Move_Image, Cells[x, y].ScreenPosition);
                }
        }
        #endregion
    }

    /// <summary>
    /// Informacion de la celda del tablero
    /// </summary>
    public class BoardCell
    {
        /// <summary>
        /// Posicion en pantalla de la celda
        /// </summary>
        public Point ScreenPosition { get; set; }
        /// <summary>
        /// Determina si la ficha seleccionada puede moverse a esta celda
        /// </summary>
        public bool CanMove { get; set; }
    }
}
