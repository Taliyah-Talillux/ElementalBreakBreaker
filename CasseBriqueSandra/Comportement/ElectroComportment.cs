using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CasseBriqueSandra.Comportement
{
    public class ElectroComportment : BrickComportment
    {
        public override void TouchedByBasic(Brick pTouchedBrick, List<Brick> bricks)
        {
            var myBall = ServiceLocator.GetService<Ball>();
            myBall.ReverseBallWithBrick(pTouchedBrick);
        }

        public override void TouchedByCryo(Brick pTouchedBrick, List<Brick> bricks)
        {
            pTouchedBrick.Type = ElementalType.Cryo;
            pTouchedBrick.isTypeChanged = true;
            pTouchedBrick.ToRemove = true;
        }

        public override void TouchedByElectro(Brick pTouchedBrick, List<Brick> bricks)
        {
            var myBall = ServiceLocator.GetService<Ball>();
            myBall.ReverseBallWithBrick(pTouchedBrick);
            pTouchedBrick.ToRemove = true;
        }

        public override void TouchedByHydro(Brick pTouchedBrick, List<Brick> bricks)
        {
            Vector2 touchPos = pTouchedBrick.Position;

            foreach (var brick in bricks.Where(b => b.Group == pTouchedBrick.Group && b.Position.Y == touchPos.Y))
            {
                brick.ToRemove = true;
            }
        }

        public override void TouchedByPyro(Brick pTouchedBrick, List<Brick> bricks)
        {
            foreach (var brick in bricks.Where(b => b.Group == pTouchedBrick.Group && b.Type == ElementalType.Electro))
            {
                brick.ToRemove = true;
            }
        }
    }
}
