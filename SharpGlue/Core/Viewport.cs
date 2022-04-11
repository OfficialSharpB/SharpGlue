/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using System.Runtime.CompilerServices;

namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a simple view port. 
    /// consisting of width, height, x, and y.
    /// </summary>
    public class Viewport
    {
        int left, right, top, bottom;
        int width, height, x, y;

        /// <summary>
        /// Left side
        /// </summary>
        public int Left => x;
        /// <summary>
        /// Right side
        /// </summary>
        public int Right => x + width;

        /// <summary>
        /// Top face 
        /// </summary>
        public int Top => y;

        /// <summary>
        /// Bottom face 
        /// </summary>
        public int Bottom => y + height;

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int Width
        {
            get => width;
            set => width = value;
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height
        {
            get => height;
            set => height = value;
        }

        /// <summary>
        /// Gets or sets the x position.
        /// </summary>
        public int X
        {
            get => x;
            set => x = value;
        }

        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        public int Y
        {
            get => y;
            set => y = value;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Viewport"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Viewport(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
