using ClickGame.Utilt;
using ClickGame.GUIControls;
using DxLibDLL;

namespace ClickGame.GameScene.SettingScene;

internal class Setting : SceneBase
{
    private readonly Fade Fade = new(0.001f, 3.5);
    private readonly FontString Font;
    private readonly UIButton backButton;
    public static bool IsFadeOut { get; set; }

    public Setting()
    {
        Font = new("Segoe UI", 25, 10);
        Font.Text = "Comming Soon...";

        backButton = new(GraphicsResource.GetResource("BackButton"));
        backButton.SoundHandle = SoundResource.GetResource("PushButton");
        backButton.OnSeparate += Back;
        backButton.X = 15;
        backButton.Y = 15;
    }

    public override void Init()
    {
        Fade.Reset();
        Fade.Start();
        IsFadeOut = false;

        base.Init();
    }

    public override void Update()
    {
        Fade.Tick();

        if (Fade.Counter.Value >= Fade.Counter.EndValue / 2.0 && !IsFadeOut)
            Fade.Stop();
        else
            Fade.Start();

        backButton.Update();

        if (Fade.Counter.IsEnd)
            SceneManeger.SetScene("Title");


        base.Update();
    }

    public override void Draw()
    {
        var fontHandle = FontManeger.FontList.ToArray()[Font.ReferenceIndex].FontHandle;
        int width = DX.GetDrawStringWidthToHandle(Font.Text, Font.Text.Length, fontHandle);
        int height = DX.GetFontSizeToHandle(fontHandle);

        Font.Draw(
            (App.CliantWidth - width) / 2,
            (App.CliantHeight - height) / 2
        );

        backButton.Draw();

        base.Draw();
        DrawFadeOut();
    }

    public override void Finish()
    {
        Fade.Stop();
        base.Finish();
    }

    private void Back()
    {
        IsFadeOut = true;
    }

    private void DrawFadeOut()
    {
        if (!Fade.Counter.IsStart)
            return;

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, (int)Fade.Value);
        DX.DrawFillBox(0, 0, App.CliantWidth, App.CliantHeight, 0x000000);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}