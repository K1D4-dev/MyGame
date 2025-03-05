using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Sourse.Managers;

public static class SceneManager
{
    private static Scene.Scene _currentScene;

    public static void SetScene(Scene.Scene newScene)
    {
        _currentScene?.UnloadContent(); // Видаляємо попередню сцену
        _currentScene = newScene;
        _currentScene.LoadContent();
    }

    public static void Update(GameTime gameTime) => _currentScene?.Update(gameTime);
    public static void Draw(SpriteBatch spriteBatch) => _currentScene?.Draw(spriteBatch);
}
