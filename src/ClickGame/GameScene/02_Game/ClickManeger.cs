namespace ClickGame.GameScene.GameScene;

internal static class ClickManeger
{
    /// <summary>
    /// 一回のクリックで何個増えるか
    /// </summary>
    public static long OneClickNum { get; set; } = 1;

    /// <summary>
    /// 現在のクリック回数
    /// </summary>
    public static long ClickNum { get; private set; } = 0;

    /// <summary>
    /// クリック回数を追加する
    /// </summary>
    /// <param name="num">追加する数</param>
    public static void AddClick(long num)
        => ClickNum += num;

    /// <summary>
    /// クリック回数を引く
    /// </summary>
    /// <param name="num">引く数</param>
    public static void PullClick(long num)
        => ClickNum -= num;
}