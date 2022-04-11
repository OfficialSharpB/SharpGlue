/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

namespace SharpGlue.Base
{
    /// <summary>
    /// Represents a service, that is usable else where.
    /// </summary>
    public interface IServiceProvider
    {
        /// <summary>
        /// Gets the name of this service.
        /// </summary>
        string ServiceName
        {
            get;
        }
    }
}
