using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class Background : SceneBase
{
    private readonly Effect[] effects = new Effect[50];

    public Background()
    {
        for (int i = 0; i < effects.Length; i++)
            effects[i] = new Effect();
    }

    public override void Update()
    {
        foreach (var item in effects)
            item.Update();
    }

    public override void Draw()
    {
        DX.DrawGraph(0, 0, GraphicsResource.GetResource("GameBack"), DX.TRUE);

        foreach (var item in effects)
            item.Draw();
    }
}