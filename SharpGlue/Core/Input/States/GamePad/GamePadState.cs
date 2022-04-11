/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

using joypad = SFML.Window.Joystick;

namespace SharpGlue.Core.Input.States.GamePad
{
    public class GamePadState
    {
        bool[] buttonCount;

        /// <summary>
        /// Initialize a new instance of <see cref="GamePadState"/>
        /// </summary>
        public GamePadState() => buttonCount = new bool[14];

        /// <summary>
        /// Initialize a new instance of <see cref="GamePadState"/>
        /// </summary>
        public GamePadState(GamePadState last) {
            buttonCount = last.buttonCount;
        }

        internal void Update(uint index) {
            for(int i = 0; i < 14; i++) {
                buttonCount[i] = joypad.IsButtonPressed(index, (uint)i);
            }
        }

        /// <summary>
        /// Gets a bool value indercating weather a <see cref="GamePadButtons"/> has been pressed.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="stroke"></param>
        /// <returns></returns>
        public bool IsButton(GamePadButtons button, GamePadStroke stroke) {
            var b = buttonCount[(int)button];
            return stroke == GamePadStroke.Pressed ? b : !b;
        }
    }
}
