/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using System;
using System.ComponentModel.DataAnnotations;

namespace SharpGlue.Core.Graphics
{
    /// <summary>
    /// Represents a manager for <see cref="GraphicsDevice"/>
    /// </summary>
    public class GraphicsDeviceManager
    {
        int defaultHeight = 800;
        int defaultWidth = 600;
        bool vsync = false;

        Game game;

        /// <summary>
        /// Gets or sets the prefered back buffer width.
        /// </summary>
        public int PreferedBackBufferWidth
        {
            get => defaultWidth;
            set => defaultWidth = value;
        }

        /// <summary>
        /// Gets or sets the prefered back buffer height.
        /// </summary>
        public int PreferedBackBufferHeight
        {
            get => defaultHeight;
            set => defaultHeight = value;
        }

        /// <summary>
        /// Gets or sets weather to use virtical sync, to prevent screen tearing.
        /// </summary>
        public bool VSyncronization
        {
            get => vsync;
            set => vsync = value;
        }

        /// <summary>
        /// Gets or sets weather the current <see cref="GraphicsDevice.renderWindow"/> is visible.
        /// </summary>
        public bool Visible
        {
            get;
            set;
        }
        /// <summary>
        /// Initialize a new instance of <see cref="GraphicsDeviceManager"/>
        /// </summary>
        /// <param name="game">The game.</param>
        public GraphicsDeviceManager(Game game) {
            if (game == null)
                throw new NullReferenceException("game");

            this.game = game;
        }

        /// <summary>
        /// Apply the current changes.
        /// </summary>
        public void ApplyChanges() {
            game.Window.renderWindow.Size = new SFML.System.Vector2u((uint)PreferedBackBufferWidth, (uint)PreferedBackBufferHeight);
            game.Window.renderWindow.SetVerticalSyncEnabled(vsync);
            game.Window.renderWindow.SetVisible(Visible);
        }
    }
}
