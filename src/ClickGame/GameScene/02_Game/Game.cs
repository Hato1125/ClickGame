using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class Game : SceneBase
{
    private static double counter;
    public static bool IsFadeIn { get; set; }
    public static bool IsFadeOutEnd
    {
        get
        {
            if (!IsFadeIn && counter <= 0)
                return true;
            else
                return false;
        }
    }

    public override void Init()
    {
        Children.Add(new Background());
        Children.Add(new ClickPanel());
        Children.Add(new NumberDisplay());
        Children.Add(new Shop());
        Children.Add(new Continue());
        IsFadeIn = true;

        base.Init();
    }

    public override void Update()
    {
        TickFadeIn();
        TickFadeOut();

        base.Update();
    }

    public override void Draw()
    {
        base.Draw();
        DrawFade();
    }

    public override void Finish()
    {
        base.Finish();
    }

    private void TickFadeIn()
    {
        if (!IsFadeIn || counter >= 90)
            return;

        counter += App.GameTime.TotalSeconds * 100;
        if (counter >= 90)
            counter = 90;
    }

    private void TickFadeOut()
    {
        if (IsFadeIn || counter <= 0)
            return;

        counter -= App.GameTime.TotalSeconds * 100;
        if (counter <= 0)
            counter = 0;
    }

    private void DrawFade()
    {
        double opacity = 255 - Math.Sin(counter * Math.PI / 180.0) * 255;

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)opacity);
        DX.DrawFillBox(0, 0, App.CliantWidth, App.CliantHeight, 0x000000);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}