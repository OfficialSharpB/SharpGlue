/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SFML.Graphics;

using SharpGlue.Base;

using System.Drawing;

namespace SharpGlue.Core.Graphics
{
    /// <summary>
    /// Represents a font.
    /// </summary>
    public class SpriteFont : ILoadableContent
    {
        int size;

        /// <summary>
        /// Gets the name of the font.
        /// </summary>
        public string Name
        {
            get {
                return System.IO.Path.GetFileNameWithoutExtension(Path);
            }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Path
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the size of the font.
        /// </summary>
        public int Size
        {
            get => size;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="SpriteFont"/>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="size"></param>
        public SpriteFont(string path, int size) {
            this.Path = path;
            this.size = size;
        }

        /// <summary>
        /// Mesures a peice of text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Vector2 MesureString(string text) {
            var generate = SpriteFontHelper.GenerateText(this, text);
            var texture = generate.Font.GetTexture((uint)size);

            return new Vector2(texture.Size.X, texture.Size.Y);
        }
    }

    public static class SpriteFontHelper
    {
        /// <summary>
        /// Convert this spritefont to a normal font.
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public static SFML.Graphics.Font ToSFML(SpriteFont font) {
            return new SFML.Graphics.Font(font.Path);
        }

        /// <summary>
        /// Generates a text object from <see cref="SFML.Graphics.Text"/>
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static SFML.Graphics.Text GenerateText(SpriteFont font, string text, Vector2 position, Color color) {
            SFML.Graphics.Text t = new SFML.Graphics.Text(text, SpriteFontHelper.ToSFML(font), (uint)font.Size);
            t.Position = new SFML.System.Vector2f(position.X, position.Y);
            t.FillColor = ColorConverter.ToSFML(color);
            return t;
        }

        /// <summary>
        /// Generates a text object from <see cref="SFML.Graphics.Text"/>
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static SFML.Graphics.Text GenerateText(SpriteFont font, string text) {
            SFML.Graphics.Text t = new SFML.Graphics.Text(text, SpriteFontHelper.ToSFML(font), (uint)font.Size);
            return t;
        }
    }
}
