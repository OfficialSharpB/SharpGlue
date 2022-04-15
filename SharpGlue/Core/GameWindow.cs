using SFML.Graphics;
using SFML.Window;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGlue.Core
{
    /// <summary>
    /// Represents a 
    /// </summary>
    public class GameWindow
    {
        internal RenderWindow renderWindow;

        string title;
        bool resizable;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get => title;
            set {
                title = value;
                if (renderWindow != null)
                    renderWindow.SetTitle(value);
            }
        }

        public bool Resizable
        {
            get => resizable;
            set {
                if (renderWindow == null)
                    return;
                resizable = value;
            }
        }

        /// <summary>
        /// Gets the handle.
        /// </summary>
        public IntPtr Pointer =>
            renderWindow.SystemHandle;

        /// <summary>
        /// Initialize a new instance of <see cref="GameWindow"/>
        /// </summary>
        public GameWindow() {
        }

        internal static RenderWindow CreateWindow(string title, bool resizable) {
            return new RenderWindow(SFML.Window.VideoMode.DesktopMode, title, resizable ? SFML.Window.Styles.Resize : SFML.Window.Styles.Close,
                new SFML.Window.ContextSettings());
        }

        internal static RenderWindow CreateWindow(string title, bool resizable, GameContext context) {
            return new RenderWindow(SFML.Window.VideoMode.DesktopMode, title, resizable ? SFML.Window.Styles.Resize : SFML.Window.Styles.Close,
                new SFML.Window.ContextSettings() {  AntialiasingLevel = context.Antialiasing, DepthBits = context.DepthBits,  StencilBits = context.Stencil});
        }

        internal static RenderWindow CreateWindow(IntPtr handle) {
            return new RenderWindow(handle);
        }

        internal static RenderWindow CreateWindow(IntPtr handle, GameContext context) {
            return new RenderWindow(handle, new ContextSettings() { AntialiasingLevel = context.Antialiasing, DepthBits = context.DepthBits, StencilBits = context.Stencil });
        }
    }
}
