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
    /// Pieza de ajedrez
    /// </summary>
    public abstract class Piece_Base : Sprite
    {
        #region Constructor
        public Piece_Base(Image image, Piece_Color color) : base(image, new Point())
        {
            this.Color = color;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Color de la pieza
        /// </summary>
        public Piece_Color Color { get; set; }
        /// <summary>
        /// Coordenada de la pieza en el tablero
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// Determina si la pieza esta seleccionada
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Movimientos que puede realizar la pieza en el tablero
        /// </summary>
        public Piece_Move[] Moves { get; set; }
        /// <summary>
        /// Movimientos habilitados
        /// </summary>
        public Point[] EnabledMoves { get; set; }
        /// <summary>
        /// Imagen a dibujar si la pieza esta seleccionada
        /// </summary>
        public Image SelectedImage { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Dibuja todos los sprites en pantalla
        /// </summary>
        /// <param name="drawHandler">controlador de dibujado</param>
        public override void Draw(DrawHandler drawHandler)
        {
            if (this.Selected)
                drawHandler.Draw(this.SelectedImage, this.Position);

            base.Draw(drawHandler);
        }
        #endregion
    }
    /// <summary>
    /// Informacion del movimiento que puede realizar una pieza
    /// </summary>
    public class Piece_Move
    {
        public Piece_Move(int x, int y, bool isLinear = true, Move_Type type = Move_Type.General)
        {
            this.Direction = new Point(x, y);
            this.Type = type;
            this.IsLinear = isLinear;
        }
        /// <summary>
        /// Direccion en la cual se realiza el movimiento
        /// </summary>
        public Point Direction { get; set; }
        /// <summary>
        /// Tipo de movimiento
        /// </summary>
        public Move_Type Type { get; set; }
        /// <summary>
        /// Determina si el movimiento es lineal
        /// </summary>
        public bool IsLinear { get; set; }
    }
    /// <summary>
    /// Tipo de movimiento que puede hacer una pieza
    /// </summary>
    public enum Move_Type
    {
        General = 1, // Movimiento y ataque a celda destino
        Special = 2 // Movimiento que depende de la posicion de la piesa en el tablero
    }
    /// <summary>
    /// Colores de las piezas 
    /// </summary>
    public enum Piece_Color
    {
        Black,
        White
    }
}
