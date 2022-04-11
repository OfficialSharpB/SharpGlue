using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGlue.Core.Input.States.Mouse
{
    /// <summary>
    /// Represents a class for mouse states.
    /// </summary>
    public class MouseState
    {
        bool[] mouseButtonState;

        /// <summary>
        /// Gets the position of this state.
        /// </summary>
        public Vector2 Position =>
            new Vector2(
                SFML.Window.Mouse.GetPosition().X,
                SFML.Window.Mouse.GetPosition().Y
            );

        /// <summary>
        /// Initialize a new instance of <see cref="MouseState"/>
        /// </summary>
        public MouseState() =>
            mouseButtonState = new bool[3];

        /// <summary>
        /// Initalize a new instance of <see cref="MouseState"/>
        /// </summary>
        /// <param name="ms_current"></param>
        public MouseState(MouseState ms_current) {
            mouseButtonState = new bool[3];
            for (int i = 0; i < 3; i++)
                mouseButtonState[i] = ms_current.mouseButtonState[i];
        }

        public void UpdateState() {
            mouseButtonState[0] = SFML.Window.Mouse.IsButtonPressed(SFML.Window.Mouse.Button.Left);
            mouseButtonState[1] = SFML.Window.Mouse.IsButtonPressed(SFML.Window.Mouse.Button.Middle);
            mouseButtonState[2] = SFML.Window.Mouse.IsButtonPressed(SFML.Window.Mouse.Button.Right);
        }

        /// <summary>
        /// Gets a <see cref="bool"/> value indercating weather a button is down or up.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="stroke"></param>
        /// <returns></returns>
        public bool IsButton(MouseButtons button, MouseStroke stroke) {
            var down = mouseButtonState[(int)button];

            return stroke == MouseStroke.Pressed ? down : !down;
        }
    }
}
