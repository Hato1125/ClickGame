using NLua;

namespace ClickGame;

internal static class LuaResource
{
    private static readonly Dictionary<string, Lua> Resources = new();

    public static void AddResource(string resourceName, string fileName)
    {
        try
        {
            var lua = new Lua();
            lua.DoFile(fileName);
            Resources.Add(resourceName, lua);
        }
        catch
        {
            Tracer.WriteError("Failed to load Lua resource.");
        }
    }

    public static void RemoveResource(string resourceName)
    {
        Resources[resourceName].Dispose();
        Resources.Remove(resourceName);
    }

    public static void RemoveAllResource()
    {
        Tracer.WriteInfo("Remove all Lua resources.");
        foreach (var item in Resources)
            item.Value.Dispose();

        Resources.Clear();
    }

    public static Lua GetResource(string resourceName)
        => Resources[resourceName];
}