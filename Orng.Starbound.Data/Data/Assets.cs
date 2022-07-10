namespace Star;

public class Assets
{
    public enum AssetType
    {
        Json = 0,
        Image = 1,
        Audio = 2,
        Font = 3,
        Bytes = 4
    }

    public enum QueuePriority
    {
        None = 0,
        Working = 1,
        PostProcess = 2,
        Load = 3
    }
}
