using SFML.Graphics;

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
        /// Initialize a new instance of <see cref="GameWindow"/>
        /// </summary>
        public GameWindow() {
        }

        /// <summary>
        /// Create a window.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="resizable"></param>
        /// <returns></returns>
        internal static RenderWindow CreateWindow(string title, bool resizable) {
            return new RenderWindow(SFML.Window.VideoMode.DesktopMode, title, resizable ? SFML.Window.Styles.Resize : SFML.Window.Styles.Close,
                new SFML.Window.ContextSettings());
        }
    }
}
