/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

using SharpGlue.Core.Graphics;
using SharpGlue.Core.Input;

using System.Collections.Generic;

namespace SharpGlue.Core.Screen
{
    public class GameSceneManager : DrawableGameComponent
    {
        private readonly List<GameScene> _screens = new List<GameScene>();
        private readonly List<GameScene> _tempScreensList = new List<GameScene>();

        private readonly InputSystem _input = new InputSystem();

        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Texture2D _blankTexture;

        private bool _isInitialized;
        private bool _traceEnabled;

        private GraphicsDeviceManager _graphicsDeviceManager;


        /// <summary>
        /// Gets or sets the graphics device manager.
        /// </summary>
        public GraphicsDeviceManager GraphicsDeviceManager
        {
            get => _graphicsDeviceManager;
            set => _graphicsDeviceManager = value;
        }

        /// <summary>
        /// Gets the input.
        /// </summary>
        public InputSystem InputSystem
        {
            get => _input;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="GameSceneManager"/>
        /// </summary>
        /// <param name="game"></param>
        public GameSceneManager(Game game) : base(game) {
            _graphicsDeviceManager = new GraphicsDeviceManager(game);
        }

        public override void Initialize() {
            base.Initialize();
            _isInitialized = true;
        }

        public override void LoadContent() {

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Tell each of the screens to load their content.
            foreach (var screen in _screens) {
                screen.LoadContent(false);
            }
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            _input.Update();    // Read the keyboard and gamepad

            // Make a copy of the master screen list, to avoid confusion if
            // the process of updating one screen adds or removes others.
            _tempScreensList.Clear();

            foreach (var screen in _screens)
                _tempScreensList.Add(screen);

            bool otherScreenHasFocus = !this.GraphicsDevice.renderWindow.IsOpen;
            bool coveredByOtherScreen = false;

            // Loop as long as there are screens waiting to be updated.
            while (_tempScreensList.Count > 0) {
                // Pop the topmost screen off the waiting list.
                var screen = _tempScreensList[_tempScreensList.Count - 1];

                _tempScreensList.RemoveAt(_tempScreensList.Count - 1);

                screen.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

                if (screen.ScreenState == GameSceneState.TransitionOn || screen.ScreenState == GameSceneState.Active) {
                    // If this is the first active screen we came across,
                    // give it a chance to handle input.
                    if (!otherScreenHasFocus) {
                        screen.HandleInput(gameTime, _input);
                        otherScreenHasFocus = true;
                    }

                    // If this is an active non-popup, inform any subsequent
                    // screens that they are covered by it.
                    if (!screen.IsPopup)
                        coveredByOtherScreen = true;
                }
            }

        }

        /// <summary>
        /// Adds a screen.
        /// </summary>
        /// <param name="screen"></param>
        public void AddScreen(GameScene screen) { 
            screen.ScreenManager = this;
            screen.IsExiting = false;

            // If we have a graphics device, tell the screen to load content.
            if (_isInitialized)
                screen.LoadContent(false);

            _screens.Add(screen);
        }

        public override void Draw(GameTime gameTime) {
            base.Draw(gameTime);
            foreach (var screen in _screens) {
                if (screen.ScreenState == GameSceneState.Hidden)
                    continue;

                screen.Draw(gameTime, _spriteBatch);
            }
        }
        /// <summary>
        /// Remove a screen.
        /// </summary>
        /// <param name="screen"></param>
        public void RemoveScreen(GameScene screen) {
            // If we have a graphics device, tell the screen to unload content.
            if (_isInitialized)
                screen.Unload();

            _screens.Remove(screen);
            _tempScreensList.Remove(screen);
        }
    }
}
