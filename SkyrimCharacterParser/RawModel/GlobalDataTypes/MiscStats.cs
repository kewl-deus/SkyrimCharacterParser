using System;

namespace SkyrimCharacterParser.RawModel.GlobalDataTypes
{
    public class MiscStats : GlobalDataType
    {
        public UInt32 count;
        public MiscStat[] stats;

        
        public override void Print()
        {
            Print("count", count);
            foreach (var miscStat in stats)
            {
                miscStat.Print();
            }
        }
    }
}
