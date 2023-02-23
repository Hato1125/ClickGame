namespace ClickGame;

internal static class ResourceManeger
{
    public static readonly string GraphicsPath = $"{AppContext.BaseDirectory}Asset\\Graphics\\";
    public static readonly string SoundPath = $"{AppContext.BaseDirectory}Asset\\Sound\\";
    public static readonly string LuaPath = $"{AppContext.BaseDirectory}Asset\\Lua\\";

    /// <summary>
    /// リソースの辞書
    /// </summary>
    public static Dictionary<ResourceType, IResourceManageable> Resource = new()
    {
        { ResourceType.Graphics, new GraphicsResource() },
        { ResourceType.Sound, new SoundResource() },
        { ResourceType.Lua, new LuaResource() }
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
}

/// <summary>
/// リソースの種類
/// </summary>
public enum ResourceType
{
    Graphics,
    Sound,
    Lua,
}