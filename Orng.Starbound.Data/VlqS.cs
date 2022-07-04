using System.Text;

namespace Orng.Starbound.Data;

// 60b908c Star::readVlqS

public class VlqS
{
    private readonly byte[] value;

    public string Value => Encoding.UTF8.GetString(value);

    public VlqS(string value) 
    => this.value = Encoding.UTF8.GetBytes(value);

    public VlqS(byte[] value)
    => this.value = value;

    public byte[] ToByteArray()
    {
        var size = new VlqU((ulong) value.Length);

        var vs = new List<byte>();
        vs.AddRange(size.ToByteArray());
        vs.AddRange(value);

        return vs.ToArray();
    }

    public void WriteToStream (Stream stream)
    {
        byte[] arr = ToByteArray();

        if (!stream.CanWrite)
            throw new StarDataStreamException(StarDataStream.ErrorNoWrite);

        if (stream.Position + arr.Length > stream.Length)
            throw new StarDataStreamException(StarDataStream.ErrorWriteOutOfRange);

        stream.Write(arr, 0, arr.Length);
    }

    public static VlqS ReadFromStream (Stream source)
    {
        var size = VlqU.ReadFromStream(source);

        if (!source.CanRead)
            throw new StarDataStreamException(StarDataStream.ErrorNoRead);

        if (source.Position + (long)size.Value > source.Length)
            throw new StarDataStreamException(StarDataStream.ErrorReadOutOfRange);

        byte[] buffer = new byte[(int)size.Value];

        source.Read(buffer, 0, (int)size.Value);
        return new VlqS(buffer);
    }
}
