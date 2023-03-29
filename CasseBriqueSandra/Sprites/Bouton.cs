using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace CasseBriqueSandra.Sprites;


public delegate void Onclick(Button pSender);
public class Button : Sprite
{
    public bool IsHover { get; private set; }
    private MouseState oldMState;

    public Onclick OnClick;
    public Button(Texture2D pTexture) : base()
    {
        Texture = pTexture;
    }

    public override void Update(GameTime pGameTime)
    {
        MouseState newMState = Mouse.GetState();
        Point MousePos = newMState.Position;

        if (BoundingBox.Contains(MousePos))
        {
            if (!IsHover)
            {
                IsHover = true;
            }
            else
            {
                if (IsHover == true)
                {
                    Debug.WriteLine("Button is no more Hover ! ");
                }
                IsHover = false;
            }
            if (IsHover)
            {
                if (newMState.LeftButton == ButtonState.Pressed && oldMState.LeftButton == ButtonState.Released)
                {
                    if (OnClick != null)
                    {
                        OnClick(this);
                    }
                }
            }
        }
        oldMState = newMState;
        base.Update(pGameTime);
    }


}
