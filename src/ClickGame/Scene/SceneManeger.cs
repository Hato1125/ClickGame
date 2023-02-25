namespace ClickGame;

internal static class SceneManeger
{
    /// <summary>
    /// シーンの辞書
    /// </summary>
    private static Dictionary<string, SceneBase> scenes = new();

    /// <summary>
    /// 現在のシーンの実態
    /// </summary>
    private static SceneBase? scene = null;

    /// <summary>
    /// 現在のシーンの名前
    /// </summary>
    public static string NowSceneName { get; private set; } = string.Empty;

    /// <summary>
    /// シーンを登録する
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    /// <param name="scene">シーンの実態</param>
    public static void AddScene(string sceneName, SceneBase scene)
    {
        Tracer.WriteInfo($"Add {sceneName} scene");
        scenes.Add(sceneName, scene);

        if (NowSceneName == string.Empty)
            SetScene(sceneName);
    }

    /// <summary>
    /// シーンをセットする
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    public static void SetScene(string sceneName)
    {
        Tracer.WriteInfo($"Set {sceneName} scene.");
        if (scene != null)
        {
            scene.Finish();
            scene.IsInit = true;
        }

        scene = scenes[sceneName];
        NowSceneName = sceneName;
    }

    /// <summary>
    /// シーンを削除する
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    public static void RemoveScene(string sceneName)
    {
        Tracer.WriteInfo($"Delete {sceneName} scene.");
        if (scene == scenes[sceneName])
        {
            NowSceneName = string.Empty;
            scene = null;
        }

        scenes[sceneName].Finish();
        scenes.Remove(sceneName);
    }

    /// <summary>
    /// すべてのシーンを削除する
    /// </summary>
    public static void AllClear()
    {
        Tracer.WriteInfo("Delete all scenes.");
        foreach (var item in scenes)
            item.Value.Finish();

        scenes.Clear();
        scene = null;
        NowSceneName = string.Empty;
    }

    /// <summary>
    /// シーンを表示する
    /// </summary>
    public static void SceneView()
    {
        if(scene == null)
            return;

        if(scene.IsInit)
        {
            scene.Init();
            scene.IsInit = false;
        }

        scene.Update();
        scene.Draw();
    }
}