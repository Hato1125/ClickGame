using DxLibDLL;
using ClickGame.Utilt;

namespace ClickGame.GameScene.GameScene;

internal class NumberDisplay : SceneBase
{
    #region Private Member

    private readonly FontString Font;

    #endregion

    public NumberDisplay()
    {
        DX.SetFontCacheCharNum(long.MaxValue.ToString().Length);
        Font = new("Segoe UI", 70, 10);
        DX.SetFontCacheCharNum(0);
    }

    public override void Draw()
    {
        var clickNumStr = ClickManeger.ClickNum.ToString();
        var fontHandle = FontManeger.FontList.ToArray()[Font.ReferenceIndex].FontHandle;
        int width = DX.GetDrawStringWidthToHandle(clickNumStr, clickNumStr.Length, fontHandle);

        Font.Text = clickNumStr;

        DX.SetDrawMode(DX.DX_DRAWMODE_BILINEAR);
        Font.Draw((App.CliantWidth - width) / 2.0f, 50);
        DX.SetDrawMode(DX.DX_DRAWMODE_NEAREST);

        base.Draw();
    }
}