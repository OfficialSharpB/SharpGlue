using SFML.Graphics;

using SharpGlue.Core;
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
    internal class testGame : Game
    {
        SpriteBatch spriteBatch;

        GameSceneManager sceneManager;
        public testGame() {
            sceneManager = new GameSceneManager(this);
            sceneManager.AddScreen(new testscene());
            sceneManager.InputSystem.AddInput<MouseInput>(new MouseInput());
            Components.Add(sceneManager);
        }
        public override void Initialize() {
            base.Initialize();
        }

        public override void LoadContent() {
            base.LoadContent();

            spriteBatch = new SpriteBatch(GraphicsDevice);

        }
        public override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Core.Color.ConflowerBlue);
            base.Draw(gameTime);
        }
    }
}
