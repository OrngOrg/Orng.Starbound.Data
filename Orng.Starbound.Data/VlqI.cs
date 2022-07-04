namespace Orng.Starbound.Data;

// 60b8cdc Star::readVlqI (Stream source)

public class VlqI
{
#pragma warning disable IDE0032 // Use auto property
    private readonly long value;
#pragma warning restore IDE0032 // Use auto property

    public long Value => value;
    
    public VlqI(long value) => this.value = value;

    public byte[] ToByteArray()
    {
        //https://github.com/StarryPy/StarryPy3k/blob/9291e5a7ca97004675a4868165ce5690c111c492/data_parser.py#L229
        ulong store = (ulong) Math.Abs(value * 2);

        if (store  < 0)
            store -= 1;

        return new VlqU(store).ToByteArray();
    }

    public void WriteToStream(Stream s)
    {
        byte[] arr = ToByteArray();

        if (s.Position + arr.Length > s.Length)
            throw new StarDataStreamException(StarDataStream.ErrorWriteOutOfRange);

        s.Write(arr, 0, arr.Length);
    }

    public static VlqI ReadFromStream(Stream source)
    {
        //https://github.com/StarryPy/StarryPy3k/blob/9291e5a7ca97004675a4868165ce5690c111c492/data_parser.py#L221
        var unsigned = VlqU.ReadFromStream(source);

        return 
            (unsigned.Value & 1) == 0x00 // If there is no neg flag
                ? new VlqI(  (long)(unsigned.Value) >> 1)
                : new VlqI(-((long)(unsigned.Value) >> 1) + 1);
    }
}
