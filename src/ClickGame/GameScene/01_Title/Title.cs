using DxLibDLL;

using ClickGame.GameScene.TitleScene;

namespace ClickGame.GameScene;

internal class Title : SceneBase
{
    public override void Init()
    {
        GraphicsResource.AddResource("Background", $"{AppContext.BaseDirectory}Asset\\Graphics\\Title\\Background.png");
        Children.Add(new SceneSelect());

        base.Init();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Draw()
    {
        DX.DrawGraph(0, 0, GraphicsResource.GetResource("Background"), DX.TRUE);

        base.Draw();
    }

    public override void Finish()
    {
        base.Finish();
    }
}