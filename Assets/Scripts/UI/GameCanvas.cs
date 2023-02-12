namespace UI {

    [System.Flags]
    public enum GameCanvas {
        //MainMenuCanvases
        MainMenu = 1 << 0,
        Options = 1 << 1,
        Presets = 1 << 2,

        //GameplayCanvases
        StartTimer = 1 << 3,
        HUD = 1 << 4,
        AimCanvas = 1 << 5,
        PauseMenu = 1 << 6,
        GameOver = 1 << 7
    }
}