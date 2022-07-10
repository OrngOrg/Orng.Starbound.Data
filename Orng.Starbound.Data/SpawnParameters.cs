namespace Star;

public class SpawnParameters
{
    public enum Area
    {
        Surface = 0,
        Ceiling = 1,
        Air = 2,
        Liquid = 3,
        Solid = 4
    }

    public enum Region
    {
        All = 0,
        Enclosed = 1,
        Exposed = 2
    }

    public enum Time
    {
        All = 0,
        Day = 1,
        Night = 2
    }
}
