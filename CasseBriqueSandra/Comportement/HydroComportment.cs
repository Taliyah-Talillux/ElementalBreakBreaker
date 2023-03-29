using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CasseBriqueSandra.Comportement;

public class HydroComportment : BrickComportment
{
    public override void TouchedByBasic(Brick pTouchedBrick, List<Brick> bricks)
    {
        var myBall = ServiceLocator.GetService<Ball>();
        myBall.ReverseBallWithBrick(pTouchedBrick);
    }

    public override void TouchedByCryo(Brick pTouchedBrick, List<Brick> Bricks)
    {
        var myBall = ServiceLocator.GetService<Ball>();
        myBall.ReverseBallWithBrick(pTouchedBrick);

        foreach (var brick in Bricks.Where(b => b.Group == pTouchedBrick.Group))
        {
            brick.isFreeze = true;
            brick.OldElement = ElementalType.Hydro;
            brick.Type = ElementalType.Cryo;
            brick.isTypeChanged = true;
            brick.timeToOldElement = brick.timer + 2;
        }
    }
    public override void TouchedByElectro(Brick pTouchedBrick, List<Brick> bricks)
    {
        var myBall = ServiceLocator.GetService<Ball>();
        myBall.ReverseBallWithBrick(pTouchedBrick);

        Vector2 touchPos = pTouchedBrick.Position;

        foreach (var brick in bricks.Where(b => b.Group == pTouchedBrick.Group && b.Position.Y == touchPos.Y))
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
