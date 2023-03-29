using System.Collections.Generic;

namespace CasseBriqueSandra.Comportement
{
    public abstract class BrickComportment
    {
        public void Collision(Brick pTouchedBrick, List<Brick> bricks)
        {
            var myBall = ServiceLocator.GetService<Ball>();

            switch (myBall.Type)
            {
                case ElementalType.Basic:
                    TouchedByBasic(pTouchedBrick, bricks);
                    break;
                case ElementalType.Cryo:
                    TouchedByCryo(pTouchedBrick, bricks);
                    break;
                case ElementalType.Hydro:
                    TouchedByHydro(pTouchedBrick, bricks);
                    break;
                case ElementalType.Pyro:
                    TouchedByPyro(pTouchedBrick, bricks);
                    break;
                case ElementalType.Electro:
                    TouchedByElectro(pTouchedBrick, bricks);
                    break;
            }
        }
        public abstract void TouchedByBasic(Brick pTouchedBrick, List<Brick> bricks);
        public abstract void TouchedByCryo(Brick pTouchedBrick, List<Brick> bricks);
        public abstract void TouchedByHydro(Brick pTouchedBrick, List<Brick> bricks);
        public abstract void TouchedByPyro(Brick pTouchedBrick, List<Brick> bricks);
        public abstract void TouchedByElectro(Brick pTouchedBrick, List<Brick> bricks);

    }
}
