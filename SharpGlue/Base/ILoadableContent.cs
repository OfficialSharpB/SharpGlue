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
    /// Represents a loadable content class.
    /// </summary>
    public interface ILoadableContent : IContent
    {
        /// <summary>
        /// Gets the path of this loadable content.
        /// </summary>
        string Path { get; }
    }
}
