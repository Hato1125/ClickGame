using DxLibDLL;

namespace ClickGame.GameScene.TitleScene;

internal class SceneSelect : SceneBase
{
    private readonly int[] buttonHandle;
    private readonly Point[] buttonPosition;

    public SceneSelect()
    {
        GraphicsResource.AddResource("StartButton", $"{AppContext.BaseDirectory}Asset\\Graphics\\Title\\StartButton.png");
        GraphicsResource.AddResource("SettingButton", $"{AppContext.BaseDirectory}Asset\\Graphics\\Title\\SettingButton.png");
        GraphicsResource.AddResource("ExitButton", $"{AppContext.BaseDirectory}Asset\\Graphics\\Title\\ExitButton.png");

        buttonHandle = new int[]
        {
            GraphicsResource.GetResource("StartButton"),
            GraphicsResource.GetResource("SettingButton"),
            GraphicsResource.GetResource("ExitButton"),
        };

        buttonPosition = new Point[buttonHandle.Length];
        for (int i = 0; i < buttonHandle.Length; i++)
        {
            DX.GetGraphSize(buttonHandle[i], out int w, out int h);
            int center_x = (App.CliantWidth - w) / 2;
            int center_y = (App.CliantHeight - h) / 2;
            int ypos = i * (h + 10);

            buttonPosition[i] = new(center_x, center_y + ypos);
        }
    }

    public override void Init()
    {
    }

    public override void Update()
    {
    }

    public override void Draw()
    {
        for(int i = 0; i < buttonHandle.Length; i++)
            DX.DrawGraph(buttonPosition[i].X, buttonPosition[i].Y, buttonHandle[i], DX.TRUE);
    }

    public override void Finish()
    {
    }
}