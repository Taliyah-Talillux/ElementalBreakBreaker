using AtelierCS.Classes_du_DesignPattern;
using CasseBriqueSandra.Sandra;
using CasseBriqueSandra.Scenes;
using CasseBriqueSandra.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CasseBriqueSandra
{
    class SceneMenu : Scene
    {
        private Button ButtonPlay;
        private Button ButtonQuit;
        public SceneMenu() : base()
        {
        }
        public override void Load()
        {
            var sInfo = ServiceLocator.GetService<IScreenService>();
            var content = ServiceLocator.GetService<ContentManager>();

            ButtonPlay = new Button(content.Load<Texture2D>("Boutons/ButtonPlay"));
            ButtonQuit = new Button(content.Load<Texture2D>("Boutons/ButtonQuit"));


            ButtonPlay.Position = new Vector2(
                (sInfo.ScreenWidth() / 2) - ButtonPlay.Texture.Width / 2,
                (sInfo.ScreenHeight() / 2) - ButtonPlay.Texture.Height / 2 - 100
                );   
            ButtonQuit.Position = new Vector2(
                (sInfo.ScreenWidth() / 2) - ButtonPlay.Texture.Width / 2,
                (sInfo.ScreenHeight() / 2) - ButtonPlay.Texture.Height / 2 + 100
                );

            ButtonPlay.OnClick = onClickPlay;
            ButtonQuit.OnClick = onClickQuit;

            listActors.Add(ButtonPlay);
            listActors.Add(ButtonQuit);

            base.Load();
        }
        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            var gameState = ServiceLocator.GetService<ISceneChanger>();

            MouseState newMouseState = Mouse.GetState();

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            var sInfo = ServiceLocator.GetService<IScreenService>();
            SpriteBatch spriteBatch = ServiceLocator.GetService<SpriteBatch>();

            spriteBatch.DrawString(AssetManager.MainFont, "This is The Menu ! ", (new Vector2(sInfo.ScreenWidth() / 2,100)), Color.Aqua);
            base.Draw(gameTime);
        }
        public void onClickPlay(Button pSender)
        {
            var gameState = ServiceLocator.GetService<ISceneChanger>();

            gameState.ChangeScene(SceneType.GamePlay);
        }
        public void onClickQuit(Button pSender)
        {
            Environment.Exit(0);
        }
    }
}
