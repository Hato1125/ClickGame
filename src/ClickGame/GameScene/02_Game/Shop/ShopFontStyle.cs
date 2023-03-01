namespace ClickGame.GameScene.GameScene;

internal struct ShopFontStyle
{
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
    public int FontThick { get; init; }

    /// <summary>
    /// フォントの色
    /// </summary>
    public Color FontColor { get; init; }

    /// <summary>
    /// フォントのスケール
    /// </summary>
    public float FontScale { get; init; }

    /// <summary>
    /// フォントの位置
    /// </summary>
    public Point Position { get; init; }

    /// <summary>
    /// フォントスタイルを初期化する
    /// </summary>
    /// <param name="name">フォント名</param>
    /// <param name="size">サイズ</param>
    /// <param name="thick">太さ</param>
    /// <param name="color">色</param>
    /// <param name="scale">スケール</param>
    /// <param name="position">位置</param>
    public ShopFontStyle(string name, int size, int thick, float scale, Color color, Point position)
    {
        FontName = name;
        FontSize = size;
        FontThick = thick;
        FontColor = color;
        FontScale = scale;
        Position = position;
    }
}