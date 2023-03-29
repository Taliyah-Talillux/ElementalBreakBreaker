using CasseBriqueSandra.Sandra;
using CasseBriqueSandra.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace CasseBriqueSandra
{
    internal class SceneGameOver : Scene
    {
        public SceneGameOver() : base()
        {
        }
        public override void Load()
        {
            Debug.Write("SceneGameOver.Load");
            base.Load();
        }

        public override void Unload()
        {
            Debug.Write("SceneGameOver.Unload");
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            var gameState = ServiceLocator.GetService<ISceneChanger>();
            MouseState newMouseState = Mouse.GetState();

            if (newMouseState.LeftButton == ButtonState.Pressed && newMouseState.LeftButton != ButtonState.Released)
            {
                gameState.ChangeScene(SceneType.GamePlay);
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = ServiceLocator.GetService<SpriteBatch>();
            var sInfo = ServiceLocator.GetService<IScreenService>();

            spriteBatch.DrawString(AssetManager.MainFont, "Game Over ! ", (new Vector2(sInfo.ScreenWidth() / 2, sInfo.ScreenHeight() / 2)), Color.Aqua);
            base.Draw(gameTime);
        }
    }
}
