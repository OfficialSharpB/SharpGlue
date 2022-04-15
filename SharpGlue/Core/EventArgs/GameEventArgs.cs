/*
 * SharpBoy - a cross platform application made to support games for sfml using this engine, 
 * aswell as emulator plugins.
 * 
 * Developer: StephenFox.
 * Website: sharpboy.org.
*/
namespace SharpGlue.Core.EventArgs
{
    /// <summary>
    /// A basic handler, to handle <see cref="GameEventArgs"/>
    /// </summary>
    /// <param name="eventArgs"></param>
    public delegate void GameEventHandler(GameEventArgs eventArgs);

    /// <summary>
    /// Represents a game event args.
    /// </summary>
    public class GameEventArgs
    {
        private readonly Game game;

        /// <summary>
        /// Gets the game.
        /// </summary>
        public Game Game
        {
            get => game;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="GameEventArgs"/>
        /// </summary>
        /// <param name="game"></param>
        public GameEventArgs(Game game) {
            this.game = game;
        }
    }
}
