using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyrimCharacterParser.RawModel.GlobalDataTypes
{
    public class GlobalDataStub : GlobalDataType
    {
        private UInt32 type;

        public GlobalDataStub(UInt32 type)
        {
            this.type = type;
        }

        public override void Print()
        {
            Print("stub for type", type);
        }
    }
}
