/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
namespace SharpGlue.Core.Screen
{
    /// <summary>
    /// Represents the state of a <see cref="GameScene"/>
    /// </summary>
    public enum GameSceneState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden
    }
}
