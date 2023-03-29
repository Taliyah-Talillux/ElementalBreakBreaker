using CasseBriqueSandra.Levels;
using CasseBriqueSandra.Sandra;
using CasseBriqueSandra.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CasseBriqueSandra
{
    internal class SceneGamePlay : Scene
    {
        public Racket myRacket;
        public Ball myBall;

        public List<Brick> Bricks = new List<Brick>();
        int currentlvl = 1;
        static int maxLvl = 2;
        public SceneGamePlay() : base()
        {
        }
        public override void Load()
        {
            myRacket = new Racket();
            ServiceLocator.RegisterService(myRacket);

            myBall = new Ball();
            ServiceLocator.RegisterService(myBall);

            Brick.LoadTexture();
            Brick.LoadComportment();
            LoadLevel();

            base.Load();
        }
        public void LoadLevel()
        {
            listActors.Add(myRacket);

            listActors.Add(myBall);

            Bricks = LevelLoader.Load(currentlvl);
            listActors.AddRange(Bricks);
            base.Load();
        }
        public override void Unload()
        {
            base.Unload();
        }

        public bool isPressed = false;
        public override void Update(GameTime gameTime)
        {
            ServiceLocator.GetService<Camera>().Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                myBall.StartMove();
            }

            Brick.CollisionsBrickWithBall(Bricks);

            //Supprimer les briques 
            Clean();


            if (Keyboard.GetState().IsKeyDown(Keys.P) && !isPressed)
            {
                Bricks.RemoveAll(_ => true);
                listActors.RemoveAll(_ => true);
            }
            isPressed = Keyboard.GetState().IsKeyDown(Keys.P);

            if (Bricks.Count == 0)
            {
                currentlvl++;
                if (currentlvl > maxLvl)
                {
                    var gameState = ServiceLocator.GetService<ISceneChanger>();
                    gameState.ChangeScene(SceneType.GameWin);
                }
                else
                {
                    LoadLevel();
                }
            }
   
           

            base.Update(gameTime);

        }
        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = ServiceLocator.GetService<SpriteBatch>();
            var sInfo = ServiceLocator.GetService<IScreenService>();

            spriteBatch.DrawString(AssetManager.MainFont, "This is The Gameplay ! ", (new Vector2(sInfo.ScreenWidth() / 2, sInfo.ScreenHeight() / 2)), Color.Aqua);
            base.Draw(gameTime);
        }
        public override void Clean()
        {
            Bricks.RemoveAll(item => item.ToRemove == true);
            base.Clean();
        }

    }
}
