namespace ClickGame;

internal static class LoadSound
{
    private static readonly string FILE = $"{AppContext.BaseDirectory}Asset\\Sound\\";

    /// <summary>
    /// Soundを読み込む
    /// </summary>
    public static void Load()
    {
        SoundResource.AddResource("PushButton", $"{FILE}PushButton.mp3");
    }
}