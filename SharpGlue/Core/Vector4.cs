using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGlue.Core
{
    public class Vector4 : Vector3
    {
        float r;

        /// <summary>
        /// Gets or sets the r position;
        /// </summary>
        public float R
        {
            get => r;
            set => r = value;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Vector4"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="r"></param>
        public Vector4(float x, float y, float w, float r) : base(x, y, w) {
            this.r = r;
        }
    }
}
