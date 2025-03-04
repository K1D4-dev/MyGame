
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame_v1.Utils;

namespace MyGame_v1.GUI;

public class Label : UiElement
{
    private static SpriteBatch _spriteBatch;
    private static Texture2D _fontTexture;
    private static Dictionary<char, Rectangle> _fontMap;
    
    public string Text { get; set; }
    private byte FontSize {get; set;}
    
    public Label(string text, byte textSize, int x, int y, Color color) : base(x, y, color)
    {
        Text = text;
        FontSize = textSize;
    }
    
    public static void Load(SpriteBatch spriteBatch, string writing)
    {
        _spriteBatch = spriteBatch;
        (_fontTexture,_fontMap) = AssetManager.LoadTexture<char>(writing, "Font");
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        int tempX = X;
        foreach (char c in Text)
        {
            
            
            if (_fontMap.TryGetValue(c, out Rectangle rectangle))
            {
                _spriteBatch.Draw(_fontTexture, new Vector2(tempX,Y), rectangle, Color, 0f, Vector2.Zero, FontSize, SpriteEffects.None, 0f);
                tempX += (rectangle.Width+1)*FontSize;
            }
            else
            {
                _fontMap.TryGetValue('A', out rectangle);
                _spriteBatch.Draw(_fontTexture, new Vector2(tempX,Y), rectangle, Color, 0f, Vector2.Zero, FontSize, SpriteEffects.None, 0f);
                tempX += (rectangle.Width+1)*FontSize;
            }
        }
    }

    public int TextWidth()
    {
        int width = 0;
        foreach (char c in Text)
        {
            if (_fontMap.TryGetValue(c, out Rectangle rectangle))
            {
                width += rectangle.Width+1;
            }
            else
            {
                _fontMap.TryGetValue('A', out rectangle);
                width += rectangle.Width+1;
            }
        }
        return width;
    }


}