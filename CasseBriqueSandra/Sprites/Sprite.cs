using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CasseBriqueSandra
{
    public class Sprite : IActor
    {
        protected ContentManager Content { get; set; } = ServiceLocator.GetService<ContentManager>();
        public Vector2 Position { get; set; }
        public virtual Vector2 Speed { get; set; }
        public Rectangle BoundingBox { get; set; }
        public int Width
        {
            get
            {
                return Texture.Width;
            }
        }
        public int Height
        {
            get
            {
                return Texture.Height;
            }
        }
        public virtual Texture2D Texture { get; protected set; }

        public bool ToRemove { get; set; }

        public Sprite()
        {
        }
        public Sprite(Vector2 pPosition)
        {
            Position = pPosition;
        }
        public void SetPosition(Vector2 pPosition)
        {
            Position = pPosition;
        }
        public void SetPosition(float pX, float pY)
        {
            Position = new Vector2(pX, pY);
        }
        public void Move()
        {
            Position += Speed;
        }
        public virtual void TouchedBy(IActor pBy)
        {
        }
        public virtual void Load()
        {
        }
        public virtual void Update(GameTime pgameTime)
        {
            Move();

            BoundingBox = new Rectangle(
              (int)Position.X,
              (int)Position.Y,
              Texture.Width,
              Texture.Height
              );
        }
        public virtual void Draw()
        {
            var spriteBatch = ServiceLocator.GetService<SpriteBatch>();
            var camera= ServiceLocator.GetService<Camera>();
            spriteBatch.Draw(Texture, Position + camera.Position, Color.White);
        }
    }
}
