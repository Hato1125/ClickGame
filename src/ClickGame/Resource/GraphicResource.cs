using DxLibDLL;

namespace ClickGame;

internal static class GraphicsResource
{
    private static readonly Dictionary<string, int> Resources = new();

    public static void AddResource(string resourceName, string fileName)
    {
        int img = DX.LoadGraph(fileName);

        if (img == -1)
            Console.WriteLine("[Warning] Failed to load resource.");

        Resources.Add(resourceName, img);
    }

    public static void RemoveResource(string resourceName)
    {
        DX.DeleteGraph(Resources[resourceName]);
        Resources.Remove(resourceName);
    }

    public static void RemoveAllResource()
    {
        foreach (var item in Resources)
            DX.DeleteGraph(item.Value);

        Resources.Clear();
    }

    public static int GetResource(string resourceName)
        => Resources[resourceName];
}