using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class Game : SceneBase
{
    private double counter;
    private bool isFadeIn;

    public override void Init()
    {
        Children.Add(new Background());
        Children.Add(new ClickPanel());
        Children.Add(new NumberDisplay());
        Children.Add(new Shop());
        isFadeIn = true;

        base.Init();
    }

    public override void Update()
    {
        TickFadeIn();

        base.Update();
    }

    public override void Draw()
    {
        base.Draw();
        DrawFadeIn();
    }

    public override void Finish()
    {
        base.Finish();
    }

    private void TickFadeIn()
    {
        if (!isFadeIn)
            return;

        counter += App.GameTime.TotalSeconds * 100;

        if (counter > 90)
        {
            counter = 90;
            isFadeIn = false;
        }
    }

    private void DrawFadeIn()
    {
        if (!isFadeIn)
            return;

        double opacity = 255 - Math.Sin(counter * Math.PI / 180.0) * 255;

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)opacity);
        DX.DrawFillBox(0, 0, App.CliantWidth, App.CliantHeight, 0x000000);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}