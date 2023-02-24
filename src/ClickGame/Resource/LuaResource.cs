using NLua;

namespace ClickGame;

internal static class LuaResource
{
    private static readonly Dictionary<string, Lua> Resources = new();

    public static void AddResource(string resourceName, string fileName)
    {
        var lua = new Lua();
        lua.DoFile(fileName);
        Resources.Add(resourceName, lua);
    }

    public static void RemoveResource(string resourceName)
    {
        Resources[resourceName].Dispose();
        Resources.Remove(resourceName);
    }

    public static void RemoveAllResource()
    {
        foreach (var item in Resources)
            item.Value.Dispose();

        Resources.Clear();
    }

    public static Lua GetResource(string resourceName)
        => Resources[resourceName];
}