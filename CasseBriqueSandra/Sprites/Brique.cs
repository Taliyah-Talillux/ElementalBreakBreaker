using CasseBriqueSandra.Comportement;
using CasseBriqueSandra.Sandra;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CasseBriqueSandra;
public class Brick : Sprite
{
    public ElementalType Type;
    public Vector2 InitalPosition;
    public int Group;

    public float Distance;
    public float timer;
    public float? timeToOldElement = null;
    public ElementalType OldElement;

    public bool isTypeChanged;
    public bool isFreeze;

    protected static Dictionary<ElementalType, Texture2D> TexturesBricks = new();
    protected static Dictionary<ElementalType, BrickComportment> Comportments = new();
    public static List<Brick> Bricks = new List<Brick>();

    public Brick(Vector2 pPosition, ElementalType pType, int pGroup) : base(pPosition)
    {
        Type = pType;
        InitalPosition = new Vector2(pPosition.X, pPosition.Y);
        Group = pGroup;
        Bricks.Add(this);
    }

    public Brick(Vector2 pPosition, ElementalType pType, float pSpeed, float pDistance, int pGroup) : this(pPosition, pType, pGroup)
    {
        Distance = pDistance;
        Speed = new Vector2(pSpeed, 0);
    }

    public override void Load()
    {
        base.Load();
    }

    public override void Update(GameTime gameTime)
    {
        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (timeToOldElement != null && timer >= timeToOldElement)
        {
            isFreeze = false;
            Type = OldElement;
            isTypeChanged = false;
            timeToOldElement = null;
        }

        if (Distance >= 0)
        {
            if (Position.X >= Distance + InitalPosition.X)
            {
                Speed = new Vector2(-Math.Abs(Speed.X), 0);

            }
            else if (Position.X <= InitalPosition.X)
            {
                Speed = new Vector2(Math.Abs(Speed.X), 0);
            }
        }
        else if (Distance <= 0)
        {
            if (Position.X <= InitalPosition.X + Distance)
            {
                Speed = new Vector2(Math.Abs(Speed.X), 0);
            }
            else if (Position.X >= InitalPosition.X)
            {
                Speed = new Vector2(-Math.Abs(Speed.X), 0);
            }
        }
        CheckCollision(gameTime);

        base.Update(gameTime);
    }

    public override void Draw()
    {
        base.Draw();
    }
    public static List<Brick> CollisionsBrickWithBall(List<Brick> bricks)
    {
        Ball myBall = ServiceLocator.GetService<Ball>();

        foreach (var brick in bricks)
        {
            if (Utils.ColliedByBox(myBall, brick))
            {
                brick.TouchedBy(myBall);
            }
        }
        return bricks;
    }

    public static void LoadTexture()
    {
        ContentManager content = ServiceLocator.GetService<ContentManager>();

        TexturesBricks[ElementalType.Basic] = content.Load<Texture2D>("Briques/Brique");
        TexturesBricks[ElementalType.Cryo] = content.Load<Texture2D>("Briques/Brique_Cryo");
        TexturesBricks[ElementalType.Hydro] = content.Load<Texture2D>("Briques/Brique_Hydro");
        TexturesBricks[ElementalType.Electro] = content.Load<Texture2D>("Briques/Brique_Electro");
        TexturesBricks[ElementalType.Pyro] = content.Load<Texture2D>("Briques/Brique_Pyro");
    }

    public static void LoadComportment()
    {
        Comportments[ElementalType.Basic] = new BasicComportment();
        Comportments[ElementalType.Cryo] = new CryoComportments();
        Comportments[ElementalType.Hydro] = new HydroComportment();
        Comportments[ElementalType.Electro] = new ElectroComportment();
        Comportments[ElementalType.Pyro] = new PyroComportments();  
    }

    public void CheckCollision(GameTime gameTime)
    {
        var myBall = ServiceLocator.GetService<Ball>();

        // Vérifier si la balle touche la brique sur l'axe horizontal ou l'axe vertical
        if (Utils.ColliedByBox(myBall, this))
        {
            TouchedBy(myBall, gameTime);
        }
    }

    public void TouchedBy(Ball pBall, GameTime gameTime)
    {
        Comportment.Collision(this, Bricks);

        ServiceLocator.GetService<Camera>().Shake(5, 0.2f);
    }
    public override Texture2D Texture
    {
        get
        {
            return TexturesBricks[Type];
        }
    }

    public BrickComportment Comportment
    {
        get
        {
            return Comportments[Type];
        }
    }

    public override Vector2 Speed
    {
        get
        {
            if (isFreeze == true)
            {
                return Vector2.Zero;
            }
            return base.Speed;
        }
    }
}
