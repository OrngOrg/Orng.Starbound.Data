namespace Orng.Starbound.Data;

// 60b91c8 Star::readVlqU (Stream source)

public class VlqU
{
#pragma warning disable IDE0032 // Use auto property
    private readonly ulong value;
#pragma warning restore IDE0032 // Use auto property

    public ulong Value => value;

    public VlqU(ulong value) => this.value = value;

    public byte[] ToByteArray()
    {

        //https://github.com/StarryPy/StarryPy3k/blob/9291e5a7ca97004675a4868165ce5690c111c492/data_parser.py#L196
        ulong store = value;

        if (store == 0)
            return new byte[0];

        var arr = new List<byte>(); // This can be optimized by finding the max bytes allowed.
                                    // Otherwise it allocates each time the limit is reached * 2 capacity.
                                    // https://stackoverflow.com/questions/51227535/how-does-c-sharp-dynamically-allocate-memory-for-a-listt

        byte b;

        while (store > 0)
        {
            b = (byte)(store & 0x7F);
            store >>= 7;
            
            if (store != 0)
                b |= 0x80; // Cont flag

            arr.Add(b);
        }

        if (arr.Count > 1)
        {
            arr[0] |= 0x80;  // this shouldn't be necessary as b |= 0x80 adds the continue bit. Needs testing.
            arr[^1] ^= 0x80; // again... shouldn't be necessary. this hotfix is suspicious.
        }

        return arr.ToArray();
    }

    public void WriteToStream (Stream s)
    {
        byte[] arr = ToByteArray();

        if (!s.CanWrite)
            throw new StarDataStreamException(StarDataStream.ErrorNoWrite);

        if (s.Position + arr.Length > s.Length)
            throw new StarDataStreamException(StarDataStream.ErrorWriteOutOfRange);

        s.Write(arr, 0, arr.Length);
    }

    public static VlqU ReadFromStream (Stream source)
    {
        if (!source.CanRead)
            throw new StarDataStreamException(StarDataStream.ErrorNoRead);

        //https://github.com/StarryPy/StarryPy3k/blob/9291e5a7ca97004675a4868165ce5690c111c492/data_parser.py#L183
        ulong store = 0;

        byte[] buffer = new byte[1];

        while (true)
        {
            int res = source.Read(buffer, 0, 1);

            if (res == 0)
                throw new StarDataStreamException(StarDataStream.ErrorReadOutOfRange);

            store = (store << 7) | ((ulong)buffer[0] & (ulong)0x7F);

            if ((buffer[0] & 0x80) == 0) // if there is no Cont flag
                break;
        }

        return new VlqU(store);
    }
}
