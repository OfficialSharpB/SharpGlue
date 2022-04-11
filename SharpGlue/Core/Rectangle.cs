using SFML.Graphics;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static SFML.Window.Mouse;

namespace SharpGlue.Core
{
    public class Rectangle : Viewport, IEquatable<Rectangle>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Rectangle"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(int x, int y, int width, int height) : base(x, y, width, height) {
        }

        public bool Equals(Rectangle other) {
            return (other.X == X && other.Y == Y
                    && other.Width == Width && other.Height == Height);
        }
    }

    public static class RectangleConverter
    {
        /// <summary>
        /// Converts a <see cref="Rectangle"/> to a <see cref="SFML.Graphics.IntRect"/>
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static IntRect ToSFMLIntRect(Rectangle rectangle) {
            return new IntRect(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        /// Inflate this rectangle with a horizontal, and virtical value.
        /// </summary>
        /// <param name="horizontalInflate"></param>
        /// <param name="virticalInflate"></param>
        public static void Inflate(this Rectangle rect, int horizontalInflate, int virticalInflate) {
            rect.X += horizontalInflate;
            rect.Y += virticalInflate;
            rect.Width += horizontalInflate * 2;
            rect.Height += virticalInflate * 2;
        }

        /// <summary>
        /// Gets a <see cref="bool"/> value indercating weather this <see cref="Rectangle"/> interacts or touchs another <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool Interact(this Rectangle rect, Rectangle value) {
            if (value == null)
                throw new ArgumentNullException("rectangle");

            return
               value.Left < rect.Right &&
                   rect.Left < value.Right &&
                   value.Top < rect.Bottom &&
                   rect.Top < value.Bottom;
        }

    }
}
