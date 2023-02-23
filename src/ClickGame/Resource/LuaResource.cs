using NLua;

namespace ClickGame;

internal class LuaResource : IResourceManageable
{
    private readonly Dictionary<string, Lua> Resources = new();

    public void AddResource(string resourceName, string fileName)
    {
        var lua = new Lua();
        lua.DoFile(fileName);
        Resources.Add(resourceName, lua);
    }

    public void RemoveResource(string resourceName)
    {
        Resources[resourceName].Dispose();
        Resources.Remove(resourceName);
    }

    public void RemoveAllResource()
    {
        foreach (var item in Resources)
            item.Value.Dispose();

        Resources.Clear();
    }

    public object GetResource(string resourceName)
        => Resources[resourceName];
}