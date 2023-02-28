using ClickGame.GUIControls;
using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class ShopItem
{
    private readonly ShopFontStyle NAME_STYLE = new(
        "Segoe UI",
        25,
        10,
        1.0f,
        DX.GetColor(255, 255, 255),
        new Point(130, 23)
    );

    private readonly ShopFontStyle PRICE_STYLE = new(
        "Segoe UI",
        25,
        10,
        1.0f,
        DX.GetColor(255, 233, 48),
        new Point(130, 60)
    );

    private readonly ShopFontStyle NUM_STYLE = new(
        "Segoe UI",
        25,
        10,
        0.8f,
        DX.GetColor(255, 255, 255),
        new Point(250, 64)
    );

    private readonly UIButton button;
    private readonly List<Item> items;
    private readonly Size iconSize;
    private readonly int fontHandle;

    /// <summary>
    /// アイテムボタンの位置
    /// </summary>
    public Point Position { get; set; }

    /// <summary>
    /// アイテムの名前
    /// </summary>
    public string ShopItemName { get; init; }

    /// <summary>
    /// アイテムのアイコンのグラフィックハンドル
    /// </summary>
    public int IconHandle { get; init; }

    /// <summary>
    /// アイテムの値段
    /// </summary>
    public long Price { get; set; }

    /// <summary>
    /// アイテムの追加間隔
    /// </summary>
    public long AddIntervalMs { get; init; }

    /// <summary>
    /// アイテムが何個追加するか
    /// </summary>
    /// <value></value>
    public long AddNumber { get; init; }

    /// <summary>
    /// アイテムを初期化する
    /// </summary>
    /// <param name="name">名前</param>
    /// <param name="iconHandle">アイコンハンドル</param>
    /// <param name="price">値段</param>
    /// <param name="addIntervalMs">更新間隔</param>
    /// <param name="addNum">追加数</param>
    public ShopItem(string name, int iconHandle, long price, long addIntervalMs, long addNum)
    {
        ShopItemName = name;
        IconHandle = iconHandle;
        Price = price;
        AddIntervalMs = addIntervalMs;
        AddNumber = addNum;

        items = new();
        button = new(GraphicsResource.GetResource("ShopItemPanel"));
        button.OnSeparate += BuyItem;
        button.OnPaint += DrawIcon;
        button.OnPaint += DrawName;
        button.OnPaint += DrawPrice;
        button.OnPaint += DrawItemNum;

        fontHandle = DX.CreateFontToHandle(
            NAME_STYLE.FontName,
            NAME_STYLE.FontSize,
            NAME_STYLE.FontThick,
            DX.DX_FONTTYPE_ANTIALIASING_16X16
        );
        DX.GetGraphSize(iconHandle, out int w, out int h);
        iconSize = new(w, h);
    }

    /// <summary>
    /// 更新する
    /// </summary>
    public void Update()
    {
        button.X = Position.X;
        button.Y = Position.Y;
        button.Update();

        UpdateItem();
    }

    /// <summary>
    /// 描画する
    /// </summary>
    public void Draw()
    {
        button.Draw();
    }

    private void BuyItem()
    {
        if (ClickManeger.ClickNum < Price)
        {
            Tracer.WriteWarning($"Not enough clicks to buy {ShopItemName}.");
            return;
        }

        Tracer.WriteInfo($"Add {ShopItemName}.");
        ClickManeger.PullClick(Price);
        items.Add(new Item(AddIntervalMs, AddNumber));
        Price = (int)(Price * 1.5f);
    }

    private void UpdateItem()
    {
        foreach (var item in items)
            item.Tick();
    }

    private void DrawIcon()
    {
        int center_y = (button.Height - iconSize.Height) / 2;
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_PMA_ALPHA, 255);
        DX.DrawGraph(center_y, center_y, IconHandle, DX.TRUE);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }

    private void DrawName()
    {
        var priceStr = $"Name: {ShopItemName}";
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_PMA_ALPHA, 255);
        DX.DrawStringFToHandle(
            NAME_STYLE.Position.X,
            NAME_STYLE.Position.Y,
            priceStr,
            NAME_STYLE.FontColor,
            fontHandle
        );
    }

    private void DrawPrice()
    {
        var priceStr = $"Price: {Price.ToString()}";
        DX.DrawStringFToHandle(
            PRICE_STYLE.Position.X,
            PRICE_STYLE.Position.Y,
            priceStr,
            PRICE_STYLE.FontColor,
            fontHandle
        );
    }

    private void DrawItemNum()
    {
        var priceStr = $"Num: {items.Count}";

        DX.SetDrawMode(DX.DX_DRAWMODE_ANISOTROPIC);
        DX.DrawExtendStringToHandle(
            NUM_STYLE.Position.X,
            NUM_STYLE.Position.Y,
            NUM_STYLE.FontScale,
            NUM_STYLE.FontScale,
            priceStr,
            NUM_STYLE.FontColor,
            fontHandle
        );
        DX.SetDrawMode(DX.DX_DRAWMODE_NEAREST);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}