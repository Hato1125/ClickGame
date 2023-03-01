using DxLibDLL;
using ClickGame.Utilt;

namespace ClickGame.GameScene.TitleScene;

internal class Title : SceneBase
{
    #region Private Member

    private const string DEVNAME = "Developer: Hato1125";
    private readonly FontString DevName;
    private readonly Fade Fade = new(0.001f, 3.5);

    #endregion

    #region Public static Member

    /// <summary>
    /// フェードアウトをするか
    /// </summary>
    public static bool IsFadeOut { get; set; }

    /// <summary>
    /// フェードアウトが終了した際に呼ばれル
    /// </summary>
    public static event Action? OnFadeOutEnd = delegate { };

    #endregion

    public Title()
    {
        DX.SetFontCacheCharNum(DEVNAME.Length);
        DevName = new("Segoe UI", 20, 10);
        DevName.Text = DEVNAME;
        DX.SetFontCacheCharNum(0);

        Children.Add(new SceneSelect());
    }

    public override void Init()
    {
        Fade.Reset();
        Fade.Start();
        IsFadeOut = false;

        base.Init();
    }

    public override void Update()
    {
        Fade.Tick();

        if (Fade.Counter.Value >= Fade.Counter.EndValue / 2.0 && !IsFadeOut)
            Fade.Stop();
        else
            Fade.Start();

        if (Fade.Counter.IsEnd)
            OnFadeOutEnd?.Invoke();

        base.Update();
    }

    public override void Draw()
    {
        DX.GetGraphSize(GraphicsResource.GetResource("TitleLogo"), out int tw, out int th);

        DX.DrawGraph(0, 0, GraphicsResource.GetResource("TitleBack"), DX.TRUE);
        DX.DrawGraph((App.CliantWidth - tw) / 2, 150, GraphicsResource.GetResource("TitleLogo"), DX.TRUE);
        DevName.Draw(15, 15);

        base.Draw();
        DrawFadeOut();
    }

    public override void Finish()
    {
        Fade.Stop();
        base.Finish();
    }

    private void DrawFadeOut()
    {
        if (!Fade.Counter.IsStart)
            return;

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)Fade.Value);
        DX.DrawFillBox(0, 0, App.CliantWidth, App.CliantHeight, 0x000000);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}