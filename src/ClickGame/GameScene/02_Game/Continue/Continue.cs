using ClickGame.GUIControls;

namespace ClickGame.GameScene.GameScene;

internal class Continue : SceneBase
{
    private const int margin = 15;
    private readonly UIButton continueButton;
    private readonly ContinueScreen continueScreen;

    public Continue()
    {
        continueButton = new(GraphicsResource.GetResource("ContinueButton"));
        continueButton.X = App.CliantWidth - (continueButton.Width + margin);
        continueButton.Y = margin;

        continueScreen = new();
        Children.Add(continueScreen);
        continueButton.OnSeparate += delegate
        {
            continueScreen.IsOpen = !continueScreen.IsOpen;
            continueScreen.ActiveButtons();
        };
    }

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        continueButton.Update();

        base.Update();
    }

    public override void Draw()
    {
        continueButton.Draw();

        base.Draw();
    }

    public override void Finish()
    {
        base.Finish();
    }
}