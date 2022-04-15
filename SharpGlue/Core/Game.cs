using SFML.Graphics;
using SFML.System;

using SharpGlue.Core.Content;
using SharpGlue.Core.EventArgs;
using SharpGlue.Core.Graphics;

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        ComponentCollection components;
        ContentManager content;

        const int _target = 60;
        float timeTillNextFrame = 1f / _target;

        bool _isMouseVisable = false;
        IntPtr? _handle;
        GameContext _contextSetting;

        bool isFocused;


        /// <summary>
        /// This event is raised before Run is called.
        /// </summary>
        public event GameEventHandler BeforeRun;

        /// <summary>
        /// Raised when the current game has lost focus.
        /// </summary>
        public event GameEventHandler LostFocus;


        /// <summary>
        /// Raised when the current game has focused.
        /// </summary>
        public event GameEventHandler Focused;


        /// <summary>
        /// Gets a bool value indercating whether this <see cref="Game"/> has focus.
        /// </summary>
        /// <remarks>True; if <see cref="Game"/> has focus, otherwise false.</remarks>
        public bool IsFocused
        {
            get => isFocused;
        }

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
        public ComponentCollection Components
        {
            get => components;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Game"/>
        /// </summary>
        public Game() {
            window = new GameWindow();
            services = new ServiceContainer();
            _gameTimer = new Stopwatch();

            components = new ComponentCollection();
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Game"/>
        /// </summary>
        public Game(GameContext context) {
            window = new GameWindow();
            services = new ServiceContainer();
            _gameTimer = new Stopwatch();

            components = new ComponentCollection();

            _contextSetting = context;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Game"/>
        /// </summary>
        /// <param name="handle">
        /// The handle of the os specific window. 
        /// You could use Form1.Handle, ect. For this.
        /// </param>
        public Game(IntPtr handle) {
            window = new GameWindow();
            services = new ServiceContainer();
            _gameTimer = new Stopwatch();

            components = new ComponentCollection();

            _handle = handle;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Game"/>
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="context"></param>
        public Game(IntPtr handle, GameContext context) {
            window = new GameWindow();
            services = new ServiceContainer();
            _gameTimer = new Stopwatch();

            components = new ComponentCollection();

            _handle = handle;
            _contextSetting = context;
        }


        public virtual void Update(GameTime gameTime) {
            for (int i = 0; i < components.Count; i++)
                if (components[i] is DrawableGameComponent)
                    ((DrawableGameComponent)components[i]).Update(gameTime);
        }
        public virtual void Draw(GameTime gameTime) {
            for (int i = 0; i < components.Count; i++)
                if (components[i] is DrawableGameComponent)
                    if( i == components[i].DrawOrder )
                        ((DrawableGameComponent)components[i]).Draw(gameTime);
        }
        public virtual void LoadContent() {
            for (int i = 0; i < components.Count; i++)
                if (components[i] is DrawableGameComponent)
                    ((DrawableGameComponent)components[i]).LoadContent();
        }
        public virtual void Initialize() {

            content = new ContentManager(services);

            for (int i = 0; i < components.Count; i++)
                if (components[i] is DrawableGameComponent)
                    ((DrawableGameComponent)components[i]).Initialize();
        }

        public void Run() {

            BeforeRun?.Invoke(new GameEventArgs(this));

            gameTime = new GameTime();

            if (!_initalized) {

                if (_handle == null)
                    if (_contextSetting == null)
                        window.renderWindow = GameWindow.CreateWindow(window.Title, window.Resizable);
                    else
                        window.renderWindow = GameWindow.CreateWindow(window.Title, window.Resizable, _contextSetting);
                else
                    if (_contextSetting == null)
                        window.renderWindow = GameWindow.CreateWindow(_handle.Value);
                    else
                        window.renderWindow = GameWindow.CreateWindow(_handle.Value, _contextSetting);

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
            window.renderWindow.LostFocus += (s, e) => { isFocused = false; LostFocus?.Invoke(new GameEventArgs(this)); };
            window.renderWindow.GainedFocus += (s, e) => { isFocused = true; Focused?.Invoke(new GameEventArgs(this)); };

            float totalTimeBeforeUpdate = 0f;
            float previousTimeEnlapsed = 0,
                deltaTime = 0, totalTimeEnlapsed = 0;

            _gameTimer.Reset();
            _gameTimer.Start();
            do {
                if (isFocused) {
                    window.renderWindow.DispatchEvents();

                    totalTimeEnlapsed = _gameTimer.Elapsed.Seconds;
                    deltaTime = totalTimeEnlapsed - previousTimeEnlapsed;
                    previousTimeEnlapsed = totalTimeEnlapsed;
                    totalTimeBeforeUpdate += deltaTime;

                    if (totalTimeEnlapsed >= timeTillNextFrame) {
                        Update(gameTime);

                        gameTime.update(TimeSpan.FromMilliseconds(totalTimeBeforeUpdate), deltaTime, totalTimeBeforeUpdate);

                        totalTimeBeforeUpdate = 0f;

                        Draw(gameTime);

                        window.renderWindow.Display();
                    }
                }
            } while (window.renderWindow.IsOpen);
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

        /// <summary>
        /// Tries to focus the window.
        /// </summary>
        public void Focus() {
            window.renderWindow?.RequestFocus();

            if (window.renderWindow.HasFocus())
                isFocused = true;
            else
                isFocused = false;
        }
    }
}
