
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Utils;

namespace MyGame.GUI;

public class Label : UiElement
{
    private static SpriteBatch _spriteBatch;
    private static Texture2D _fontTexture;
    private static Dictionary<char, Rectangle> _fontMap;
    private static Texture2D _punctuationTexture;
    private static Dictionary<char, Rectangle> _punctuationMap;
    
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
        (_punctuationTexture,_punctuationMap) = AssetManager.LoadTexture<char>("Punctuation", "Font");
    }
    
    public override void Draw(SpriteBatch spriteBatch)
    {
        int tempX = X;
            
        foreach (char c in Text)
        {
            
            
            if (_fontMap.TryGetValue(c, out Rectangle rectangle1))
            {
                _spriteBatch.Draw(_fontTexture, new Vector2(tempX,Y), rectangle1, Color, 0f, Vector2.Zero, FontSize, SpriteEffects.None, 0f);
                tempX += (rectangle1.Width+1)*FontSize;
            }
            else if (_punctuationMap.TryGetValue(c, out Rectangle rectangle2))
            {
                _spriteBatch.Draw(_punctuationTexture, new Vector2(tempX,Y), rectangle2, Color, 0f, Vector2.Zero, FontSize, SpriteEffects.None, 0f);
                tempX += (rectangle2.Width+1)*FontSize;
            }
            else
            {
                _punctuationMap.TryGetValue('?', out Rectangle rectangle3);
                _spriteBatch.Draw(_punctuationTexture, new Vector2(tempX,Y), rectangle3, Color, 0f, Vector2.Zero, FontSize, SpriteEffects.None, 0f);
                tempX += (rectangle3.Width+1)*FontSize;
            }
        }
    }

    public int TextWidth()
    {
        int width = 0;
        foreach (char c in Text)
        {
            if (_fontMap.TryGetValue(c, out Rectangle rectangle1))
            {
                width += rectangle1.Width+1;
            }
            else if (_punctuationMap.TryGetValue(c, out Rectangle rectangle2))
            {
                width += rectangle2.Width+1;
            }
            else
            {
                _punctuationMap.TryGetValue('?', out Rectangle rectangle3);
                width += rectangle3.Width+1;
            }
        }
        return width;
    }


}