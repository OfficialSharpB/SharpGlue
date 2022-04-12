using SFML.Graphics;
using SFML.System;

using SharpGlue.Core.Content;
using SharpGlue.Core.Graphics;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpGlue.Core
{
    public class Game : IDisposable
    {
        GameWindow window;
        GraphicsDevice device;
        GameTime gameTime;
        ServiceContainer services;
        Stopwatch _gameTimer;
        bool _initalized;
        List<DrawableGameComponent> components;
        ContentManager content;

        const int _target = 60;
        float timeTillNextFrame = 1f / _target;

        bool _isMouseVisable = false;

        /// <summary>
        /// Gets the content.
        /// </summary>
        public ContentManager Content
        {
            get => content;
        }

        /// <summary>
        /// Gets or sets a bool value indercating weather the mouse is visable.
        /// </summary>
        public bool IsMouseVisable
        {
            get => _isMouseVisable;
            set {
                if (window.renderWindow == null)
                    return;

                window.renderWindow.SetMouseCursorVisible(value);
                _isMouseVisable = value;
            }
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        public ServiceContainer Services
        {
            get => services;
        }

        /// <summary>
        /// Gets the window.
        /// </summary>
        public GameWindow Window
        {
            get => window;
        }

        /// <summary>
        /// Gets the <see cref="GraphicsDevice"/>
        /// </summary>
        public GraphicsDevice GraphicsDevice
        {
            get => device;
        }

        /// <summary>
        /// Gets the components.
        /// </summary>
        public List<DrawableGameComponent> Components
        {
            get => components;
        }

        public Game() {
            window = new GameWindow();
            services = new ServiceContainer();
            _gameTimer = new Stopwatch();

            components = new List<DrawableGameComponent>();
        }


        public virtual void Update(GameTime gameTime) {
            foreach (var component in components)
                component.Update(gameTime);
        }
        public virtual void Draw(GameTime gameTime) {
            foreach (var component in components)
                component.Draw(gameTime);
        }
        public virtual void LoadContent() {
            foreach (var component in components)
                component.LoadContent();
        }
        public virtual void Initialize() {

            content = new ContentManager(services);

            foreach (var component in components)
                component.Initialize();
        }

        public void Run() {
            gameTime = new GameTime();

            if (!_initalized) {

                window.renderWindow = GameWindow.CreateWindow(window.Title, window.Resizable);
                device = new GraphicsDevice(this);
                services.AddService<GraphicsDevice>(device);

                _gameTimer.Start();

                Initialize();
                LoadContent();

                _initalized = true;
            }

            _doRun();
        }

        private void _doRun() {

            // so we can close the window.
            window.renderWindow.Closed += (s, e) => { window.renderWindow.Close(); };

            float totalTimeBeforeUpdate = 0f;
            float previousTimeEnlapsed = 0,
                deltaTime = 0, totalTimeEnlapsed = 0;

            _gameTimer.Reset();
            _gameTimer.Start();
            while (window.renderWindow.IsOpen) {
                window.renderWindow.DispatchEvents();

                totalTimeEnlapsed = _gameTimer.Elapsed.Seconds;
                deltaTime = totalTimeEnlapsed - previousTimeEnlapsed;
                previousTimeEnlapsed = totalTimeEnlapsed;
                totalTimeBeforeUpdate += deltaTime;

                if(totalTimeEnlapsed >= timeTillNextFrame) {
                    Update(gameTime);

                    gameTime.update(TimeSpan.FromSeconds(totalTimeBeforeUpdate), deltaTime);

                    totalTimeBeforeUpdate = 0f;

                    Draw(gameTime);

                    window.renderWindow.Display();
                }
            }
        }

        /// <summary>
        /// Reset the current game time.
        /// </summary>
        public void ResetEnlapsedTime() {
            if(_gameTimer != null) {
                _gameTimer.Reset();
                _gameTimer.Start();
            }
        }

        public void Dispose() {
            if (window.renderWindow.IsOpen)
                window.renderWindow.Close();

            window.renderWindow.Dispose();
            _gameTimer.Stop();
        }
    }
}
