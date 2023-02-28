namespace ClickGame.Utilt;

internal class Fade : IAnimation
{
    #region Public Member

    /// <summary>
    /// カウンター
    /// </summary>
    public Counter Counter { get; }

    /// <summary>
    /// 現在の値
    /// </summary>
    public double Value { get; set; }

    #endregion

    /// <summary>
    ///  Fadeを初期化する
    /// </summary>
    /// <param name="interval">間隔</param>
    /// <param name="increaseNum">増加値</param>
    /// <param name="isLoop">ループするか</param>
    public Fade(double interval, double increaseNum = 1, bool isLoop = false)
    {
        Counter = new(0, 180, interval, increaseNum, isLoop);
        Value = 0;
    }

    /// <summary>
    /// アニメーションを進行する
    /// </summary>
    public void Tick()
    {
        Counter.Tick();

        var rad = 0.0;
        if (Counter.Value <= Counter.EndValue / 2)
            rad = Counter.Value;
        else
            rad = Counter.EndValue - Counter.Value;

        Value = Math.Sin(rad) * 255;
    }

    /// <summary>
    /// アニメーションを開始する
    /// </summary>
    public void Start()
        => Counter.Start();

    /// <summary>
    /// アニメーションを停止させる
    /// </summary>
    public void Stop()
        => Counter.Stop();

    /// <summary>
    /// アニメーションをリセットする
    /// </summary>
    public void Reset()
    {
        Counter.Reset();
        Value = 0;
    }
}