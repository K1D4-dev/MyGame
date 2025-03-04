
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class InputManager
{
    private static MyGame _game;
    
    public static void Load(MyGame game)
    {
        _game = game;
    }
    
    public static void KeyControl()
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
           
            _game.Exit();
        }
    }
}