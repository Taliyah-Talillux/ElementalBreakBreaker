using System.Collections.Generic;
using System.Linq;

namespace CasseBriqueSandra.Comportement
{
    public class PyroComportments : BrickComportment
    {
        public override void TouchedByBasic(Brick pTouchedBrick, List<Brick> bricks)
        {
            var myBall = ServiceLocator.GetService<Ball>();
            myBall.ReverseBallWithBrick(pTouchedBrick);
        }

        public override void TouchedByCryo(Brick pTouchedBrick, List<Brick> bricks)
        {
            var myBall = ServiceLocator.GetService<Ball>();
            myBall.ReverseBallWithBrick(pTouchedBrick);
            pTouchedBrick.ToRemove = true;
        }

        public override void TouchedByElectro(Brick pTouchedBrick, List<Brick> bricks)
        {
            var myBall = ServiceLocator.GetService<Ball>();
            myBall.ReverseBallWithBrick(pTouchedBrick);

            foreach (var brick in bricks.Where(b => b.Group == pTouchedBrick.Group && b.Type == ElementalType.Pyro))
            {
                brick.ToRemove = true;
            }
        }

        public override void TouchedByHydro(Brick pTouchedBrick, List<Brick> bricks)
        {
            var myBall = ServiceLocator.GetService<Ball>();
            myBall.ReverseBallWithBrick(pTouchedBrick);
            pTouchedBrick.ToRemove = true;

        }

        public override void TouchedByPyro(Brick pTouchedBrick, List<Brick> bricks)
        {
            var myBall = ServiceLocator.GetService<Ball>();
            myBall.ReverseBallWithBrick(pTouchedBrick);
            pTouchedBrick.ToRemove = true;
        }
    }
}
