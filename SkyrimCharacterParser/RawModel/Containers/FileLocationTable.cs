using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyrimCharacterParser.RawModel.Containers
{
    public class FileLocationTable : DataContainer
    {
        public UInt32 formIDArrayCount; // 	uint32 	Absolute offset to the start of File.formIDArrayCount.
        public UInt32 unknownTable3Offset; // 	uint32 	Absolute offset to the start of File.unknown3TableSize.
        public UInt32 globalDataTable1Offset; // 	uint32 	Absolute offset to the start of File.globalDataTable1.
        public UInt32 globalDataTable2Offset; // 	uint32 	Absolute offset to the start of File.globalDataTable2.
        public UInt32 changedFormsOffset; // 	uint32 	Absolute offset to the start of File.changedForms.
        public UInt32 globalDataTable3Offset; // 	uint32 	Absolute offset to the start of File.globalDataTable3.
        public UInt32 globalDataTable1Count; // 	uint32 	The number of Global Data in File.globalDataTable1 (9).
        public UInt32 globalDataTable2Count; // 	uint32 	The number of Global Data in File.globalDataTable2 (15).
        public UInt32 globalDataTable3Count; // 	uint32 	The number of Global Data in File.globalDataTable3 (5 -- bugged).

        public UInt32 changedFormCount;
        public UInt32[] unused; 	//uint32[15]

        public override void Print()
        {
            Print("formIDArrayCount", formIDArrayCount);
            Print("unknownTable3Offset", unknownTable3Offset);
            Print("globalDataTable1Offset", globalDataTable1Offset);
            Print("globalDataTable2Offset", globalDataTable2Offset);
            Print("changedFormsOffset", changedFormsOffset);
            Print("globalDataTable3Offset", globalDataTable3Offset);
            Print("globalDataTable1Count", globalDataTable1Count);
            Print("globalDataTable2Count", globalDataTable2Count);
            Print("globalDataTable3Count", globalDataTable3Count);
            Print("changedFormCount", changedFormCount);
        }

    }
}
