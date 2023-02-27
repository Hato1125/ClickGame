using System.Diagnostics;

namespace ClickGame.GameScene.GameScene;

internal class Item
{
    private readonly Stopwatch stopwatch = new();

    /// <summary>
    /// 追加する間隔
    /// </summary>
    public double AddIntervalMs { get; init; }

    /// <summary>
    /// 追加する数
    /// </summary>
    public long AddNumber { get; init; }

    /// <summary>
    /// アイテムを初期化する
    /// </summary>
    /// <param name="addInterValMs">追加する間隔</param>
    /// <param name="addNum">追加する数</param>
    public Item(double addIntervalMs, long addNum)
    {
        AddIntervalMs = addIntervalMs;
        AddNumber = addNum;
    }

    /// <summary>
    /// 計測する
    /// </summary>
    public void Tick()
    {
        if (!stopwatch.IsRunning)
            stopwatch.Start();

        if(stopwatch.Elapsed.TotalSeconds > AddIntervalMs)
        {
            ClickManeger.AddClick(AddNumber);
            stopwatch.Restart();
        }
    }
}