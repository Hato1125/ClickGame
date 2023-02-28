namespace ClickGame;

internal static class LoadGraphics
{
    private static readonly string FILE = $"{AppContext.BaseDirectory}Asset\\Graphics\\";
    private static readonly string TITLE = "Title\\";
    private static readonly string GAME = "Game\\";

    /// <summary>
    /// Groaphicsを読み込む
    /// </summary>
    public static void Load()
    {
        LoadTitleImg();
        LoadGameImg();
    }

    private static void LoadTitleImg()
    {
        GraphicsResource.AddResource("TitleBack", $"{FILE}{TITLE}Background.png");
        GraphicsResource.AddResource("TitleLogo", $"{FILE}{TITLE}TitleLogo.png");
        GraphicsResource.AddResource("StartButton", $"{FILE}{TITLE}StartButton.png");
        GraphicsResource.AddResource("SettingButton", $"{FILE}{TITLE}SettingButton.png");
        GraphicsResource.AddResource("ExitButton", $"{FILE}{TITLE}ExitButton.png");
    }

    private static void LoadGameImg()
    {
        GraphicsResource.AddResource("GameBack", $"{FILE}{GAME}Background.png");
        GraphicsResource.AddResource("ClickPanel", $"{FILE}{GAME}ClickPanel.png");
        GraphicsResource.AddResource("Effect_1", $"{FILE}{GAME}Effect\\Effect_1.png");
        GraphicsResource.AddResource("Effect_2", $"{FILE}{GAME}Effect\\Effect_2.png");
        GraphicsResource.AddResource("Effect_3", $"{FILE}{GAME}Effect\\Effect_3.png");
        GraphicsResource.AddResource("ShopItemPanel", $"{FILE}{GAME}Shop\\ShopItemPanel.png");
        GraphicsResource.AddResource("ClickerIcon", $"{FILE}{GAME}Shop\\ClickerIcon.png");
        GraphicsResource.AddResource("TwinClickerIcon", $"{FILE}{GAME}Shop\\TwinClickerIcon.png");
        GraphicsResource.AddResource("ContinuePanel", $"{FILE}{GAME}Continue\\Panel.png");
        GraphicsResource.AddResource("ContinueButton", $"{FILE}{GAME}Continue\\ContinueButton.png");
        GraphicsResource.AddResource("ContinueButton_1", $"{FILE}{GAME}Continue\\ContinueButton_1.png");
        GraphicsResource.AddResource("ContinueButton_2", $"{FILE}{GAME}Continue\\ContinueButton_2.png");
        GraphicsResource.AddResource("ContinueButton_3", $"{FILE}{GAME}Continue\\ContinueButton_3.png");
    }
}