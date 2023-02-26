using System.Diagnostics;
using DxLibDLL;
using ClickGame.GameScene.TitleScene;
using ClickGame.GameScene.GameScene;

namespace ClickGame;

internal class App
{
    private readonly Stopwatch stopwatch = new();

    /// <summary>
    /// Windowの横幅
    /// </summary>
    public static readonly int CliantWidth = 1280;

    /// <summary>
    /// Windowの高さ
    /// </summary>
    public static readonly int CliantHeight = 720;

    /// <summary>
    /// アプリケーションの名前
    /// </summary>
    public static readonly string AppName = "ClickGame";

    /// <summary>
    /// アプリケーションのバージョン
    /// </summary>
    public static readonly string AppVer = "1.0.0";

    /// <summary>
    /// ランダム
    /// </summary>
    public static readonly Random Random = new Random(DX.GetRand(1000));

    /// <summary>
    /// メインループの1Tickの時間
    /// </summary>
    public static TimeSpan GameTime { get; private set; } = TimeSpan.Zero;

    /// <summary>
    /// 最大フレームレート
    /// </summary>
    public static double MaxFramelate { get; set; } = 60;

    /// <summary>
    /// アプリケーションを起動する
    /// </summary>
    public void Run()
    {
        Initialize();
        WindowLoop();
        Finalizer();
    }

    private void Initialize()
    {
        Tracer.WriteInfo("Start Dxlib initialization.");
        if (DX.SetOutApplicationLogValidFlag(DX.FALSE) == -1
            || DX.SetGraphMode(CliantWidth, CliantHeight, 32) == -1
            || DX.SetWindowSize(CliantWidth, CliantHeight) == -1
            || DX.SetWindowText(AppName) == -1
            || DX.SetMainWindowClassName(AppName) == -1
            || DX.SetAlwaysRunFlag(DX.TRUE) == -1
            || DX.ChangeWindowMode(DX.TRUE) == -1
            || DX.DxLib_Init() == -1)
        {
            Tracer.WriteError("Failed to initialize Dxlib.");
            throw new Exception("Failed to initialize Dxlib.");
        }

        LoadGraphics.Load();

        SceneManeger.AddScene("Title", new Title());
        SceneManeger.AddScene("Game", new Game());
    }

    private void WindowLoop()
    {
        while (DX.ProcessMessage() != -1)
        {
            stopwatch.Restart();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.ClearDrawScreen();

            Mouse.Update();
            Keyboard.Update();
            SceneManeger.SceneView();

            DX.ScreenFlip();
            FramelateLimiter();
            GameTime = stopwatch.Elapsed;
        }
    }


    private void Finalizer()
    {
        SceneManeger.AllClear();
        GraphicsResource.RemoveAllResource();
        SoundResource.RemoveAllResource();
        LuaResource.RemoveAllResource();
        DX.DxLib_End();
    }

    private void FramelateLimiter()
    {
        double ms = 1.0 / MaxFramelate;

        if (stopwatch.Elapsed.TotalSeconds < ms)
        {
            double sleepMs = (ms - stopwatch.Elapsed.TotalSeconds) * 1000.0;
            Thread.Sleep((int)sleepMs);
        }
    }
}