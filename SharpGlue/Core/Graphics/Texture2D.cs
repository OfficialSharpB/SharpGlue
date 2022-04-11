/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

using SFML.Graphics;
using SharpGlue.Base;


namespace SharpGlue.Core.Graphics
{
    public class Texture2D : Texture, IAsset
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Texture2D"/>
        /// </summary>
        /// <param name="filename"></param>
        public Texture2D(string filename) : base(filename) {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="Texture2D"/>
        /// </summary>
        public Texture2D(Image image) : base(image) {
        }
    }
}
