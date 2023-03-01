using System.Diagnostics.CodeAnalysis;
using DxLibDLL;

namespace ClickGame.Utilt;

internal struct Font
{
    #region Public Member

    /// <summary>
    /// フォントの名前
    /// </summary>
    public string FontName { get; init; }

    /// <summary>
    /// フォントのサイズ
    /// </summary>
    public int FontSize { get; init; }

    /// <summary>
    /// フォントの太さ
    /// </summary>
    public int FontWeight { get; init; }

    /// <summary>
    /// フォントのハンドル
    /// </summary>
    public int FontHandle { get; private set; }

    #endregion

    /// <summary>
    /// フォントを初期化する
    /// </summary>
    /// <param name="fontName">フォント名</param>
    /// <param name="fontSize">フォントサイズ</param>
    /// <param name="fontWeight">フォントウェイト</param>
    public Font(string fontName, int fontSize, int fontWeight)
    {
        FontName = fontName;
        FontSize = fontSize;
        FontWeight = fontWeight;
    }

    /// <summary>
    /// フォントハンドルを作成する
    /// </summary>
    public void CreateFontHandle()
    {
        Tracer.WriteInfo("Create fonthandle.");
        FontHandle = DX.CreateFontToHandle(FontName, FontSize, FontWeight, DX.DX_FONTTYPE_ANTIALIASING_8X8);
    }


    public static bool operator ==(Font a, Font b)
    {
        if (a.FontName == b.FontName
            && a.FontSize == b.FontSize
            && a.FontWeight == b.FontWeight)
            return true;
        else
            return false;
    }

    public static bool operator !=(Font a, Font b)
    {
        if (a.FontName != b.FontName
            || a.FontSize != b.FontSize
            || a.FontWeight != b.FontWeight)
            return true;
        else
            return false;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return base.Equals(obj);
    }
}