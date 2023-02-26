using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class Background : SceneBase
{
    public override void Init()
    {
    }

    public override void Update()
    {
    }

    public override void Draw()
    {
        DX.DrawGraph(0, 0, GraphicsResource.GetResource("GameBack"), DX.TRUE);
    }

    public override void Finish()
    {
    }
}