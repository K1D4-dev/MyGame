using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace MyGame.Utils;

public static class AssetManager
{
    private static GraphicsDevice _graphicsDevice;
    
    public static void Load(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
    }

    public static (Texture2D ,Dictionary<T, Rectangle>) LoadTexture<T>(string name, string folder)
    {
        Texture2D texture;
        
        
        using (var stream = File.OpenRead($"Content/{folder}s/{name}.png"))
        {
            texture = Texture2D.FromStream(_graphicsDevice, stream);
        }
        
        string jsonText = File.ReadAllText($"Content/{folder}s/{name}.json");
        Dictionary<T, Rectangle> spriteMap = JsonConvert.DeserializeObject<Dictionary<T, Rectangle>>(jsonText);
        Console.WriteLine($"{name} texture loaded");
        return (texture, spriteMap);
    }
    
    

}