using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyrimCharacterParser.RawModel.Containers;
using SkyrimCharacterParser.RawModel.GlobalDataTypes;

namespace SkyrimCharacterParser.RawModel.Factories
{
    public class GlobalDataStubFactory : GlobalDataTypeFactory
    {
        public override bool CanBuild(GlobalData globalData)
        {
            return true;
        }

        public override GlobalDataType BuildType(GlobalData globalData)
        {
            return new GlobalDataStub(globalData.type);
        }
    }
}
