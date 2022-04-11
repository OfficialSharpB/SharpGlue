/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
namespace SharpGlue.Core.Input.States.Touch
{
    /// <summary>
    /// Represents a static class for touch states.
    /// </summary>
    public static class TouchState
    {
        /// <summary>
        /// Gets a bool value indercating weather a finger(s) touched the screen.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool IsFingerDown(TouchIndex index) {
            if (index == TouchIndex.None)
                return false;
            return SFML.Window.Touch.IsDown((uint)index);
        }
    }
}
