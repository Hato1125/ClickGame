namespace ClickGame.Utilt;

internal class FadeOut : IAnimation
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
    ///  FadeOutを初期化する
    /// </summary>
    /// <param name="interval">間隔</param>
    /// <param name="increaseNum">増加値</param>
    /// <param name="isLoop">ループするか</param>
    public FadeOut(double interval, double increaseNum = 1, bool isLoop = false)
    {
        Counter = new(0, 90, interval, increaseNum, isLoop);
        Value = 0;
    }

    /// <summary>
    /// アニメーションを進行する
    /// </summary>
    public void Tick()
    {
        Counter.Tick();

        var rad = (Counter.Value * Math.PI) / 180.0;
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