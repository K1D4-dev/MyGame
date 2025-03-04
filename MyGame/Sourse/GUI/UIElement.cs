using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame_v1;

public abstract class UiElement
{

    protected int X{get; set;}
    protected int Y{get; set;}
        
        
    protected Color Color{get; set;}
    
    
    public UiElement(int x, int y, Color color)
    {
        X = x;
        Y = y;
        Color = color;
    }

    public abstract void Draw(SpriteBatch spriteBatch);
}
