using DxLibDLL;

namespace ClickGame;

internal static class SoundResource
{
    private static readonly Dictionary<string, int> Resources = new();

    public static void AddResource(string resourceName, string fileName)
    {
        int img = DX.LoadSoundMem(fileName);

        if (img == -1)
            Tracer.WriteWarning("Failed to load resource.");

        Resources.Add(resourceName, img);
    }

    public static void RemoveResource(string resourceName)
    {
        DX.DeleteSoundMem(Resources[resourceName]);
        Resources.Remove(resourceName);
    }

    public static void RemoveAllResource()
    {
        Tracer.WriteInfo("Delete all sound resources.");
        foreach (var item in Resources)
            DX.DeleteSoundMem(item.Value);

        Resources.Clear();
    }

    public static int GetResource(string resourceName)
        => Resources[resourceName];
}