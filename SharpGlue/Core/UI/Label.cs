using SharpGlue.Core.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGlue.Core.UI
{
    public class Label : GameObject
    {
        string text;

        /// <summary>
        /// Gets or sets the text of this label.
        /// </summary>
        public string Text
        {
            get => text;
            set => text = value;
        }

        /// <summary>
        /// Draw this label.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="font"></param>
        /// <param name="color"></param>
        public void Draw( SpriteBatch spriteBatch, SpriteFont font, Color color ) {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, Position, color);
            spriteBatch.End();
        }
    }
}
