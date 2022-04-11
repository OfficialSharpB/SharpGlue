/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

using SharpGlue.Core.Input.States.GamePad;

namespace SharpGlue.Core.Input.Methods
{
    public class GamePadInput : AbstractInputMethod
    {
        const int MAX_INPUT = 4;
        GamePadState[] currentStates = new GamePadState[4], 
                       previousStates = new GamePadState[4];
        PlayerIndex index;

        /// <summary>
        /// Initialize a new instance of <see cref="GamePadInput"/>
        /// </summary>
        /// <param name="index"></param>
        public GamePadInput(PlayerIndex index) =>
            this.index = index;
        public override void Update() {
          for(int i = 0; i < MAX_INPUT;i++) {
                currentStates[i] = new GamePadState();
                previousStates[i] = new GamePadState(currentStates[i]);
            }
        }

        /// <summary>
        /// Gets a bool value indercating weather a button is down.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool IsButtonDown(GamePadButtons button) {
            var c = currentStates[(int)index];
            var p = previousStates[(int)index];

            return c.IsButton(button, GamePadStroke.Pressed) &&
                   p.IsButton(button, GamePadStroke.Released);
        }
    }
}
