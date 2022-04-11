using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGlue.Core
{
    public class Vector2 : IEquatable<Vector2>
    {
        float x, y;

        /// <summary>
        /// Gets or sets the x position.
        /// </summary>
        public float X
        {
            get => x;
            set => x = value;
        }

        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        public float Y
        {
            get => y;
            set => y = value;
        }

        /// <summary>
        /// Initialie a new instance of <see cref="Vector2"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(float x, float y) {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets a <see cref="bool"/> value indercating weather another <see cref="Vector2"/> has the same values as this <see cref="Vector2"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Vector2 other) {
            return (x == other.X && y == other.Y);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) {
            return new Vector2(
                v1.X + v2.X,
                v2.Y + v1.Y);
        }
        public static Vector2 operator - (Vector2 v1, Vector2 v2) => new Vector2(
            v1.X - v2.X,
            v1.Y - v2.Y);
        public static Vector2 operator /(Vector2 v1, Vector2 v2) => new Vector2(
            v1.X / v2.X,
            v2.Y / v1.Y);

        /// <summary>
        /// Returns a zero point vector 2
        /// </summary>
        public static Vector2 Zero = new Vector2(0, 0);
    }
}
