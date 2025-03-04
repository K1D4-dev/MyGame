using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame_v1.GUI;
using MyGame_v1.Utils;

namespace MyGame_v1;

public class Button : UiElement
{
    private static Dictionary<string, Rectangle> _buttonMap;
    private static Texture2D _buttonTexture;
    private static SpriteBatch _spriteBatch;

    private static readonly byte Retreat = 4;

    private MouseState _previousMouseState;

    private Rectangle ButtonRect{get;set;}
    private int TextWidth { get; }
    private string Text { get; set; }
    private byte FontSize { get; }
    private Label Label { get; }
   

    public Button(string text, byte textSize, int x, int y, Color color) : base(x, y, color)
    {
        Text = text;
        FontSize = textSize;
        Label = new Label(text, textSize, x + Retreat * FontSize, y, color);
        TextWidth = Label.TextWidth();


        ButtonRect = new Rectangle(X, Y, (TextWidth + Retreat * 2) * FontSize, 16 * FontSize);
    }

  

    public static void Load(SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
        (_buttonTexture, _buttonMap) = AssetManager.LoadTexture<string>("Button", "Texture");
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        int tempX = X;
        if (_buttonMap.TryGetValue("button-left", out var rectangle))
            _spriteBatch.Draw(_buttonTexture, new Vector2(tempX, Y), rectangle, Color.White, 0f, Vector2.Zero,
                new Vector2(FontSize, FontSize), SpriteEffects.None, 0f);

        tempX += Retreat * FontSize;
        if (_buttonMap.TryGetValue("button-center", out var rectangle1))
            _spriteBatch.Draw(_buttonTexture, new Vector2(tempX, Y), rectangle1, Color.White, 0f, Vector2.Zero,
                new Vector2(TextWidth * FontSize / rectangle1.Width, FontSize), SpriteEffects.None, 0f);
        tempX += TextWidth * FontSize;
        if (_buttonMap.TryGetValue("button-right", out var rectangle2))
            _spriteBatch.Draw(_buttonTexture, new Vector2(tempX, Y), rectangle2, Color.White, 0f, Vector2.Zero,
                new Vector2(FontSize, FontSize), SpriteEffects.None, 0f);
        
        Label.Draw(spriteBatch);
    }

    internal void Update(GameTime gameTime)
    {
        var mouse = Mouse.GetState();

        if (ButtonRect.Contains(mouse.Position) &&
            mouse.LeftButton == ButtonState.Pressed &&
            _previousMouseState.LeftButton == ButtonState.Released)
            Console.WriteLine("Кнопка натиснута!");

        _previousMouseState = mouse; // Оновлюємо стан мишки
    }
}