using ClickGame.Utilt;
using System.Diagnostics;

namespace ClickGame.GUIControls;

internal class Scroll
{
    #region Private Member

    private Counter Scroller;
    private bool isScroll;
    private bool isUp;

    #endregion

    #region Public Member

    public double ScrollInterval { get; set; }
    public double ScrollIncreaseNumber { get; set; }
    public double Value { get; private set; }

    #endregion

    public Scroll(double interval, double increaseNum)
    {
        ScrollInterval = interval;
        ScrollIncreaseNumber = increaseNum;
        Scroller = new(0, 0, interval, increaseNum);
    }

    public void Tick()
    {
        if (Mouse.Wheel != 0)
        {
            isUp = Mouse.Wheel < 0 ? true : false;
            ScrollSetUp();
        }

        if (isScroll)
        {
            Scroller.Tick();
            var scrollValue = TickEasing(100.0);
            Value += isUp ? scrollValue : -scrollValue;

            // ちゃんと10までいかないので丸めて判定する
            if (Scroller.IsEnd)
            {
                isScroll = false;
                Scroller.Stop();
            }
        }
    }

    public void ScrollSetUp()
    {
        isScroll = true;
        Scroller = new(0, 100, ScrollInterval, ScrollIncreaseNumber);
        Scroller.Start();
    }

    public double TickEasing(double tergetValue)
        => (tergetValue - Scroller.Value) * 0.019775;
}