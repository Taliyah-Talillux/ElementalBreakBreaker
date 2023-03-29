using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBriqueSandra
{
    public interface IScreenService
    {
        int ScreenWidth();
        int ScreenHeight(); 
    }
    public class ScreenInfo : IScreenService
    {
        private GameWindow gameWindow;
        public ScreenInfo(GameWindow pWindow) 
        { 
            gameWindow = pWindow;  
        }

        public int ScreenWidth()
        {
            return gameWindow.ClientBounds.Width;  
        }
        public int ScreenHeight() 
        {
            return gameWindow.ClientBounds.Height;
        }
    }
}
