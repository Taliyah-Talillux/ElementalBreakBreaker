using CasseBriqueSandra.Sandra;
using CasseBriqueSandra.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CasseBriqueSandra
{
    // Classe principale du jeu
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SceneManager gameState;

        public MainGame()
        {
            // TAILLE FENETRE JEU 
            ScreenInfo mySI = new ScreenInfo(this.Window);

            // SERVICE LOCATOR 
            ServiceLocator.RegisterService<IScreenService>(mySI);
            ServiceLocator.RegisterService<ContentManager>(Content);
            ServiceLocator.RegisterService<Camera>(new Camera());


                graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 700;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            gameState = new SceneManager();
            ServiceLocator.RegisterService<ISceneChanger>(gameState);
        }

        // Fonction appelée une fois pour initialiser le jeu
        protected override void Initialize()
        {
            // TODO: Ajoutez ici votre code d'initialisation
            IsMouseVisible = true;
            base.Initialize();
        }

        // Fonction appelée une seule fois pour charger le contenu du jeu
        protected override void LoadContent()
        {
            gameState.ChangeScene(SceneType.GamePlay);

            AssetManager.Load();
            // Crée un nouveau SpriteBatch, qui sera utilisé pour afficher des images (textures)
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ServiceLocator.RegisterService<SpriteBatch>(spriteBatch);

            // TODO: Ajoutez ici votre code qui chargera le contenu du jeu
        }

        // Fonction appelée une fois pour décharger le contenu du jeu (hors ContentManager)
        protected override void UnloadContent()
        {
        }
        // Fonction appelée 60x par seconde pour mettre à jour l'état du jeu
        // Reçoit "gametime" qui contient le temps écoulé depuis le dernier update
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Ajoutez le code de mise à jour ici
            if (gameState != null)
            {
                gameState.CurrentScene.Update(gameTime);
            }
            base.Update(gameTime);
        }

        // Fonction appelée aussi souvent que possible (jusqu'à 60x par seconde) pour afficher le jeu
        // Reçoit "gametime" qui contient le temps écoulé depuis le dernier update
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Ajouter le code d'affichage ici
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            if (gameState != null)
            {
                gameState.CurrentScene.Draw(gameTime);
            }
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}