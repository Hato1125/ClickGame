using DxLibDLL;
using ClickGame.Utilt;

namespace ClickGame.GameScene.TitleScene;

internal class Title : SceneBase
{
    private const string DEVNAME = "Developer: Hato1125";
    private const uint DEVCOLOR = 0xffffff;
    private int devNameHandle;
    private int devNamePosX;
    private int devNamePosY;
    public static readonly FadeOut FadeOut = new(0.001f, 2);
    public static event Action? OnFadeOutEnd = delegate { };

    public override void Init()
    {
        Children.Add(new SceneSelect());
        DX.SetFontCacheCharNum(DEVNAME.Length);
        devNameHandle = DX.CreateFontToHandle("Segoe UI", 20, 10, DX.DX_FONTTYPE_ANTIALIASING_16X16);
        DX.SetFontCacheCharNum(0);
        int h = DX.GetFontSizeToHandle(devNameHandle);
        devNamePosX = 15;
        devNamePosY = App.CliantHeight - (h + 15);
        FadeOut.Reset();
        FadeOut.Stop();

        base.Init();
    }

    public override void Update()
    {
        FadeOut.Tick();

        if(FadeOut.Counter.IsEnd)
            OnFadeOutEnd?.Invoke();

        base.Update();
    }

    public override void Draw()
    {
        DX.GetGraphSize(GraphicsResource.GetResource("TitleLogo"), out int tw, out int th);

        DX.DrawGraph(0, 0, GraphicsResource.GetResource("TitleBack"), DX.TRUE);
        DX.DrawGraph((App.CliantWidth - tw) / 2, 150, GraphicsResource.GetResource("TitleLogo"), DX.TRUE);
        DX.DrawStringToHandle(devNamePosX, devNamePosY, DEVNAME, DEVCOLOR, devNameHandle);

        base.Draw();
        DrawFadeOut();
    }

    public override void Finish()
    {
        base.Finish();
    }

    private void DrawFadeOut()
    {
        if (!FadeOut.Counter.IsStart)
            return;

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)FadeOut.Value);
        DX.DrawFillBox(0, 0, App.CliantWidth, App.CliantHeight, 0x000000);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}