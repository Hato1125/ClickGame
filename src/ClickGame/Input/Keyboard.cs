using DxLibDLL;

namespace ClickGame;

internal static class Keyboard
{
    private static readonly byte[] buffer = new byte[256];
    private static readonly sbyte[] value = new sbyte[256];

    /// <summary>
    /// 更新する
    /// </summary>
    public static void Update()
    {
        DX.GetHitKeyStateAll(buffer);

        for (int i = 0; i < buffer.Length; i++)
        {
            if (DX.CheckHitKey(i) == 1)
                value[i] = (sbyte)(IsPushing(i) ? 2 : 1);
            else
                value[i] = (sbyte)(IsPushing(i) ? -1 : 0);
        }
    }

    /// <summary>
    /// キーを押している間を取得する
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns></returns>
    public static bool IsPushing(int key)
        => value[key] > 0;

    /// <summary>
    /// キーを押した瞬間を取得する
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns></returns>
    public static bool IsPushed(int key)
        => value[key] == 1;

    /// <summary>
    /// キーを離した瞬間を取得する
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns></returns>
    public static bool IsSeparate(int key)
        => value[key] == -1;
}