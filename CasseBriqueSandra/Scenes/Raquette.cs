using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CasseBriqueSandra.Scenes
{
    public class Racket : Sprite
    {
        protected static Dictionary<ElementalType, Texture2D> TexturesRacket = new Dictionary<ElementalType, Texture2D>();

        public ElementalType Type = ElementalType.Basic;
        public Racket() : base()
        {
            ContentManager pContent = ServiceLocator.GetService<ContentManager>();

            TexturesRacket[ElementalType.Basic] = pContent.Load<Texture2D>("Raquettes/Raquette");
            TexturesRacket[ElementalType.Cryo] = pContent.Load<Texture2D>("Raquettes/Raquette_Cryo");
            TexturesRacket[ElementalType.Hydro] = pContent.Load<Texture2D>("Raquettes/Raquette_Hydro");
            TexturesRacket[ElementalType.Electro] = pContent.Load<Texture2D>("Raquettes/Raquette_Electro");
            TexturesRacket[ElementalType.Pyro] = pContent.Load<Texture2D>("Raquettes/Raquette_Pyro");

            var sInfo = ServiceLocator.GetService<IScreenService>();
            SetPosition(sInfo.ScreenWidth() / 2 - Width, sInfo.ScreenHeight() - Height);
        }
        public override void Load()
        {
            FollowMousePosition();
            base.Load();
        }
        public override void Update(GameTime pgameTime)
        {
            FollowMousePosition();
            ChangeRacket();

            base.Update(pgameTime);
        }
        public void FollowMousePosition()
        {
            var sInfo = ServiceLocator.GetService<IScreenService>();

            SetPosition(Mouse.GetState().X - Width / 2, Mouse.GetState().Y - Height);

            if (Position.X < 0)
            {
                Position = new Vector2(0, MathHelper.Clamp(Position.Y, 0, sInfo.ScreenHeight() - Height));
            }
            if (Position.X + Width > sInfo.ScreenWidth())
            {
                Position = new Vector2(sInfo.ScreenWidth() - Width, MathHelper.Clamp(Position.Y, 0, sInfo.ScreenHeight() - Height));
            }
            if (Position.Y < sInfo.ScreenHeight() - sInfo.ScreenHeight() / 3)
            {
                Position = new Vector2(Position.X, sInfo.ScreenHeight() - sInfo.ScreenHeight() / 3);
            }
            if (Position.Y + Height > sInfo.ScreenHeight())
            {
                Position = new Vector2(Position.X, sInfo.ScreenHeight() - Height);
            }
        }
        public void ChangeRacket()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Type = ElementalType.Cryo;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                Type = ElementalType.Hydro;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                Type = ElementalType.Electro;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                Type = ElementalType.Pyro;
            }
        }
        public override Texture2D Texture
        {
            get
            {
                return TexturesRacket[Type];
            }
        }
    }
}
