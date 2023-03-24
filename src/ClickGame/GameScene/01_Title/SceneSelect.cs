using ClickGame.GUIControls;
using DxLibDLL;

namespace ClickGame.GameScene.TitleScene;

internal class SceneSelect : SceneBase
{
    #region Private Member

    private readonly int[] buttonHandle;
    private readonly string[] gotoScene;
    private readonly UIButton[] buttons;
    private string gotoSceneName;

    #endregion

    public SceneSelect()
    {
        gotoSceneName = string.Empty;
        gotoScene = new string[]
        {
            "Game",
            "Setting",
            "Exit",
        };

        buttonHandle = new int[]
        {
            GraphicsResource.GetResource("StartButton"),

            GraphicsResource.GetResource("SettingButton"),
            GraphicsResource.GetResource("ExitButton"),
        };

        buttons = new UIButton[buttonHandle.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = new(buttonHandle[i]);

            // UIの位置の計算
            int center_x = (App.CliantWidth - buttons[i].Width) / 2;
            int center_y = (App.CliantHeight - buttons[i].Height) / 2;
            int ypos = i * (buttons[i].Height + 10);
            buttons[i].X = center_x;
            buttons[i].Y = center_y + ypos;
            buttons[i].SoundHandle = SoundResource.GetResource("PushButton");
        }
    }

    public override void Init()
    {
        foreach (var btns in buttons)
            btns.IsInput = true;
    }

    public override void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Update();

            if (buttons[i].IsSeparate())
            {
                // TODO: 終了処理へ行くように実装しようか... 今はとりあえずreturnしときます。
                if(i == buttons.Length - 1)
                    return;

                // ボタンの操作をできなくする
                foreach (var btns in buttons)
                    btns.IsInput = false;

                // 遷移情報をセット
                gotoSceneName = gotoScene[i];
                Title.OnFadeOutEnd += GotoScene;
                Title.IsFadeOut = true;
            }
        }
    }

    public override void Draw()
    {
        foreach (var btns in buttons)
            btns.Draw();
    }

    private void GotoScene()
        => SceneManeger.SetScene(gotoSceneName);
}