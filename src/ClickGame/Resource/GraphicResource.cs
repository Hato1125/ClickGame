using DxLibDLL;

namespace ClickGame;

internal class GraphicsResource : IResourceManageable
{
    private readonly Dictionary<string, int> Resources = new();

    public void AddResource(string resourceName, string fileName)
    {
        int img = DX.LoadGraph(fileName);

        if (img == -1)
            Console.WriteLine("[Warning] Failed to load resource.");

        Resources.Add(resourceName, img);
    }

    public void RemoveResource(string resourceName)
    {
        DX.DeleteGraph(Resources[resourceName]);
        Resources.Remove(resourceName);
    }

    public void RemoveAllResource()
    {
        foreach (var item in Resources)
            DX.DeleteGraph(item.Value);

        Resources.Clear();
    }

    public int GetResource(string resourceName)
        => Resources[resourceName];
}