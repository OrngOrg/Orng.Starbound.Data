namespace Star;

public class ClientApplication
{
    public enum MainAppState
    {
        Quit = 0,
        Startup = 1,
        Mods = 2,
        ModsWarning = 3,
        Splash = 4,
        Error = 5,
        Title = 6,
        SinglePlayer = 7,
        MultiPlayer = 8
    }
}
