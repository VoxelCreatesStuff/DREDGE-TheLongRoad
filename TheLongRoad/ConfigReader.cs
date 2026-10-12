using UnityEngine;
using Newtonsoft.Json.Linq;
using System.IO;

public static class ConfigReader
{
    private static JObject config;

    public static void Load(string filePath)
    {
        config = JObject.Parse(File.ReadAllText(filePath));
    }

    public static float GetFloat(string key)
    {
        if (config == null)
        {
            Debug.LogError("Config not loaded!");
            return 0f;
        }

        JToken entry = config[key]?["value"];

        if (entry != null && float.TryParse(
            entry.ToString(),
            System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture,
            out float result))
        {
            return result;
        }

        Debug.LogError($"Float key '{key}' not found!");
        return 0f;
    }
}