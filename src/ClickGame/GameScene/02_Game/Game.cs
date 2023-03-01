using DxLibDLL;
using ClickGame.Utilt;

namespace ClickGame.GameScene.GameScene;

internal class Game : SceneBase
{
    #region Private Member

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

    public Game()
    {
        Children.Add(new Background());
        Children.Add(new ClickPanel());
        Children.Add(new NumberDisplay());
        Children.Add(new Shop());
        Children.Add(new Continue());
    }

    public override void Init()
    {
        Fade.Stop();
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
        base.Draw();
        DrawFade();
    }

    public override void Finish()
    {
        base.Finish();
    }

    private void DrawFade()
    {
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)Fade.Value);
        DX.DrawFillBox(0, 0, App.CliantWidth, App.CliantHeight, 0x000000);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}