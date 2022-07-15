namespace Orng.Starbound.Data;

public class Vlq
{
    public uint Value { get; set; }

    public Vlq (uint value) => this.Value = value;

    public int NumBytes ()
    {
        double bits = Math.Log2((double) Value * 2d);

        //if (signed)
        //    bits += 1d;

        return (int)Math.Max(Math.Ceiling(bits / 7d), 1);
    }

    private byte SnipBits (ref uint v, int bits)
    {
        byte output = (byte)((byte)v & (byte)(Math.Pow(2, bits) - 1));
        v >>= bits;

        return output;
    }

    private byte SnipBits(ref int v, int bits)
    {
        byte output = (byte)((byte)v & (byte)(Math.Pow(2, bits) - 1));
        v >>= bits;

        return output;
    }

    private void AddContinueFlag(ref byte b) => b |= 0b10000000;

    public byte[] GetBytes ()
    {
        uint v = Value;

        //byte[] bytes = new byte[NumBytes()];
        List<byte> _bytes = new List<byte>();
        int currentByte = 0;

        while (v > 0)
        {
            byte b = SnipBits(ref v, 7);
            
            if (v > 0)
                AddContinueFlag(ref b);

            //bytes[currentByte++] = b;
            _bytes.Add(b);
        }

        return _bytes.ToArray();
    }

    public void WriteToStream(Stream s) => s.Write(GetBytes());
}
