namespace Star;

public class ByteArray
{
    public byte[] Value { get; set; } = new byte[0];

    public ByteArray() { }
    public ByteArray(byte[] value) => Value = value;
}
