/*
 * SharpBoy - a cross platform application made to support games for sfml using this engine, 
 * aswell as emulator plugins.
 * 
 * Developer: StephenFox.
 * Website: sharpboy.org.
*/
namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a size, including width, height.
    /// </summary>
    public class Size
    {
        int width, height;

        /// <summary>
        /// Gets or sets the width of this <see cref="Size"/>
        /// </summary>
        public int Width
        {
            get => width;
            set => width = value;
        }

        /// <summary>
        /// Gets or sets the height of this <see cref="Size"/>
        /// </summary>
        public int Height
        {
            get => height;
            set => height = value;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Size"/>
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Size(int width, int height) {
            this.width = width;
            this.height = height;
        }
    }
}
