using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class Number : SceneBase
{
    private const uint COLOR = 0xffffff;
    private int fontHandle;

    public static long ClickNumber { get; set; }

    public override void Init()
    {
        DX.SetFontCacheCharNum(long.MaxValue.ToString().Length);
        fontHandle = DX.CreateFontToHandle("Segoe UI", 70, 10, DX.DX_FONTTYPE_ANTIALIASING_16X16);
        DX.SetFontCacheCharNum(0);

        base.Init();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Draw()
    {
        int width = DX.GetDrawStringWidthToHandle(ClickNumber.ToString(), ClickNumber.ToString().Length, fontHandle);
        DX.SetDrawMode(DX.DX_DRAWMODE_BILINEAR);
        DX.DrawStringFToHandle((App.CliantWidth - width) / 2.0f, 50, ClickNumber.ToString(), COLOR, fontHandle);
        DX.SetDrawMode(DX.DX_DRAWMODE_NEAREST);

        base.Draw();
    }

    public override void Finish()
    {
        if (fontHandle != -1)
            DX.DeleteFontToHandle(fontHandle);

        base.Finish();
    }
}