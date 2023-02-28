using DxLibDLL;

namespace ClickGame.Utilt;

internal class FontString
{
    #region Public Member

    /// <summary>
    /// 参照しているインデックス
    /// </summary>
    public int ReferenceIndex { get; init; }

    /// <summary>
    /// テキスト
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// フォントの色
    /// </summary>
    public Color FontColor { get; set; }

    #endregion

    /// <summary>
    /// フォントを初期化する
    /// </summary>
    /// <param name="fontName">フォント名</param>
    /// <param name="fontSize">フォントサイズ</param>
    /// <param name="fontWeight">フォントウェイト</param>
    public FontString(string fontName, int fontSize, int fontWeight)
    {
        Text = string.Empty;
        FontColor = Color.White;

        var font = new Font(fontName, fontSize, fontWeight);

        try
        {
            FontManeger.AddFont(font);
            ReferenceIndex = FontManeger.SearchSameFontIndex(font);
        }
        catch
        {
            DX.DeleteFontToHandle(font.FontHandle);
            ReferenceIndex = FontManeger.SearchSameFontIndex(font);
        }

        Tracer.WriteInfo($"ReferenceIndex: {ReferenceIndex}");
    }

    /// <summary>
    /// フォントを描画する
    /// </summary>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    /// <param name="scaleX">X方向のスケール</param>
    /// <param name="scaleY">Y方向のスケール</param>
    public void Draw(float x, float y, float scaleX = 1.0f, float scaleY = 1.0f)
    {
        if(FontColor == Color.Empty || string.IsNullOrWhiteSpace(Text))
            return;

        uint color = DX.GetColor(FontColor.R, FontColor.G, FontColor.B);
        DX.DrawExtendStringFToHandle(x, y, scaleX, scaleY, Text, color, FontManeger.FontList.ToArray()[ReferenceIndex].FontHandle);
    }
}