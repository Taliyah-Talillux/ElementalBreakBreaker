namespace CasseBriqueSandra.Scenes
{
    public enum SceneType
    {
        Menu,
        GamePlay,
        GameOver,
        GameWin
    }

    public interface ISceneChanger
    {
        void ChangeScene(SceneType pSceneType);
    }

    public class SceneManager : ISceneChanger
    {
        public Scene CurrentScene { get; set; }

        public SceneManager()
        {
        }
        public void ChangeScene(SceneType pSceneType)
        {
            if (CurrentScene != null)
            {
                CurrentScene.Unload();
                CurrentScene = null;
            }

            switch (pSceneType)
            {
                case SceneType.Menu:
                    CurrentScene = new SceneMenu();
                    break;
                case SceneType.GamePlay:
                    CurrentScene = new SceneGamePlay();
                    break;
                case SceneType.GameOver:
                    CurrentScene = new SceneGameOver();
                    break;
                case SceneType.GameWin:
                    CurrentScene = new SceneGameWin();
                    break;
                default:
                    break;
            }
            CurrentScene.Load();
        }
    }
}
