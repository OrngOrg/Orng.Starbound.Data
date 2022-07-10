namespace Star;
public class DataStreamException : IOException
{
    public DataStreamException() : base() { }
    public DataStreamException(string message) : base(message) { }
}
