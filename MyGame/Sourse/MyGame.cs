using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MyGame.GUI;
using MyGame.Scene;
using MyGame.Sourse.Managers;
using MyGame.Utils;

namespace MyGame;

public class MyGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Label _label;
    private Button _button;

    public MyGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        
        IsMouseVisible = true; //Бачити мишку в грі
        Window.Title = "My Game"; //назва вікна
        Window.AllowUserResizing = false;// Дозволити зміну розмірів вікна
        Window.IsBorderless = true; // Відображати грані вікна
        _graphics.SynchronizeWithVerticalRetrace = false; //Вертикальна синхронізація
        IsFixedTimeStep = false; // фіксована затримка
        _graphics.IsFullScreen = false; //Повноекранний режим
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
       _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
       _graphics.PreferredBackBufferHeight =  GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        AssetManager.Load(GraphicsDevice);
        LocalizationManager.LoadLanguage(_spriteBatch,"EN");
        
        InputManager.Load(this);
        
        Button.Load(_spriteBatch);

        SceneManager.SetScene(new MainMenuScene(_spriteBatch));


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        
        InputManager.KeyControl();
        
        SceneManager.Update(gameTime);
  
     
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Chocolate);
        
        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
        
        SceneManager.Draw(_spriteBatch);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}