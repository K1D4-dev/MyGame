using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Scene;

public abstract class Scene
{
    protected SpriteBatch SpriteBatch;

    public Scene(SpriteBatch spriteBatch)
    {
        SpriteBatch = spriteBatch;
    }

    public virtual void LoadContent() { }
    public virtual void UnloadContent() { }
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
}