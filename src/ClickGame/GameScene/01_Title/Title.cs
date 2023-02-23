using ClickGame.GameScene.TitleScene;

namespace ClickGame.GameScene;

internal class Title : SceneBase
{
    public override void Init()
    {
        Children.Add(new SceneSelect());

        base.Init();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Draw()
    {
        base.Draw();
    }

    public override void Finish()
    {
        base.Finish();
    }
}