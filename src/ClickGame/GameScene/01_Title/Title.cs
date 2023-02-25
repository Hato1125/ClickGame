using DxLibDLL;

namespace ClickGame.GameScene.TitleScene;

internal class Title : SceneBase
{
    private double counter;
    public static bool IsFadeOut { get; set; }
    public static event Action? OnFadeOutEnd = delegate { };

    public override void Init()
    {
        GraphicsResource.AddResource("Background", $"{AppContext.BaseDirectory}Asset\\Graphics\\Title\\Background.png");
        GraphicsResource.AddResource("TitleLogo", $"{AppContext.BaseDirectory}Asset\\Graphics\\Title\\TitleLogo.png");
        Children.Add(new SceneSelect());

        base.Init();
    }

    public override void Update()
    {
        TickFadeOut();
        base.Update();
    }

    public override void Draw()
    {
        DX.GetGraphSize(GraphicsResource.GetResource("TitleLogo"), out int tw, out int th);

        DX.DrawGraph(0, 0, GraphicsResource.GetResource("Background"), DX.TRUE);
        DX.DrawGraph((App.CliantWidth - tw) / 2, 150, GraphicsResource.GetResource("TitleLogo"), DX.TRUE);

        base.Draw();
        DrawFadeOut();
    }

    public override void Finish()
    {
        base.Finish();
    }

    private void TickFadeOut()
    {
        if (!IsFadeOut)
            return;

        counter += App.GameTime.TotalSeconds * 100;

        if (counter > 90)
        {
            counter = 90;
            OnFadeOutEnd?.Invoke();
        }
    }

    private void DrawFadeOut()
    {
        if (!IsFadeOut)
            return;

        double opacity = Math.Sin(counter * Math.PI / 180.0) * 255;

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)opacity);
        DX.DrawFillBox(0, 0, App.CliantWidth, App.CliantHeight, 0x000000);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}