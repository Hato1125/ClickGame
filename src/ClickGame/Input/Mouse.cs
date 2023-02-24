using DxLibDLL;

namespace ClickGame;

internal static class Mouse
{
    private static readonly sbyte[] value = new sbyte[8];

    /// <summary>
    /// Windowの位置基準のマウスカーソルのX座標
    /// </summary>
    public static int X { get; private set; }

    /// <summary>
    /// Windowの位置基準のマウスカーソルのY座標
    /// </summary>
    public static int Y { get; private set; }

    /// <summary>
    /// マウスホイールの回転量
    /// </summary>
    public static float Wheel { get; private set; }

    /// <summary>
    /// 更新する
    /// </summary>
    public static void Update()
    {
        DX.GetMousePoint(out int x, out int y);
        Wheel = DX.GetMouseWheelRotVolF();
        X = x;
        Y = y;

        for(int i = 0; i < value.Length; i++)
        {
            if (DX.GetMouseInput() == (int)GetMouseKey(i))
                value[i] = (sbyte)(IsPushing(GetMouseKey(i)) ? 2 : 1);
            else
                value[i] = (sbyte)(IsPushing(GetMouseKey(i)) ? -1 : 0);
        }
    }

    /// <summary>
    /// ボタンを押している間を取得する
    /// </summary>
    /// <param name="key">キー</param>
    public static bool IsPushing(MouseKey key)
        => value[GetMouseKeyIndex(key)] > 0;

    /// <summary>
    /// ボタンを押した瞬間を取得する
    /// </summary>
    /// <param name="key">キー</param>
    public static bool IsPushed(MouseKey key)
        => value[GetMouseKeyIndex(key)] == 1;

    /// <summary>
    /// ボタンを離した瞬間を取得する
    /// </summary>
    /// <param name="key">キー</param>
    public static bool IsSeparate(MouseKey key)
        => value[GetMouseKeyIndex(key)] == -1;

    private static int GetMouseKeyIndex(MouseKey key) => key switch
    {
        MouseKey.Left => 0,
        MouseKey.Right => 1,
        MouseKey.Middle => 2,
        MouseKey.Input_4 => 3,
        MouseKey.Input_5 => 4,
        MouseKey.Input_6 => 5,
        MouseKey.Input_7 => 6,
        MouseKey.Input_8 => 7,
        _ => 0
    };

    private static MouseKey GetMouseKey(int index) => index switch
    {
        0 => MouseKey.Left,
        1 => MouseKey.Right,
        2 => MouseKey.Middle,
        3 => MouseKey.Input_4,
        4 => MouseKey.Input_5,
        5 => MouseKey.Input_6,
        6 => MouseKey.Input_7,
        7 => MouseKey.Input_8,
        _ => MouseKey.Left
    };
}

/// <summary>
/// マウスのキーコード
/// </summary>
public enum MouseKey
{
    Left = DX.MOUSE_INPUT_LEFT,
    Right = DX.MOUSE_INPUT_RIGHT,
    Middle = DX.MOUSE_INPUT_MIDDLE,
    Input_4 = DX.MOUSE_INPUT_4,
    Input_5 = DX.MOUSE_INPUT_5,
    Input_6 = DX.MOUSE_INPUT_6,
    Input_7 = DX.MOUSE_INPUT_7,
    Input_8 = DX.MOUSE_INPUT_8,
}