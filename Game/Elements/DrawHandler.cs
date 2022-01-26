using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Elements
{
    /// <summary>
    /// Clase con la logica de dibujado
    /// </summary>
    public class DrawHandler: IDisposable
    {
        public DrawHandler(int width, int height)
        {
            BaseImage = new Bitmap(width, height);
            Graphics = System.Drawing.Graphics.FromImage(BaseImage);
        }

        /// <summary>
        /// Imagen base sobre la cual se dibujan las demas imagenes
        /// </summary>
        public Image BaseImage { get; private set; }
        /// <summary>
        /// Clase con funciones de dibujado
        /// </summary>
        private System.Drawing.Graphics Graphics { get; set; }

        public void Dispose()
        {
            Graphics.Dispose();
            BaseImage = null;
        }
        /// <summary>
        /// Dibuja una imagen en pantalla
        /// </summary>
        /// <param name="image">Imagen a dibujar</param>
        /// <param name="position">Posicion de la imagen en pantalla</param>
        public void Draw(Image image, Point position)
        {
            Graphics.DrawImage(image, position.X, position.Y, image.Width, image.Height);
        }
    }
}
