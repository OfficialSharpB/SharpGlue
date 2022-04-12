/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

using SFML.Graphics;
using SharpGlue.Base;

using System.IO;

namespace SharpGlue.Core.Graphics
{
    public class Texture2D : Texture, ILoadableContent
    {
        /// <summary>
        /// Gets the name of this texture.
        /// </summary>
        public string Name => name;
        string name;

        /// <summary>
        /// Gets the path of this texture.
        /// </summary>
        public string Path => path;
        string path;

        /// <summary>
        /// Initialize a new instance of <see cref="Texture2D"/>
        /// </summary>
        /// <param name="filename"></param>
        public Texture2D(string filename) : base(filename) {
            name = System.IO.Path.GetFileNameWithoutExtension(filename);
            path = filename;
        }
        /// <summary>
        /// Initialize a new instance of <see cref="Texture2D"/>
        /// </summary>
        public Texture2D(Image image) : base(image) {
        }
    }
}
