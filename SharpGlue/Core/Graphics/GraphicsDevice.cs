/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SFML.Graphics;
using SharpGlue.Base;

using System.Threading;

namespace SharpGlue.Core.Graphics
{
    /// <summary>
    /// Represents a graphics device.
    /// </summary>
    public class GraphicsDevice : IServiceProvider
    {
        Viewport viewPort;
        Game game;
        internal RenderWindow renderWindow;
        public string ServiceName => "GraphicsDevice";

        /// <summary>
        /// Initialize a new instance of <see cref="GraphicsDevice"/>
        /// </summary>
        /// <param name="game"></param>
        /// <exception cref="NullReferenceException"></exception>
        public GraphicsDevice(Game game) {
            if (game == null)
                throw new System.NullReferenceException("game");

            this.game = game;
            renderWindow = this.game.Window.renderWindow;
            renderWindow.Resized += (s, e) =>
            {
                ViewPort.Width = (int)e.Width;
                viewPort.Height = (int)e.Height;
            };
        }


        /// <summary>
        /// Gets or sets the view port.
        /// </summary>
        public Viewport ViewPort
        {
            get => viewPort;
            set {
                if (renderWindow == null)
                    return;
                renderWindow.SetView(new View(new FloatRect(value.Left, value.Top, value.Width, value.Height)));
                renderWindow.Size = new SFML.System.Vector2u((uint)value.Width, (uint)value.Height);
                viewPort = value;
            }
        }

        /// <summary>
        /// Clears the buffer with a solid color.
        /// </summary>
        /// <param name="color"></param>
        public void Clear(Color color) {
            renderWindow.Clear(ColorConverter.ToSFML(color));
        }
    }
}
