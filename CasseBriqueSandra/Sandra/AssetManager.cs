using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBriqueSandra.Sandra;

class AssetManager
{
    public static SpriteFont MainFont { get; private set; }
    public static ContentManager pContent { get; private set; }

    public static void Load()
    {
        pContent = ServiceLocator.GetService<ContentManager>();
        MainFont = pContent.Load<SpriteFont>("MainFont");
    }
}
