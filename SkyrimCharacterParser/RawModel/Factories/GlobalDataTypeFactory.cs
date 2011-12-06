using System;
using System.IO;
using SkyrimCharacterParser.RawModel.Containers;
using SkyrimCharacterParser.RawModel.GlobalDataTypes;
using SkyrimCharacterParser.RawModel.Reader;

namespace SkyrimCharacterParser.RawModel.Factories
{
    public abstract class GlobalDataTypeFactory
    {
        public abstract bool CanBuild(GlobalData globalData);

        public abstract GlobalDataType BuildType(GlobalData globalData);

        protected SkyrimBinaryReader CreateDataReader(GlobalData globalData)
        {
            return new SkyrimBinaryReader(new MemoryStream(globalData.data));
        }
    }
}
