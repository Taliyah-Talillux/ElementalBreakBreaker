using Microsoft.Xna.Framework;
using System;

namespace CasseBriqueSandra.Camera
{
    public class Camera
    {
        public Vector2 Position = Vector2.Zero;
        private float timer;
        private float? duration;
        private float intensity;
        private static Random rnd = new Random();

        public void Shake(float pIntensity, float pDuration)
        {
            duration = pDuration;
            intensity = pIntensity;
            timer = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (duration != null)
            {

                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                // bouger cam
                if (timer < duration)
                {
                    var x = (rnd.NextSingle() * 2 - 1) * intensity;
                    var y = (rnd.NextSingle() * 2 - 1) * intensity;
                    Position = new Vector2(x, y);
                }
                else if (timer >= duration)
                {
                    Position = Vector2.Zero;
                    duration = null;
                }
            }
        }
    }

}
