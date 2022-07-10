namespace Star;

public class JsonWriter
{
    public enum State
    {
        Top = 0,
        Object = 1,
        ObjectElement = 2,
        Array = 3,
        ArrayElement = 4
    }
}
