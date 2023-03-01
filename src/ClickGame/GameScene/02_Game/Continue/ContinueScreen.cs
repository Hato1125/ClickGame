using DxLibDLL;
using ClickGame.GUIControls;

namespace ClickGame.GameScene.GameScene;

internal class ContinueScreen : SceneBase
{
    private const double FADESPEED = 400;
    private const int BNT_INTERVAL = 20;
    private UIButton[] buttons = new UIButton[3];
    private double fadeCounter;
    private double fade;
    private int gotoIndex;

    public bool IsOpen { get; set; }

    public ContinueScreen()
    {
        int height = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = new(GraphicsResource.GetResource($"ContinueButton_{i + 1}"));
            buttons[i].SoundHandle = SoundResource.GetResource("PushButton");
            buttons[i].IsInput = false;
            height += buttons[i].Height + BNT_INTERVAL;
        }

        //位置決め
        int center_y = (App.CliantHeight - height) / 2;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].X = (App.CliantWidth - buttons[i].Width) / 2;
            buttons[i].Y = (buttons[i].Height + BNT_INTERVAL) * i + center_y;
        }

        Game.OnFadeOutEnd += GotoScene;
    }

    public override void Init()
    {
        fadeCounter = 0;
    }

    public override void Update()
    {
        FadeIn();
        FadeOut();
        double rad = (fadeCounter * Math.PI) / 180.0;
        fade = Math.Sin(rad) * 255;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Update();

            if (buttons[i].IsSeparate())
            {
                gotoIndex = i;

                if (i == 2)
                    IsOpen = false;
                else
                    Game.IsFadeOut = true;

                InactiveButtons();
            }
        }
    }

    public override void Draw()
    {
        DrawPanel();
        DrawButtons();
    }

    private void FadeIn()
    {
        if (!IsOpen || fadeCounter >= 90)
            return;

        fadeCounter += FADESPEED * App.GameTime.TotalSeconds;
        if (fadeCounter >= 90)
            fadeCounter = 90;
    }

    private void FadeOut()
    {
        if (IsOpen || fadeCounter <= 0)
            return;

        fadeCounter -= FADESPEED * App.GameTime.TotalSeconds;
        if (fadeCounter <= 0)
            fadeCounter = 0;
    }

    private void DrawPanel()
    {
        var panel = GraphicsResource.GetResource("ContinuePanel");
        DX.GetGraphSize(panel, out int w, out int h);

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)fade - 55);
        DX.DrawFillBox(0, 0, App.CliantWidth, App.CliantHeight, 0x000000);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)fade);
        DX.DrawGraph((App.CliantWidth - w) / 2, (App.CliantHeight - h) / 2, panel, DX.TRUE);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }

    private void DrawButtons()
    {
        foreach (var item in buttons)
        {
            item.Opacity = (byte)fade;
            item.Draw();
        }
    }

    private void GotoScene()
    {
        IsOpen = false;
        switch (gotoIndex)
        {
            case 0:
                SceneManeger.SetScene("Title");
                break;

            case 1:
                SceneManeger.SetScene("Setting");
                break;
        }
    }

    public void ActiveButtons()
    {
        foreach (var item in buttons)
            item.IsInput = true;
    }

    private void InactiveButtons()
    {
        foreach (var item in buttons)
            item.IsInput = false;
    }
}