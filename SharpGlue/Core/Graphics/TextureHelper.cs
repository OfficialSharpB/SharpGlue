using SFML.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGlue.Core.Graphics
{
    public static class TextureHelper
    {
        /// <summary>
        /// Generates a blank texture.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Texture2D GenerateBlack(Color color, Vector2 size) {
            RenderTexture texture = new RenderTexture((uint)size.X, (uint)size.Y);
            texture.Clear(ColorConverter.ToSFML(color));
            texture.Display();

            var texture2D = texture.Texture.CopyToImage(); ;

            return new Texture2D(texture2D);
        }
    }
}
