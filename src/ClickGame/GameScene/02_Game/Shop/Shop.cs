using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class Shop : SceneBase
{
    private readonly Dictionary<string, ShopItem> shopItems = new()
    {
        { "Clicker", new ShopItem("Clicker", GraphicsResource.GetResource("ClickerIcon"), 10, 10, 1) },
        { "TwinClicker", new ShopItem("TwinClicker", GraphicsResource.GetResource("TwinClickerIcon"), 30, 10, 3) },
    };

    public Shop()
    {
        DX.GetGraphSize(GraphicsResource.GetResource("ShopItemPanel"), out int w, out int h);

        var keys = shopItems.Keys.ToArray();
        for (int i = 0; i < shopItems.Count; i++)
            shopItems[keys[i]].Position = new Point(App.CliantWidth - (w + 20), 300 + (h + 10) * i);
    }

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        foreach (var item in shopItems)
            item.Value.Update();

        base.Update();
    }

    public override void Draw()
    {
        foreach (var item in shopItems)
            item.Value.Draw();

        base.Draw();
    }

    public override void Finish()
    {
        base.Finish();
    }
}