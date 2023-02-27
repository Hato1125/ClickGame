using ClickGame.GUIControls;
using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class ClickPanel : SceneBase
{
    private const int SPEED = 1000;
    private readonly Point POSITION = new(100, 200);

    private UIElement colision;
    private Size panelSize;
    private double counter;
    private bool isAnimation;
    private bool isReverse;

    public ClickPanel()
    {
        DX.GetGraphSize(GraphicsResource.GetResource("ClickPanel"), out int w, out int h);
        panelSize = new Size(w, h);
        colision = new(w, h);
        colision.X = POSITION.X;
        colision.Y = POSITION.Y;
    }

    public override void Init()
    {
    }

    public override void Update()
    {

        if(isAnimation)
        {
            if (colision.IsPushed())
                isReverse = !isReverse;
        }

        colision.Update();
        if (colision.IsPushed())
        {
            Number.ClickNumber++;
            isAnimation = true;
        }

        if(isAnimation)
        {
            if (isReverse)
                counter -= App.GameTime.TotalSeconds * SPEED;
            else
                counter += App.GameTime.TotalSeconds * SPEED;

            if (isReverse)
            {
                if (counter < 0)
                {
                    counter = 0;
                    isAnimation = false;
                    isReverse = false;
                }
            }
            else
            {
                if (counter > 180)
                {
                    counter = 0;
                    isAnimation = false;
                    isReverse = false;
                }
            }
        }
    }

    public override void Draw()
    {
        // ラジアン
        double rad = (counter * Math.PI) / 180.0;
        double scale = 1.0 - Math.Sin(rad) * 0.1;

        DX.SetDrawMode(DX.DX_DRAWMODE_BILINEAR);
        DX.DrawRotaGraph2F(
            POSITION.X + panelSize.Width / 2,
            POSITION.Y + panelSize.Height / 2,
            panelSize.Width / 2,
            panelSize.Height / 2,
            scale,
            0.0,
            GraphicsResource.GetResource("ClickPanel"), DX.TRUE
        );
        DX.SetDrawMode(DX.DX_DRAWMODE_NEAREST);
    }

    public override void Finish()
    {
    }
}