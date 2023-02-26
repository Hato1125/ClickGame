using DxLibDLL;

namespace ClickGame.GameScene.TitleScene;

internal class Title : SceneBase
{
    private const string DEVNAME = "Developer: Hato1125";
    private const uint DEVCOLOR = 0xffffff;
    private int devNameHandle;
    private int devNamePosX;
    private int devNamePosY;
    private double counter;
    public static bool IsFadeOut { get; set; }
    public static event Action? OnFadeOutEnd = delegate { };

    public Title()
    {
        GraphicsResource.AddResource("Background", $"{AppContext.BaseDirectory}Asset\\Graphics\\Title\\Background.png");
        GraphicsResource.AddResource("TitleLogo", $"{AppContext.BaseDirectory}Asset\\Graphics\\Title\\TitleLogo.png");
    }

    public override void Init()
    {
        Children.Add(new SceneSelect());
        DX.SetFontCacheCharNum(DEVNAME.Length);
        devNameHandle = DX.CreateFontToHandle("Segoe UI", 20, 10, DX.DX_FONTTYPE_ANTIALIASING_16X16);
        DX.SetFontCacheCharNum(0);
        int h = DX.GetFontSizeToHandle(devNameHandle);
        devNamePosX = 15;
        devNamePosY = App.CliantHeight - (h + 15);

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
        DX.DrawStringToHandle(devNamePosX, devNamePosY, DEVNAME, DEVCOLOR, devNameHandle);

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