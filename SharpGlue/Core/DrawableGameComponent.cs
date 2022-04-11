/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SharpGlue.Core.Graphics;

using System;

namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a drawable game component.
    /// </summary>
    public class DrawableGameComponent
    {
        Game game;

        /// <summary>
        /// Gets the graphics device.
        /// </summary>
        public GraphicsDevice GraphicsDevice
        {
            get => game.GraphicsDevice;
        }

        /// <summary>
        /// Initalize a new instance of <see cref="DrawableGameComponent"/>
        /// </summary>
        /// <param name="game"></param>
        /// <exception cref="NullReferenceException"></exception>
        public DrawableGameComponent(Game game) {
            if (game == null)
                throw new NullReferenceException("game");
            this.game = game;
        }

        public virtual void Initialize() { }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void LoadContent() { }
    }
}
