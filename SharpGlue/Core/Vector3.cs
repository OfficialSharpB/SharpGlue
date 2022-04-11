/*
 * SharpGlue, The sfml engine, for 2d, and 3d game development.
 * 
 * Sharpboy.org
 * Stephen Hale
*/
namespace SharpGlue.Core
{
    public class Vector3 : Vector2
    {
        float w;

        /// <summary>
        /// Gets the w position.
        /// </summary>
        public float W
        {
            get => w;
            set => w = value;
        }

        /// <summary>
        /// Initalize a new instance of <see cref="Vector3"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        public Vector3(float x, float y, float w) : base(x, y) {
            this.w = w;
        }
    }
}
