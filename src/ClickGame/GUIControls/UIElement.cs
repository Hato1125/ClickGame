using DxLibDLL;

namespace ClickGame.GUIControls;

internal class UIElement
{
    private int gHandle;
    private int width;
    private int height;

    /// <summary>
    /// ペイントハンドル
    /// </summary>
    protected int paintHandle;

    /// <summary>
    /// UIのX座標
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// UIのY座標
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// UIの横幅
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// UIの高さ
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// 透明度
    /// </summary>
    public byte Opacity { get; set; }

    /// <summary>
    /// ユーザの操作を受け付けるか
    /// </summary>
    public bool IsInput { get; set; }

    /// <summary>
    /// 更新時に呼ばれる
    /// </summary>
    public event Action? OnUpdate = delegate { };

    /// <summary>
    /// 描画時に呼ばれる
    /// </summary>
    public event Action? OnPaint = delegate { };

    /// <summary>
    /// ホバー時に呼ばれる
    /// </summary>
    public event Action? OnHover = delegate { };

    /// <summary>
    /// ホバー時にクリックしている間に呼ばれる
    /// </summary>
    public event Action? OnPushing = delegate { };

    /// <summary>
    /// ホバー時にクリックした瞬間のみ呼び出される
    /// </summary>
    public event Action? OnPushed = delegate { };

    /// <summary>
    /// ホバー時に離した瞬間のみに呼び出される
    /// </summary>
    public event Action? OnSeparate = delegate { };

    /// <summary>
    /// メインのペイント
    /// </summary>
    protected event Action? OnMainPaint = delegate { };

    /// <summary>
    /// UIElementを初期化する
    /// </summary>
    /// <param name="width">横幅</param>
    /// <param name="height">高さ</param>
    public UIElement(int width, int height)
    {
        Opacity = 255;
        Width = width;
        Height = height;
        IsInput = true;
    }

    /// <summary>
    /// UIの更新をする
    /// </summary>
    public void Update()
    {
        CreateDrawArea();
        OnUpdate?.Invoke();

        if (IsHover())
            OnHover?.Invoke();

        if (IsPushing())
            OnPushing?.Invoke();

        if (IsPushed())
            OnPushed?.Invoke();

        if (IsSeparate())
            OnSeparate?.Invoke();
    }

    /// <summary>
    /// UIの描画をする
    /// </summary>
    public void Draw()
    {
        int nowScreen = DX.GetDrawScreen();
        DX.SetDrawScreen(gHandle);
        DX.ClearDrawScreen();
        OnPaintPanel();
        OnMainPaint?.Invoke();
        DX.SetDrawScreen(nowScreen);

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, Opacity);
        DX.DrawGraph(X, Y, gHandle, DX.TRUE);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }

    /// <summary>
    /// ホバーしたかを取得する
    /// </summary>
    public bool IsHover()
        => IsInput
            && Mouse.X >= X
            && Mouse.Y >= Y
            && Mouse.X <= X + Width
            && Mouse.Y <= Y + Height;

    /// <summary>
    /// ホバー時に押されているかを取得する
    /// </summary>
    public bool IsPushing()
        => IsHover() && Mouse.IsPushing(MouseKey.Left);

    /// <summary>
    /// ホバー時に押された瞬間を取得する
    /// </summary>
    public bool IsPushed()
        => IsHover() && Mouse.IsPushed(MouseKey.Left);

    /// <summary>
    /// ホバー時に離された瞬間を取得する
    /// </summary>
    public bool IsSeparate()
        => IsHover() && Mouse.IsSeparate(MouseKey.Left);

    /// <summary>
    /// 描画領域の作成
    /// </summary>
    private void CreateDrawArea()
    {
        if (width == Width && height == Height)
            return;

        Tracer.WriteInfo($"-[{this.GetType()}] Create UIdrawarea.");
        Tracer.WriteInfo($"|UISize: Width:{Width} Height:{Height}");
        DX.DeleteGraph(gHandle);
        DX.DeleteGraph(paintHandle);
        gHandle = DX.MakeScreen(Width, Height, DX.TRUE);
        paintHandle = DX.MakeScreen(Width, Height, DX.TRUE);

        width = Width;
        height = Height;

    }

    private void OnPaintPanel()
    {
        int nowScreen = DX.GetDrawScreen();
        DX.SetDrawScreen(paintHandle);
        DX.ClearDrawScreen();
        OnPaint?.Invoke();
        DX.SetDrawScreen(nowScreen);
    }
}