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
    /// Represents a base class for a usable content.
    /// </summary>
    public interface IContent
    {
        /// <summary>
        /// Gets the name of this content.
        /// </summary>
        string Name
        {
            get;
        }
    }
}
