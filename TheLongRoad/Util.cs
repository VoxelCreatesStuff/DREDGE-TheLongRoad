using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

public static class Util
{
    public static T GetJSON<T>(string filename)
    {
        string folder = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location
        );
        string path = Path.Combine(folder, filename + ".jsonc");

        if (File.Exists(path))
        {
            return JsonConvert.DeserializeObject<T>(
                File.ReadAllText(path)
            );
        }

        T instance = Activator.CreateInstance<T>();

        File.WriteAllText(
            path,
            JsonConvert.SerializeObject(instance, Formatting.Indented)
        );

        return instance;
    }
}