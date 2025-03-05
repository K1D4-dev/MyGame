
using Microsoft.Xna.Framework;


namespace MyGame.Utils;

public class PerformanceMonitor
{
    private static double _elapsedTime = 0;
    private static int _frameCount = 0;
    private static int _fps = 0;
    
 

    public static int Fps(GameTime gameTime)
    {
        _elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
        _frameCount++;
        if (_elapsedTime >= 1.0)
        {
            _fps = _frameCount;
            _frameCount = 0;
            _elapsedTime = 0;
            
        }
        
        return _fps;
    }


    public static double FrameTime(GameTime gameTime)
    {
        return gameTime.ElapsedGameTime.TotalSeconds;
    }
    
    
}