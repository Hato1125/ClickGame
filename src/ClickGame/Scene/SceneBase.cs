namespace ClickGame;

internal class SceneBase
{
    /// <summary>
    /// 初期化するか
    /// </summary>
    public bool IsInit { get; set; }

    /// <summary>
    /// 子要素のリスト
    /// </summary>
    public readonly List<SceneBase> Children;

    /// <summary>
    /// シーンを初期化する
    /// </summary>
    public SceneBase()
    {
        IsInit = true;
        Children = new();
    }

    /// <summary>
    /// 初期化する
    /// </summary>
    public virtual void Init()
    {
        foreach (var child in Children)
            child.Init();
    }

    /// <summary>
    /// 更新する
    /// </summary>
    public virtual void Update()
    {
        foreach (var child in Children)
            child.Update();
    }

    /// <summary>
    /// 描画する
    /// </summary>
    public virtual void Draw()
    {
        foreach (var child in Children)
            child.Draw();
    }

    /// <summary>
    /// 終了する
    /// </summary>
    public virtual void Finish()
    {
        foreach (var child in Children)
            child.Finish();
    }
}