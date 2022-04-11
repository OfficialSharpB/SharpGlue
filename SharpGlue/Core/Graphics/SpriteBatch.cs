/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SFML.Graphics;

using SharpGlue.Core.Exceptions;

namespace SharpGlue.Core.Graphics
{
    /// <summary>
    /// Represents a drawable component for drawing graphics, and text onto <see cref="Game"/>
    /// </summary>
    public class SpriteBatch
    {
        bool ready = false;
        GraphicsDevice graphicsDevice;

        /// <summary>
        /// Gets the graphics device.
        /// </summary>
        public GraphicsDevice GraphicsDevice => graphicsDevice;

        /// <summary>
        /// Initialize a new instance of <see cref="SpriteBatch"/>
        /// </summary>
        /// <param name="graphicsDevice"></param>
        public SpriteBatch(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;
        }

        /// <summary>
        /// Begin drawing.
        /// </summary>
        /// <exception cref="SpriteBatchException"></exception>
        public void Begin() {
            if (ready)
                throw new SpriteBatchException(this, "End() must be called for starting to draw again");

            ready = true;
        }

        /// <summary>
        /// End drawing.
        /// </summary>
        /// <exception cref="SpriteBatchException"></exception>
        public void End() {
            if (!ready)
                throw new SpriteBatchException(this, "Begin() must be called before ending the drawing process.");

            ready = false;
        }

        /// <summary>
        /// Draws a string on screen.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <exception cref="SpriteBatchException"></exception>
        public void DrawString(SpriteFont font, string text, Vector2 position, Color color) {
            if (!ready)
                throw new SpriteBatchException(this, "Call begin before starting draw.");

            var graphics = graphicsDevice.renderWindow;
            graphics.Draw(
                SpriteFontHelper.GenerateText(font, text, position, color)
            );
        }

        /// <summary>
        /// Draws a texture.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="sourceRectangle"></param>
        /// <param name="color"></param>
        /// <param name="origin"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public void Draw(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color color, Vector2 origin, float rotation, float scale) {
            if (!ready)
                throw new SpriteBatchException(this, "Call begin before starting draw.");

            var graphics = graphicsDevice.renderWindow;

            Sprite sprite = new Sprite(texture);
            sprite.Position = new SFML.System.Vector2f(position.X, position.Y);
            sprite.Rotation = rotation;
            sprite.Scale = new SFML.System.Vector2f(scale, scale);
            sprite.Origin = new SFML.System.Vector2f(origin.X, origin.Y);
            sprite.TextureRect = RectangleConverter.ToSFMLIntRect(sourceRectangle);
            graphics.Draw(sprite);
        }

        /// <summary>
        /// Draws a texture.
        /// </summary>
        public void Draw(Texture2D texture, Vector2 position, Color color, Vector2 origin, float rotation, float scale) =>
            Draw(texture, position, new Rectangle(0, 0, (int)texture.Size.X, (int)texture.Size.Y), color, origin, rotation, scale);

        /// <summary>
        /// Draws a texture.
        /// </summary>
        public void Draw(Texture2D texture, Vector2 position, Color color, Vector2 origin, float rotation) =>
            Draw(texture, position, color, origin, rotation, 1);

        /// <summary>
        /// Draws a texture.
        /// </summary>
        public void Draw(Texture2D texture, Vector2 position, Color color, Vector2 origin) =>
            Draw(texture, position, color, origin, 0f);

        /// <summary>
        /// Draws a texture.
        /// </summary>
        public void Draw(Texture2D texture, Vector2 position, Color color) =>
            Draw(texture, position, color, Vector2.Zero);

        /// <summary>
        /// Draws a texture.
        /// </summary>
        public void Draw(Texture2D texture, Rectangle sourceRectangle, Color color) {
            Vector2 position = new Vector2(sourceRectangle.X, sourceRectangle.Y);
            Draw(texture, position, sourceRectangle, color, Vector2.Zero, 0f, 1f);
        }
    }
}
