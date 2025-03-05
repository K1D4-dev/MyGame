using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.GUI;
using MyGame.Sourse.Managers;
using MyGame.Utils;

namespace MyGame.Scene;

public class MainMenuScene : Scene
{
    private Label _label;
    private Button _button;

    public MainMenuScene(SpriteBatch spriteBatch) : base(spriteBatch)
    {
    }

    public override void LoadContent()
    {
        _button = new Button(LocalizationManager.GetTranslation("new_game"), 10, 100,100, Color.Black);
        _label = new Label("",4,16,0,Color.White);
    }


    public override void Update(GameTime gameTime)
    {
        _button.Update(gameTime);
        _label.Text = $"FPS: {PerformanceMonitor.Fps(gameTime)}";
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        _label.Draw(spriteBatch);
        _button.Draw(spriteBatch);
    }
}