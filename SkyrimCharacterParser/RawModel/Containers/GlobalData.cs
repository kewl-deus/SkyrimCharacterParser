using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SkyrimCharacterParser.RawModel.Containers
{
    public class GlobalData : DataContainer
    {
        public UInt32 type;
        public UInt32 length;
        public byte[] data; //uint8[length]

        public override void Print()
        {
            Print("type", type);
            Print("length", length);
        }

        
    }
}
