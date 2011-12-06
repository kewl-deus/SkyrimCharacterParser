using System;
using System.IO;
using SkyrimCharacterParser.RawModel.Containers;
using SkyrimCharacterParser.RawModel.GlobalDataTypes;
using SkyrimCharacterParser.RawModel.Reader;

namespace SkyrimCharacterParser.RawModel.Factories
{
    public class MiscStatsFactory : GlobalDataTypeFactory
    {
        public override bool CanBuild(GlobalData globalData)
        {
            return globalData.type == 0;
        }

        public override GlobalDataType BuildType(GlobalData globalData)
        {
            SkyrimBinaryReader br = CreateDataReader(globalData);

            MiscStats ms = new MiscStats();
            ms.count = br.ReadUInt32();
            ms.stats = new MiscStat[ms.count];

            for (int i = 0; i < ms.count; i++)
            {
                MiscStat m = new MiscStat();
                m.name = br.ReadWString();
                m.category = br.ReadByte();
                m.value = br.ReadInt32();

                ms.stats[i] = m;
            }

            return ms;
        }


        
    }
}
