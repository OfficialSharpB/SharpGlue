/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
using SharpGlue.Core.Input.States.Mouse;
using System.Collections.Generic;

namespace SharpGlue.Core.Input.Methods
{
    /// <summary>
    /// Represents a mouse input device.
    /// </summary>
    public class MouseInput : AbstractInputMethod
    {
        MouseState current, last;
        Vector2 currentPos, lastPos;

        /// <summary>
        /// Gets the current position of the mouse.
        /// </summary>
        public Vector2 CurrentPosition =>
                currentPos;

        /// <summary>
        /// Gets the last known position of the mouse.
        /// </summary>
        public Vector2 LastPosition =>
            lastPos;

        /// <summary>
        /// Initialize a new instance of <see cref="MouseDevice"/>
        /// </summary>
        /// <param name="name"></param>
        public MouseInput() {
            current = new MouseState();
        }

        public override void Update() {
            try {
                last = new MouseState(current);
                current = new MouseState();

                current.UpdateState();
            }
            catch { }

            currentPos = current.Position;
            lastPos = last.Position;
        }

        /// <summary>
        /// Gets a <see cref="bool"/> value indercating weather a <see cref="MouseButton"/> has been pressed or held.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="multiPress"></param>
        /// <returns></returns>
        public bool IsButtonDown(MouseButtons button, bool multiPress) =>
            multiPress ?
               current.IsButton(button, MouseStroke.Pressed) :
               current.IsButton(button, MouseStroke.Pressed) &&
               last.IsButton(button, MouseStroke.Released);

        /// <summary>
        /// Gets a <see cref="bool"/> value indercating weather a <see cref="MouseButton"/> has been pressed or held.
        /// </summary>
        public bool IsButtonDown(MouseButtons button) =>
            IsButtonDown(button, false);

        /// <summary>
        /// Gets a <see cref="bool"/> value indercating weather a <see cref="MouseButton"/> is released or not being pressed.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool IsButtonUp(MouseButtons button) =>
            current.IsButton(button, MouseStroke.Released) &&
            last.IsButton(button, MouseStroke.Released);
    }
}
