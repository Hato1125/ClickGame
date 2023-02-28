using DxLibDLL;

namespace ClickGame.Utilt;

internal static class FontManeger
{
    private static readonly List<Font> fonts = new();

    /// <summary>
    /// フォントリスト
    /// </summary>
    public static IEnumerable<Font> FontList
    {
        get
        {
            foreach (var font in fonts)
                yield return font;
        }
    }

    /// <summary>
    /// フォントを登録する
    /// </summary>
    /// <param name="font">フォント</param>
    public static void AddFont(Font font)
    {
        // 同じFontがすでに登録されているかを確認する
        foreach (var item in fonts)
        {
            if (font == item)
            {
                Tracer.WriteWarning("The addition is canceled because the same font is already registered.");
                throw new Exception("The addition is canceled because the same font is already registered.");
            }
        }

        Tracer.WriteInfo("Add font.");
        fonts.Add(font);
    }

    /// <summary>
    /// 同じフォントのインデックスを取得する
    /// </summary>
    /// <param name="font">フォント</param>
    public static int SearchSameFontIndex(Font font)
    {
        for(int i = 0; i < fonts.Count; i++)
        {
            if(fonts[i] == font)
                return i;
        }

        return -1;
    }

    /// <summary>
    /// フォントハンドルを削除する
    /// </summary>
    /// <param name="index">インデックス</param>
    public static void RemoveHandle(int index)
    {
        if (fonts[index].FontHandle != -1)
            DX.DeleteFontToHandle(fonts[index].FontHandle);

        try
        {
            fonts.Remove(fonts[index]);
        }
        catch
        {
            Tracer.WriteError("Invalid index passed.");
            throw new IndexOutOfRangeException("Invalid index passed.");
        }
    }

    /// <summary>
    /// フォントハンドルを削除する
    /// </summary>
    /// <param name="font">フォント</param>
    public static void RemoveHandle(Font font)
    {
        if (font.FontHandle != -1)
            DX.DeleteFontToHandle(font.FontHandle);

        try
        {
            fonts.Remove(font);
        }
        catch
        {
            Tracer.WriteError("That font is not registered.");
            throw new KeyNotFoundException("That font is not registered.");
        }
    }

    /// <summary>
    /// すべてのフォントハンドルを削除する
    /// </summary>
    public static void RemoveAllHandle()
    {
        foreach (var font in fonts)
            DX.DeleteFontToHandle(font.FontHandle);

        fonts.Clear();
    }
}