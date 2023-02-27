using ClickGame.GUIControls;
using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class ShopItem
{
    private readonly UIButton button;
    private readonly List<Item> items;
    private Size iconSize;

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
    public long Price { get; init; }

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

    }
}