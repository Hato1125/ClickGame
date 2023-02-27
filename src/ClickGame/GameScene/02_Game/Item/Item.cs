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
    /// 値段
    /// </summary>
    public long Price { get; init; }

    /// <summary>
    /// 追加する数
    /// </summary>
    public long AddNumber { get; init; }

    /// <summary>
    /// アイテムを初期化する
    /// </summary>
    /// <param name="addInterValMs">追加する間隔</param>
    /// <param name="price">値段</param>
    /// <param name="addNum">追加する数</param>
    public Item(double addInterValMs, long price, long addNum)
    {
        AddIntervalMs = AddIntervalMs;
        Price = price;
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