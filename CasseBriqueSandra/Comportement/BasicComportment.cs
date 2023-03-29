using System.Collections.Generic;

namespace CasseBriqueSandra.Comportement;

public class BasicComportment : BrickComportment
{
    public override void TouchedByBasic(Brick pTouchedBrick, List<Brick> bricks)
    {
        var myBall = ServiceLocator.GetService<Ball>();
        myBall.ReverseBallWithBrick(pTouchedBrick);
    }

    public override void TouchedByCryo(Brick pTouchedBrick, List<Brick> bricks)
    {
        Ball myBall = ServiceLocator.GetService<Ball>();
        myBall.ReverseBallWithBrick(pTouchedBrick);

        if (!pTouchedBrick.isTypeChanged)
        {
            pTouchedBrick.Type = myBall.Type;
            pTouchedBrick.isTypeChanged = true;
        }
    }

    public override void TouchedByElectro(Brick pTouchedBrick, List<Brick> bricks)
    {
        Ball myBall = ServiceLocator.GetService<Ball>();
        myBall.ReverseBallWithBrick(pTouchedBrick);

        if (!pTouchedBrick.isTypeChanged)
        {
            pTouchedBrick.Type = myBall.Type;
            pTouchedBrick.isTypeChanged = true;
        }
    }

    public override void TouchedByHydro(Brick pTouchedBrick, List<Brick> bricks)
    {
        Ball myBall = ServiceLocator.GetService<Ball>();
        myBall.ReverseBallWithBrick(pTouchedBrick);

        if (!pTouchedBrick.isTypeChanged)
        {
            pTouchedBrick.Type = myBall.Type;
            pTouchedBrick.isTypeChanged = true;
        }
    }

    public override void TouchedByPyro(Brick pTouchedBrick, List<Brick> bricks)
    {
        Ball myBall = ServiceLocator.GetService<Ball>();
        myBall.ReverseBallWithBrick(pTouchedBrick);

        if (!pTouchedBrick.isTypeChanged)
        {
            pTouchedBrick.Type = myBall.Type;
            pTouchedBrick.isTypeChanged = true;
        }
    }
}
