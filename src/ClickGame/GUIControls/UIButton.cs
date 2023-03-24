using System.Diagnostics;
using DxLibDLL;

namespace ClickGame.GUIControls;

internal class UIButton : UIElement
{
    private readonly Stopwatch stopwatch = new();
    private TimeSpan time;
    private int imgHandle;
    private double counter;
    private double scale;

    private int sound;
    /// <summary>
    /// サウンドハンドル
    /// </summary>
    public int SoundHandle
    {
        get => sound;
        set
        {
            OnSeparate += new Action(() => DX.PlaySoundMem(value, DX.DX_PLAYTYPE_BACK));
            sound = value;
        }
    }

    /// <summary>
    /// Buttonの初期化をする
    /// </summary>
    /// <param name="gHandle">グラフィックハンドル</param>
    public UIButton(int gHandle) : base(0, 0)
    {
        imgHandle = gHandle;
        DX.GetGraphSize(gHandle, out int w, out int h);
        Width = w;
        Height = h;

        OnMainPaint += Paint;
        OnUpdate += Tick;
    }

    private void Tick()
    {
        // Deltaタイムのセット
        time = stopwatch.Elapsed;
        stopwatch.Restart();

        if (IsPushing())
        {
            counter += time.TotalSeconds * 1450;

            if (counter > 90)
                counter = 90;
        }
        else
        {
            counter -= time.TotalSeconds * 800;

            if (counter < 0)
                counter = 0;
        }

        scale = 1.0f - Math.Sin(counter * Math.PI / 180.0) * 0.1;
    }

    private void Paint()
    {
        float rX = Width / 2.0f;
        float rY = Height / 2.0f;

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_PMA_ALPHA, 255);
        DX.SetDrawMode(DX.DX_DRAWMODE_ANISOTROPIC);
        DX.DrawRotaGraph2F(
            Width / 2.0f,
            Height / 2.0f,
            rX, rY,
            (float)scale,
            0.0f,
            imgHandle,
            DX.TRUE
        );

        DX.DrawRotaGraph2F(
            Width / 2.0f,
            Height / 2.0f,
            rX, rY,
            (float)scale,
            0.0f,
            paintHandle,
            DX.TRUE
        );
        DX.SetDrawMode(DX.DX_DRAWMODE_NEAREST);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }
}