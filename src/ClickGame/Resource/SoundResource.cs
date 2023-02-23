using DxLibDLL;

namespace ClickGame;

internal class SoundResource : IResourceManageable
{
    private readonly Dictionary<string, int> Resources = new();

    public void AddResource(string resourceName, string fileName)
    {
        int img = DX.LoadSoundMem(fileName);

        if (img == -1)
            Console.WriteLine("[Warning] Failed to load resource.");

        Resources.Add(resourceName, img);
    }

    public void RemoveResource(string resourceName)
    {
        DX.DeleteSoundMem(Resources[resourceName]);
        Resources.Remove(resourceName);
    }

    public void RemoveAllResource()
    {
        foreach (var item in Resources)
            DX.DeleteSoundMem(item.Value);

        Resources.Clear();
    }

    public object GetResource(string resourceName)
        => Resources[resourceName];
}