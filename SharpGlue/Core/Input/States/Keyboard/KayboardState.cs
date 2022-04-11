/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using Microsoft.VisualBasic;

using SFML.Window;

namespace SharpGlue.Core.Input.States.Keyboard
{
    public class KeyboardState
    {
        int keyCount = (int)Keys.KeyCount;
        bool[] pressedKeys;

        /// <summary>
        /// Initalize a new instance of <see cref="KeyboardState"/>
        /// </summary>
        public KeyboardState() =>
            pressedKeys = new bool[keyCount];

        /// <summary>
        /// Initalize a new instance of <see cref="KeyboardState"/>
        /// </summary>
        public KeyboardState(KeyboardState previues) {
            pressedKeys = previues.pressedKeys;
        }

        internal void Update() {
            for (int i = 0; i < keyCount; i++)
                pressedKeys[i] = SFML.Window.Keyboard.IsKeyPressed((SFML.Window.Keyboard.Key)i);
        }

        /// <summary>
        /// Gets a bool value indercating weather any <see cref="Keys"/> are pressed or released.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="stroke"></param>
        /// <returns></returns>
        public bool IsKey(Keys key, KeyStroke stroke) {
            var keyDown = pressedKeys[(int)key];
            return stroke == KeyStroke.Pressed ? keyDown : !keyDown;
        }
    }
}
