using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using MyGame.GUI;
using Newtonsoft.Json;

namespace MyGame;

public static class LocalizationManager
{
    private static Dictionary<string, LM> _languages = new Dictionary<string, LM>();
    private static Dictionary<string, string> _translations = new Dictionary<string, string>();
    
    public static void LoadLanguage(SpriteBatch spriteBatch ,string langCode)
    {
        _translations.Clear(); // Видаляємо всі старі переклади
        string langPath = "Content/Localization/Languages.lm";
        string translationPath = $"Content/Localization/Languages/{langCode}.lang";
        
        if (File.Exists(langPath))
        {
            string json = File.ReadAllText(langPath);
            _languages = JsonConvert.DeserializeObject<Dictionary<string, LM>>(json);
            Console.WriteLine("Завантажені мови: ");
            foreach (KeyValuePair<string, LM> pair in _languages)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            if (File.Exists(translationPath) && _languages.TryGetValue(langCode, out LM lm))
            {
                json = File.ReadAllText(translationPath);
                var newTranslations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                foreach (var entry in newTranslations)
                {
                    _translations[entry.Key] = entry.Value;
                }
                string writing = lm.Writing;
                Label.Load(spriteBatch, writing);
            }
        }
        
        
    }
    
    public static string GetTranslation(string key)
    {
        return _translations.TryGetValue(key, out var value) ? value : $"[{key}]";
    }
    
    private struct LM
    {
        public string Name;
        public string Writing;
    }

}

