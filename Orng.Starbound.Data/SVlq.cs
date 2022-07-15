namespace Orng.Starbound.Data;

public class SVlq
{
    public int Value { get; set; }

    public SVlq (int value) => this.Value = value;

    public int NumBytes()
    {
        double bits;

        if (Value > 0)
        {
            bits = Math.Log2((double)Value * 2d) + 1d;
        }
        else
        {
            bits = Math.Log2(Math.Abs(Value) + 1d);
        }

        return (int)Math.Max(Math.Ceiling(bits / 7d), 1);
    }

    private byte SnipBits(ref uint v, int bits)
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

    private byte NegativeFlagSnip (ref int v)
    {
        bool isNegative = false;

        if (v < 0)
        {
            isNegative = true;
            v = Math.Abs(v) >> 1;
        }

        byte b = (byte)(SnipBits(ref v, 6) << 1);

        if (isNegative)
        {
            AddNegativeFlag(ref b);
        }

        if (v > 0)
        {
            AddContinueFlag(ref b);
        }

        return b;
    }

    private void AddContinueFlag(ref byte b) => b |= 0b10000000;

    private void AddNegativeFlag(ref byte b) => b |= 1;

    public byte[] GetBytes()
    {
        int v = Value;

        byte[] bytes = new byte[NumBytes()];
        int currentByte = 0;

        byte b = NegativeFlagSnip(ref v);
        bytes[currentByte++] = b;

        while (v > 0)
        {
            b = SnipBits(ref v, 7);

            if (v > 0)
                AddContinueFlag(ref b);

            bytes[currentByte++] = b;
        }

        return bytes;
    }

    public void WriteToStream(Stream s) => s.Write(GetBytes());
}
