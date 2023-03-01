using System.Diagnostics;

namespace ClickGame.Utilt;

internal class Counter
{
    #region Private Member

    private readonly Stopwatch tickStopwatch = new();

    #endregion

    #region Public Member

    /// <summary>
    /// 現在の値
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// 終了値
    /// </summary>
    public double EndValue { get; set; }

    /// <summary>
    /// Tickする間隔
    /// </summary>
    public double TickInterval { get; set; }

    /// <summary>
    /// 1Tickでの増加値
    /// </summary>
    public double IncreaseNumber { get; set; }

    /// <summary>
    /// ループするか
    /// </summary>
    public bool IsLoop { get; set; }

    /// <summary>
    /// スタートしているか
    /// </summary>
    public bool IsStart { get; private set; }

    /// <summary>
    /// 終了値に達しているか
    /// </summary>
    public bool IsEnd { get => Value >= EndValue ? true : false; }

    /// <summary>
    /// 現在のカウンタの状態
    /// </summary>
    public CounterState State { get; private set; }

    #endregion

    /// <summary>
    /// カウンタを初期化する
    /// </summary>
    /// <param name="begin">初期値</param>
    /// <param name="end">終了値</param>
    /// <param name="interval">間隔</param>
    /// <param name="increaseNum">増加量</param>
    /// <param name="isLoop">ループするか</param>
    public Counter(double begin, double end, double interval, double increaseNum = 1, bool isLoop = false)
    {
        Value = begin;
        EndValue = end;
        TickInterval = interval;
        IncreaseNumber = increaseNum;
        IsLoop = isLoop;
        IsStart = false;
        State = CounterState.Stoping;
    }

    /// <summary>
    /// Tickする
    /// </summary>
    public void Tick()
    {
        if (!IsStart)
            return;

        // StartしているのにストップウォッチがStartしていない
        if (!tickStopwatch.IsRunning)
            tickStopwatch.Start();

        if (tickStopwatch.Elapsed.TotalSeconds >= TickInterval)
        {
            if (Value >= EndValue)
            {
                if (IsLoop)
                {
                    Value = 0;
                    tickStopwatch.Restart();
                }
                else
                {
                    Stop();
                    tickStopwatch.Stop();
                }
            }
            else
            {
                Value += IncreaseNumber;
                tickStopwatch.Restart();
            }
        }
    }

    /// <summary>
    /// カウンタを開始する
    /// </summary>
    public void Start()
    {
        if (IsStart)
            return;

        State = CounterState.Starting;

        if (!tickStopwatch.IsRunning)
            tickStopwatch.Start();
            
        IsStart = true;
    }

    /// <summary>
    /// カウンタを停止させる
    /// </summary>
    public void Stop()
    {
        State = CounterState.Stoping;
        tickStopwatch.Stop();
        IsStart = false;
    }

    /// <summary>
    /// カウンタをリセットする
    /// </summary>
    /// <param name="begin">初期値</param>
    public void Reset(double begin = 0)
    {
        tickStopwatch.Reset();
        Value = begin;
    }

    /// <summary>
    /// 現在の値の文字列表記を取得する
    /// </summary>
    public override string ToString()
        => Value.ToString();

    /// <summary>
    /// 現在の値の文字列表記を取得する
    /// </summary>
    public string ToString(string format)
        => Value.ToString(format);
}

/// <summary>
/// カウンタの状態を表す列挙型
/// </summary>
public enum CounterState
{
    /// <summary>
    /// 開始している
    /// </summary>
    Starting,

    /// <summary>
    /// 止まっている
    /// </summary>
    Stoping,
}