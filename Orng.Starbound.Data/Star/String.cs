using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orng.Starbound.Data;

namespace Star;
public class String
{
    public string Value { get; set; }

    public String (string value) => Value = value;

    public byte[] GetBytes()
    {
        var utf8Bytes = Encoding.UTF8.GetBytes(Value);

        var vlqSize = new Vlq((uint)utf8Bytes.Length);

        var fullBuffer = new byte[vlqSize.NumBytes() + utf8Bytes.Length];

        var ms = new MemoryStream(fullBuffer);
        vlqSize.WriteToStream(ms);
        ms.Write(utf8Bytes);
        ms.Dispose();

        return fullBuffer;
    }

    public void WriteToStream(Stream s) => s.Write(GetBytes());
}
