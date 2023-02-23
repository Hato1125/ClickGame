namespace ClickGame;

internal static class ResourceManeger
{
    /// <summary>
    /// リソースの辞書
    /// </summary>
    public static Dictionary<ResourceType, IResourceManageable> Resource = new()
    {
        { ResourceType.Graphics, new GraphicsResource() },
        { ResourceType.Sound, new SoundResource() },
    };

    /// <summary>
    /// 全てのリソースを削除する
    /// </summary>
    public static void RemoveResource()
    {
        Console.WriteLine("[Log] Delete all resources.");
        foreach (var resource in Resource)
            resource.Value.RemoveAllResource();
    }

    /// <summary>
    /// リソースの種類
    /// </summary>
    public enum ResourceType
    {
        Graphics,
        Sound,
    }
}