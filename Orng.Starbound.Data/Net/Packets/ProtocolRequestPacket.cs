using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star;
public struct ProtocolRequestPacket
{
    public uint requestProtocolVersion = 0;

    public ProtocolRequestPacket() { }
    public ProtocolRequestPacket(uint requestProtocolVersion) => this.requestProtocolVersion = requestProtocolVersion;

    public void Read (DataStream s)
    {

    }

    public void Write (DataStream s)
    {

    }
}
