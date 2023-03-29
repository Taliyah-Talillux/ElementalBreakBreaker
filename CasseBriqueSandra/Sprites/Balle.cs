using CasseBriqueSandra.Sandra;
using CasseBriqueSandra.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CasseBriqueSandra
{
    public enum BallState
    {
        Idle,
        Moving,
    }
    public class Ball : Sprite
    {
        protected static Dictionary<ElementalType, Texture2D> TexturesBall = new Dictionary<ElementalType, Texture2D>();

        public ElementalType Type = ElementalType.Basic;

        private BallState _currentState = BallState.Idle;
        public Ball() : base()
        {
            ContentManager pContent = ServiceLocator.GetService<ContentManager>();
            TexturesBall[ElementalType.Basic] = pContent.Load<Texture2D>("Balles/Balle");
            TexturesBall[ElementalType.Cryo] = pContent.Load<Texture2D>("Balles/Balle_Cryo");
            TexturesBall[ElementalType.Hydro] = pContent.Load<Texture2D>("Balles/Balle_Hydro");
            TexturesBall[ElementalType.Electro] = pContent.Load<Texture2D>("Balles/Balle_Electro");
            TexturesBall[ElementalType.Pyro] = pContent.Load<Texture2D>("Balles/Balle_Pyro");

            //Texture = TexturesBall[ElementalType.Basic];
        }
        public void CenterBalle()
        {
            Racket myRacket = ServiceLocator.GetService<Racket>();
            SetPosition(myRacket.Position.X + myRacket.Width / 2 - Width / 2, myRacket.Position.Y - Height);
        }

        public override void Load()
        {
            Type = ElementalType.Basic;
            _currentState = BallState.Idle;
            //Texture = TexturesBall[ElementalType.Basic];

            CenterBalle();
            base.Load();
        }
        public override void Update(GameTime pgameTime)
        {
            base.Update(pgameTime);

            if (_currentState == BallState.Idle)
            {
                StateIdleUpdate();
            }
            else if (_currentState == BallState.Moving)
            {
                StateMoveUpdate();
                var myRacket = ServiceLocator.GetService<Racket>();

                ReverseSpeed();
            }
        }
        public override void Draw()
        {
            base.Draw();
        }
        public void StateIdleUpdate()
        {
            CenterBalle();
            var myBall = ServiceLocator.GetService<Ball>();
            ChangeTextureBall();
        }
        public void StateMoveUpdate()
        {
            var sInfo = ServiceLocator.GetService<IScreenService>();

            if (Position.X < 0)
            {
                SetPosition(0, Position.Y);
                Speed = new Vector2(-Speed.X, Speed.Y);
            }
            if (Position.X > sInfo.ScreenWidth() - Width)
            {
                SetPosition(sInfo.ScreenWidth() - Width, Position.Y);
                Speed = new Vector2(-Speed.X, Speed.Y);
            }
            if (Position.Y < 0)
            {
                SetPosition(Position.X, 0);
                Speed = new Vector2(Speed.X, -Speed.Y);
            }
            if (Position.Y > sInfo.ScreenHeight())
            {
                _currentState = BallState.Idle;
            }
        }
        public void StartMove()
        {
            _currentState = BallState.Moving;
            Speed = new Vector2(-2, -2);
        }
        public void ChangeTextureBall()
        {
            Racket myRacket = ServiceLocator.GetService<Racket>();

            Type = myRacket.Type;
        }
        public void ReverseSpeed()
        {
            Racket myRacket = ServiceLocator.GetService<Racket>();

            // Vérifier si la balle touche la raquette sur l'axe horizontal ou sur le côté gauche/droit
            if (Utils.ColliedByBox(myRacket, this))
            {
                TouchedBy(myRacket);

                if (Position.X + Width / 2 <= myRacket.Position.X)
                {
                    // Rebond à gauche
                    Speed = new Vector2(-Math.Abs(Speed.X), Speed.Y);
                }
                else if (Position.X + Width / 2 >= myRacket.Position.X + myRacket.Width)
                {
                    // Rebond à droite
                    Speed = new Vector2(Math.Abs(Speed.X), Speed.Y);
                }
                else if (Position.Y + Height >= myRacket.Position.Y && Position.Y + Height / 2 <= myRacket.Position.Y + myRacket.Height && Speed.Y > 0)
                {
                    // Rebond vertical
                    Speed = new Vector2(Speed.X, -Speed.Y);
                }
                ChangeTextureBall();
            }
        }
        public override Texture2D Texture
        {
            get
            {
                return TexturesBall[Type];
            }
        }
        public void ReverseBallWithBrick(Brick brick)
        {
            Random rnd = new Random();
            double randomAngleInDegrees = rnd.NextDouble() * 360; // Générer un angle aléatoire entre 0 et 360 degrés

            if (Position.X + Width / 2 <= brick.Position.X)
            {
                // Rebond à gauche
                float angle = MathHelper.ToRadians((float)randomAngleInDegrees); // Convertir l'angle en radians

                Speed = new Vector2(-Math.Abs(Speed.Length() * (float)Math.Cos(angle)), -Speed.Length() * (float)Math.Sin(angle));
            }
            else if (Position.X + Width / 2 >= brick.Position.X + brick.Width)
            {
                // Rebond à droite
                float angle = MathHelper.ToRadians((float)randomAngleInDegrees); // Convertir l'angle en radians

                Speed = new Vector2(Math.Abs(Speed.Length() * (float)Math.Cos(angle)), -Speed.Length() * (float)Math.Sin(angle));
            }
            else if (Position.Y + Height / 2 <= brick.Position.Y)
            {
                // Rebond en bas
                float angle = MathHelper.ToRadians((float)randomAngleInDegrees); // Convertir l'angle en radians

                Speed = new Vector2(Speed.Length() * (float)Math.Sin(angle), -Math.Abs(Speed.Length() * (float)Math.Cos(angle)));
            }
            else if (Position.Y + Height / 2 >= brick.Position.Y + brick.Height)
            {
                // Rebond en haut
                float angle = MathHelper.ToRadians((float)randomAngleInDegrees); // Convertir l'angle en radians
                Speed = new Vector2(Speed.Length() * (float)Math.Sin(angle), Math.Abs(Speed.Length() * (float)Math.Cos(angle)));
            }
        }
    }
}
