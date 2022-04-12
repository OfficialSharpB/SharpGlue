
/*
 * SharpBoy - a cross platform application made to support games for sfml using this engine, 
 * aswell as emulator plugins.
 * 
 * Developer: StephenFox.
 * Website: sharpboy.org.
*/
using System;

namespace SharpGlue.Core.Exceptions
{
    public sealed class ContentException : Exception
    {
        /// <summary>
        /// Initialize a new instance of <see cref="ContentException"/>
        /// </summary>
        /// <param name="message"></param>
        public ContentException(string message) : base(message) {
        }
    }
}
