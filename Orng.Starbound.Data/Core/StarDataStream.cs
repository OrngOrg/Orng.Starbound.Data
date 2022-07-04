namespace Orng.Starbound.Data;

public class StarDataStreamException : StarException
{
    private readonly StarDataStream? __that = null;

    public StarDataStreamException() : base() { }

    public StarDataStreamException(string message) : base(message) { }

    public StarDataStreamException(StarDataStream __that) : base() 
    => this.__that = __that;

    public StarDataStreamException(StarDataStream __that, string message) : base(message) 
    => this.__that = __that;
}

public class StarDataStream
{
    //.exe+8a9b74
    public const string ErrorCannotOpen = "Cannot open filename '%s'";

    //.exe+8a9c08
    public const string ErrorNoRead = "DataStreamFunctions no read function given";

    //.exe+8a9c34
    public const string ErrorNoWrite = "DataStreamFunctions no write function given";

    //.exe+8a9b90
    public const string ErrorVlqA = "Error reading VLQ encoded intenger!";

    //.exe+8a9bb4
    public const string ErrorVlqB = "Error reading VLQ encoded intenger!";

    //.exe+8a951c
    public const string ErrorReadOutOfRange = "Error, readPosition out of range";

    //.exe+8a9540
    public const string ErrorWriteOutOfRange = "Error, writePosition out of range";

    public Stream? stream = null;

    //.pdb+60b8ba0 60b8bc8 60b8bf8
    public void ReadBytes (byte[] buffer, int len)
    {
        if (stream is null || !stream.CanRead)
            throw new StarDataStreamException(this, ErrorNoRead);

        if (stream.Position + len > buffer.Length)
            throw new StarDataStreamException(this, ErrorReadOutOfRange);

        try
        {
            stream.Read(buffer, 0, len);
        }
        catch (Exception e)
        {
            throw new AggregateException(new StarDataStreamException(this), e);
        }
    }

    //.pdb+60b8cdc 660b8d04
    public long ReadVlqI ()
    {
        if (stream is null || !stream.CanRead)
            throw new StarDataStreamException(this, ErrorNoRead);

        try
        {
            var vlq = VlqI.ReadFromStream(stream);
            return vlq.Value;
        }
        catch (Exception e)
        {
            throw new AggregateException(new StarDataStreamException(this, ErrorVlqA), e);
        }
    }

    //.pdb+60b908c 60b90b0
    public string ReadVlqS ()
    {
        if (stream is null || !stream.CanRead)
            throw new StarDataStreamException(this, ErrorNoRead);

        try
        {
            var vlq = VlqS.ReadFromStream(stream);
            return vlq.Value;
        }
        catch (Exception e)
        {
            throw new AggregateException(new StarDataStreamException(this), e);
        }
    }

    //.pdb+60b91c8 60b91f0
    public ulong ReadVlqU ()
    {
        if (stream is null || !stream.CanRead)
            throw new StarDataStreamException(this, ErrorNoRead);

        try
        {
            var vlq = VlqU.ReadFromStream(stream);
            return vlq.Value;
        }
        catch (Exception e)
        {
            throw new AggregateException(new StarDataStreamException(this, ErrorVlqB), e);
        }
    }

    //.pdb+60b9610 60b9658
    public void WriteBytes (byte[] ba)
    {
        if (stream is null || !stream.CanWrite)
            throw new StarDataStreamException(this, ErrorNoWrite);

        if (stream.Position + ba.Length > stream.Length)
            throw new StarDataStreamException(this, ErrorWriteOutOfRange);

        try
        {
            stream.Write(ba, 0, ba.Length);
        }
        catch (Exception e)
        {
            throw new AggregateException(new StarDataStreamException(this), e);
        }
    }

    //.pdb+60b9704
    public void WriteVlqI (VlqI vlq)
    => WriteBytes(vlq.ToByteArray());
    
    public void WriteVlqI (long vlq)
    => WriteBytes(new VlqI(vlq).ToByteArray());

    //.pdb+60b9908
    public void WriteVlqS (VlqS vlq)
    => WriteBytes(vlq.ToByteArray());

    public void WriteVlqS (string vlq)
    => WriteBytes(new VlqS(vlq).ToByteArray());

    //.pdb+60b9a78
    public void WriteVlqU (VlqU vlq)
    => WriteBytes(vlq.ToByteArray());

    public void WriteVlqU (ulong vlq)
    => WriteBytes(new VlqU(vlq).ToByteArray());
}
