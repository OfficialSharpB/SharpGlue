/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/

using SharpGlue.Core.Graphics;

using System;

namespace SharpGlue.Core.Exceptions
{
    public class SpriteBatchException : Exception
    {
        SpriteBatch sprteBatch;

        /// <summary>
        /// Gets the spriteBatch.
        /// </summary>
        public SpriteBatch SpriteBatch => sprteBatch;

        /// <summary>
        /// Initailize a new instance of <see cref="SpriteBatchException"/>
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="message"></param>
        public SpriteBatchException(SpriteBatch spriteBatch, string message) : base(message) {
            this.sprteBatch = spriteBatch;
        }
    }
}
