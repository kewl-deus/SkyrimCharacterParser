using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyrimCharacterParser.RawModel.Containers;
using SkyrimCharacterParser.RawModel.GlobalDataTypes;

namespace SkyrimCharacterParser.RawModel
{
    public class SkyrimSavegame
    {
        public String label;

        public Header header;

        public byte formVersion;

        public FileLocationTable fileLocationTable;

        public GlobalDataType[] globalDataTable1; //Types 0 to 8.
        public GlobalDataType[] globalDataTable2; //Types 100 to 114.

        public SkyrimSavegame(String label)
        {
            this.label = label;
        }

        public String GetSkyrimVersion()
        {
            switch (formVersion)
            {
                case 57:
                    return "1.1.21";
                default:
                    return "unknown";
            }
        }

        public String GetPlayerName()
        {
            return header.playerName;
        }

        public String GetPlayerRace()
        {
            return header.playerRaceEditorID;
        }

        public String GetPlayerLocation()
        {
            return header.playerLocation;
        }

        public String GetLabel()
        {
            return label;
        }

        public int GetNumber()
        {
            return (int) header.saveNumber;
        }

        public DateTime GetSaveTime()
        {
            return header.GetSaveTime();
        }

        public int GetPlayerLevel()
        {
            return (int) header.playerLevel;
        }

        public IEnumerable<MiscStat> GetMiscStats()
        {
            List<MiscStat> stats = new List<MiscStat>();
            foreach (var gtype in globalDataTable1)
            {
                if (gtype is MiscStats)
                {
                    MiscStats miscStats = gtype as MiscStats;
                    stats.AddRange(miscStats.stats);
                }
            }
            return stats;
        }
    }
}
