/*
 * SharpBoy - a cross platform application made to support games for sfml using this engine, 
 * aswell as emulator plugins.
 * 
 * Developer: StephenFox.
 * Website: sharpboy.org.
*/
namespace SharpGlue.Base
{
    /// <summary>
    /// Represents a base class for a <c>Component</c>
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Gets the draw order of this <see cref="IComponent"/>
        /// </summary>
        int DrawOrder
        {
            get;
            internal set;
        }
    }
}
