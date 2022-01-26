using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Elements
{
    /// <summary>
    /// Clase que carga los recursos del juego
    /// </summary>
    public class Resources
    {
        /// <summary>
        /// Imagen del tablero
        /// </summary>
        public Image Image_BoardTiles { get; set; }
        /// <summary>
        /// Imagen de la celda de color celeste que se muestra cuando la celda acepta el movimiento de la pieza seleccionada
        /// </summary>
        public Image Image_MoveTiles { get; set; }
        /// <summary>
        /// Imagen de la celda de color verde que se muestra cuando se seleecciona la ficha
        /// </summary>
        public Image Image_SelectedTile { get; set; }
        /// <summary>
        /// Imagen del peon Blanco
        /// </summary>
        public Image Image_WhitePawn { get; set; }
        /// <summary>
        /// Imagen de la Torre Blanca
        /// </summary>
        public Image Image_White_Rook { get; set; }
        /// <summary>
        /// Imagen del Caballo Blanco
        /// </summary>
        public Image Image_White_Knight { get; set; }
        /// <summary>
        /// Imagen del Alfil Blanco
        /// </summary>
        public Image Image_White_Bishop { get; set; }
        /// <summary>
        /// Imagen de la Reina Blanca
        /// </summary>
        public Image Image_White_Queen { get; set; }
        /// <summary>
        /// Imagen del Rey Blanco
        /// </summary>
        public Image Image_White_King { get; set; }
        /// <summary>
        /// Imagen del Peon Negro
        /// </summary>
        public Image Image_BlackPawn { get; set; }
        /// <summary>
        /// Imagen de la Torre Negra
        /// </summary>
        public Image Image_Black_Rook { get; set; }
        /// <summary>
        /// Imagen del caballo Negro
        /// </summary>
        public Image Image_Black_Knight { get; set; }
        /// <summary>
        /// Imagen del Alfil Negro
        /// </summary>
        public Image Image_Black_Bishop { get; set; }
        /// <summary>
        /// Imagen de la Reina Negra
        /// </summary>
        public Image Image_Black_Queen { get; set; }
        /// <summary>
        /// Imagen del Rey Negro
        /// </summary>
        public Image Image_Black_King { get; set; }
    }
}
