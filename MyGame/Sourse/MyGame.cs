using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame_v1;
using MyGame_v1.GUI;
using MyGame_v1.Utils;

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
        
       // _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
       // _graphics.PreferredBackBufferHeight =  GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
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

        _button = new Button(LocalizationManager.GetTranslation("new_game"), 10, 100,100, Color.Black);
        _label = new Label("",4,16,0,Color.White);


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        
        InputManager.KeyControl();
        _label.Text = $"FPS: {PerformanceMonitor.Fps(gameTime)}";
       
  
        _button.Update(gameTime);
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Chocolate);
        
        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
        
        _label.Draw(_spriteBatch);
        _button.Draw(_spriteBatch);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}