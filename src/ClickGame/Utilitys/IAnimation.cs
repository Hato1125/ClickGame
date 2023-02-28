namespace ClickGame.Utilt;

internal interface IAnimation
{
    /// <summary>
    /// カウンター
    /// </summary>
    Counter Counter { get; }

    /// <summary>
    /// 現在の値
    /// </summary>
    double Value { get; set; }

    /// <summary>
    /// アニメーションを進行する
    /// </summary>
    void Tick();

    /// <summary>
    /// アニメーションを開始する
    /// </summary>
    void Start();

    /// <summary>
    /// アニメーションを停止させる
    /// </summary>
    void Stop();

    /// <summary>
    /// アニメーションをリセットする
    /// </summary>
    void Reset();
}