using System;
using SkyrimCharacterParser.RawModel.Containers;

namespace SkyrimCharacterParser.RawModel.GlobalDataTypes
{
    public class MiscStat : DataContainer
    {
        public string name;
        public byte category;
        public Int32 value;


        public override void Print()
        {
            Print("name", name);
            Print("category", category);
            Print("value", value);
        }
    }
}
