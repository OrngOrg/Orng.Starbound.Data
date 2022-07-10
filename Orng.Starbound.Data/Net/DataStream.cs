namespace Star;

public class DataStream
{
    public const uint CurrentStreamVersion = 1;

    private ByteOrder m_byteOrder = Star.ByteOrder.NoConversion;
    private bool m_nullTerminatedStrings = true;
    private uint m_streamCompatibilityVersion = CurrentStreamVersion;

    public ByteOrder ByteOrder() => m_byteOrder;
    public bool NullTerminatedStrings() => m_nullTerminatedStrings;
    public uint StreamCompatibilityVersion() => m_streamCompatibilityVersion;


    public Stream stream;

    public DataStream(Stream stream) => this.stream = stream;

    public void SetByteOrder (ByteOrder byteOrder) 
    => m_byteOrder = byteOrder;

    public void SetNullTerminatedStrings (bool nullTerminatedStrings) 
    => m_nullTerminatedStrings = nullTerminatedStrings;

    public void SetStreamCompatibilityVersion (uint streamCompatibilityVersion) 
    => m_streamCompatibilityVersion = streamCompatibilityVersion;

    public void ReadData (byte[] buffer, uint len)
    {
        if (stream is null)
            throw new DataStreamException();

        if (!stream.CanRead)
            throw new DataStreamException();

        if (stream.Position + len > stream.Length)
            throw new DataStreamException();

        stream.Read(buffer, 0, (int)len);
    }

    public void WriteData (byte[] data, uint len)
    {
        if (stream is null)
            throw new DataStreamException();

        if (!stream.CanWrite)
            throw new DataStreamException();

        if (stream.Position + len > stream.Length)
            throw new DataStreamException();

        stream.Write(data, 0, (int)len);
    }

    public Star.ByteArray ReadBytes (uint len)
    {
        byte[] data = new byte[len];
        ReadData(data, len);
        return new Star.ByteArray(data);
    }

    public void WriteBytes(Star.ByteArray data)
    {
        WriteVlqU((uint)data.Value.Length);
        WriteData(data.Value, (uint)data.Value.Length);
    }

    public void Write(Star.String v) => Write(v.Value);

    public void Write(Star.ByteArray v) => WriteBytes(v);

    public void Write(string v) 
    => WriteBytes(new ByteArray(System.Text.Encoding.UTF8.GetBytes(v)));

    unsafe public void Write(char* v) => Write(new string(v));

    public void Write(float v)
    {
        
    }

    public void Write(uint v)
    {
        //
    }

    public void Write(int v)
    {
        //
    }

    public void Write(char v)
    {
        //
    }

    public void Write(bool v)
    {
        //
    }

    public void Read(ref Star.String v)
    {
        //
    }

    public void Read(ref Star.ByteArray v)
    {
        //
    }

    public void Read(ref string v)
    {
        //
    }

    public void Read(ref float v)
    {
        //
    }

    public void Read(ref uint v)
    {
        //
    }

    public void Read(ref int v)
    {
        //
    }

    public void Read(ref char v)
    {
        //
    }

    public void Read(ref bool v)
    {
        //
    }

    public uint WriteVlqU(uint v)
    {
        return 0;
    }

    public uint WriteVlqI(int v)
    {
        return 0;
    }

    public uint WriteVlqS(uint v)
    {
        return 0;
    }

    public uint ReadVlqU()
    {
        return 0;
    }

    public uint ReadVlqU(ref uint v)
    {
        return 0;
    }

    public int ReadVlqI()
    {
        return 0;
    }

    public uint ReadVlqI(ref int v)
    {
        return 0;
    }

    public uint ReadVlqS()
    {
        return 0;
    }

    public uint ReadVlqS(ref uint v)
    {
        return 0;
    }

    unsafe private void WriteStringData(char* v, uint len)
    {
        //
    }


}
