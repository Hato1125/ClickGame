using DxLibDLL;

namespace ClickGame.GameScene.GameScene;

internal class Effect
{
    private const int MIN_SPEED = 100;
    private const int MAX_SPEED = 400;
    private int effectHeight;
    private int effectHandle;
    private float posX;
    private float posY;
    private float scale;
    private int effectType;
    private int scrollSpeed;

    /// <summary>
    /// 初期化をする
    /// </summary>
    public Effect()
        => Init();

    /// <summary>
    /// エフェクトの初期化をする
    /// </summary>
    private void Init()
    {
        effectType = App.Random.Next(1, 4);
        scrollSpeed = App.Random.Next(MIN_SPEED, MAX_SPEED + 1);
        scale = App.Random.Next(3, 10) / 10.0f;
        effectHandle = GraphicsResource.GetResource($"Effect_{effectType}");
        DX.GetGraphSize(effectHandle, out int w, out int h);
        posX = App.Random.Next(-w, App.CliantWidth + w + 1);
        effectHeight = h;
        posY = -h;
    }

    /// <summary>
    /// 位置の更新をする
    /// </summary>
    public void Update()
    {
        if (posY < App.CliantHeight + effectHeight)
            posY += (float)(App.GameTime.TotalSeconds * scrollSpeed);
        else
            Init();
    }

    /// <summary>
    /// 描画をする
    /// </summary>
    public void Draw()
    {
        // ラジアンを求める
        double angle = posY * (180.0 / (App.CliantHeight + effectHeight));
        double rad = (angle * Math.PI) / 180.0;
        double depth = (scale * 255);

        DX.SetDrawMode(DX.DX_DRAWMODE_BILINEAR);
        DX.SetDrawBright((int)depth, (int)depth, (int)depth);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ADD, (int)depth);
        DX.DrawRotaGraphF(posX, posY, scale, Math.Sin(rad), effectHandle, DX.TRUE);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
        DX.SetDrawBright(255, 255, 255);
        DX.SetDrawMode(DX.DX_DRAWMODE_NEAREST);
    }
}