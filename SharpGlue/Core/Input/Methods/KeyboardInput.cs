/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SharpGlue.Core.Input.States.Keyboard;

namespace SharpGlue.Core.Input.Methods
{
    /// <summary>
    /// Represents a keyboard.
    /// </summary>
    public class KeyboardInput : AbstractInputMethod
    {
        KeyboardState current, previous;
        bool allowLongPress = false;

        /// <summary>
        /// Initialize a new instance of <see cref="KeyboardInput"/>
        /// </summary>
        public KeyboardInput() {
            current = new KeyboardState();
            previous = new KeyboardState(current);
        }

        /// <summary>
        /// Gets or sets a bool value indercating weather keys can be held down, or can only be pressed once, with no held.
        /// </summary>
        public bool AllowLongPress
        {
            get => allowLongPress;
            set => allowLongPress = value;
        }

        public override void Update() {
            current = new KeyboardState();
            previous = new KeyboardState(current);
        }

        /// <summary>
        /// Gets a bool value indercating a key has been pressed.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyDown(Keys key) {
            if (allowLongPress)
                return current.IsKey(key, KeyStroke.Pressed);
            else
                return current.IsKey(key, KeyStroke.Pressed) &&
                       previous.IsKey(key, KeyStroke.Released);
        }


        /// <summary>
        /// Gets a bool value indercating a key has been released.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyUp(Keys key) {
            if (allowLongPress)
                return current.IsKey(key, KeyStroke.Released);
            else
                return current.IsKey(key, KeyStroke.Released) &&
                      previous.IsKey(key, KeyStroke.Pressed);
        }

        /// <summary>
        /// Gets a bool value indercating a key has been released.
        /// </summary>
        public bool IsKeyDown(string keyName) {
            var key = (Keys)System.Enum.Parse(typeof(Keys), keyName);
            return IsKeyDown(key);
        }

        /// <summary>
        /// Gets a bool value indercating a key has been released.
        /// </summary>
        public bool IsKeyUp(string keyName) {
            var key = (Keys)System.Enum.Parse(typeof(Keys), keyName);
            return IsKeyUp(key);
        }
    }
}
