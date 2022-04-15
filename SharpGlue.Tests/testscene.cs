using SFML.Graphics;

using SharpGlue.Core;
using SharpGlue.Core.Content;
using SharpGlue.Core.Graphics;
using SharpGlue.Core.Input.Methods;
using SharpGlue.Core.Screen;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGlue.Tests
{
    internal class testscene : GameScene
    {
        SpriteFont font;
        public override void LoadContent(bool instancePreserved, ContentManager content) {
            base.LoadContent(instancePreserved, content);
            font = new SpriteFont(Environment.CurrentDirectory + @"\arial.ttf", 15);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            base.Draw(gameTime, spriteBatch);
spriteBatch.Begin();
            var mouse = ScreenManager.InputSystem.GetInput<MouseInput>();

            spriteBatch.DrawString(font, "Test fontString", mouse.CurrentPosition, Core.Color.Black);
            var texture = TextureHelper.GenerateBlack(Core.Color.Black, new Vector2(20, 20));
            spriteBatch.Draw(texture, mouse.CurrentPosition, Core.Color.White);
            spriteBatch.End();
        }
    }
}
