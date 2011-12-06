using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;

namespace SkyrimCharacterParser.RawModel.Containers
{
    public class Header : DataContainer
    {
        public UInt32 version;
        public UInt32 saveNumber;
        public string playerName;
        public UInt32 playerLevel;
        public string playerLocation;
        public string gameDate;
        public string playerRaceEditorID;

        public UInt16 unknown1;
        public byte[] unknown2float32;
        public byte[] unknown3float32;

        public FILETIME filetime;

        public UInt32 shotWidth;
        public UInt32 shotHeight;

        public DateTime GetSaveTime()
        {
            long highBits = ((long) filetime.dwHighDateTime) << 32;
            long lowBits = (uint) filetime.dwLowDateTime;
            DateTime saveTime = DateTime.FromFileTime(highBits + lowBits);
            return saveTime;
        }

        public override void  Print()
        {
            Print("version", version);
            Print("saveNumber", saveNumber);
            Print("playerName", playerName);
            Print("playerLevel", playerLevel);
            Print("playerLocation", playerLocation);
            Print("gameDate", gameDate);
            Print("playerRaceEditorID", playerRaceEditorID);
            //Print("filetime", fileTime);
            Print("shotWidth", shotWidth);
            Print("shotHeight", shotHeight);

            Print("saveTime", GetSaveTime());
        }

    }
}
