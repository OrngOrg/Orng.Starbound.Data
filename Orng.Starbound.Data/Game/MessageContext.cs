namespace Star;

public class MessageContext
{
    public enum Mode
    {
        Local = 0,
        Party = 1,
        Broadcast = 2,
        Whisper = 3,
        CommandResult = 4,
        RadioMessage = 5,
        World = 6
    }
}
