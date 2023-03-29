using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CasseBriqueSandra.Scenes
{
    abstract public class Scene
    {
        protected List<IActor> listActors;
        public Scene()
        {
            listActors = new List<IActor>();
            ServiceLocator.RegisterService(listActors);
        }
        public virtual void Clean()
        {
            listActors.RemoveAll(item => item.ToRemove == true);
        }

        public virtual void Load()
        {
            foreach (IActor actors in listActors)
            {
                actors.Load();
            }
        }
        public virtual void Unload()
        {
        }
        public virtual void Update(GameTime gameTime)
        {
            foreach (IActor actors in listActors)
            {
                actors.Update(gameTime);
            }
        }
        public virtual void Draw(GameTime gameTime)
        {
            foreach (IActor actors in listActors)
            {
                actors.Draw();
            }
        }
    }
}
