using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using SkyrimCharacterParser.RawModel.Factories;
using SkyrimCharacterParser.RawModel.Containers;
using SkyrimCharacterParser.RawModel.GlobalDataTypes;

namespace SkyrimCharacterParser.RawModel.Reader
{
    public class SkyrimSavegameReader
    {
        private GlobalDataTypeFactory[] gtypeFactories = { new MiscStatsFactory(), new GlobalDataStubFactory() };

        private SkyrimBinaryReader br;

        public IEnumerable<SkyrimSavegame> Read(DirectoryInfo savePath)
        {
            List<SkyrimSavegame> savegames = new List<SkyrimSavegame>();

            FileInfo[] files = savePath.GetFiles("*.ess");
            foreach (var fileInfo in files)
            {
                if (fileInfo.Name.Contains("autosave") || fileInfo.Name.Contains("quicksave"))
                {
                    continue;
                }

                Debug.Print("******* " + fileInfo.Name + "***********");
                using (FileStream fs = fileInfo.Open(FileMode.Open))
                {
                    SkyrimSavegame sg = Read(fileInfo.Name, fs);
                    savegames.Add(sg);
                }
                Debug.Print("************************************");
            }

            return savegames;
        }

        public SkyrimSavegame Read(String label, FileStream fileStream)
        {
            br = new SkyrimBinaryReader(fileStream);

            char[] magic = br.ReadChars(13);

            UInt32 headerSize = br.ReadUInt32();

            Print("magic", new string(magic));
            Print("headerSize", headerSize);

            Header header = ReadHeader();
            header.Print();
            ReadScreenshot(header);

            byte formVersion = br.ReadByte(); //uint8
            UInt32 pluginInfoSize = br.ReadUInt32();

            Print("formVersion", formVersion);
            Print("pluginInfoSize", pluginInfoSize);

            //PluginInfo pluginInfo = ReadPluginInfo();

            //skip pluginInfo
            br.ReadBytes((int) pluginInfoSize);

            FileLocationTable fileLocationTable = ReadFileLocationTable();
            fileLocationTable.Print();

            GlobalDataType[] globalDataTable1 = ReadGlobalDataTable(9); //Types 0 to 8.
            //GlobalDataType[] globalDataTable2 = ReadGlobalDataTable(15); //Types 100 to 114.


            SkyrimSavegame savegame = new SkyrimSavegame(label);
            savegame.header = header;
            savegame.formVersion = formVersion;
            savegame.fileLocationTable = fileLocationTable;
            savegame.globalDataTable1 = globalDataTable1;
            //savegame.globalDataTable2 = globalDataTable2;

            foreach (var ms in savegame.GetMiscStats().OrderBy(p => p.category).ThenBy(n => n.name))
            {
                Print("stats", "cat({0}).{1} = {2}", ms.category, ms.name, ms.value);
            }

            return savegame;
        }

        private Header ReadHeader()
        {
            Header h = new Header();

            h.version = br.ReadUInt32();
            h.saveNumber = br.ReadUInt32();
            h.playerName = br.ReadWString();
            h.playerLevel = br.ReadUInt32();
            h.playerLocation = br.ReadWString();
            h.gameDate = br.ReadWString();
            h.playerRaceEditorID = br.ReadWString();

            h.unknown1 = br.ReadUInt16();
            h.unknown2float32 = br.ReadBytes(4);
            h.unknown3float32 = br.ReadBytes(4);

            h.filetime = new FILETIME();
            h.filetime.dwLowDateTime = br.ReadInt32();
            h.filetime.dwHighDateTime = br.ReadInt32();
            
            h.shotWidth = br.ReadUInt32();
            h.shotHeight = br.ReadUInt32();

            return h;
        }

        private PluginInfo ReadPluginInfo()
        {
            PluginInfo pi = new PluginInfo();

            pi.pluginCount = br.ReadByte();

            return pi;
        }

        private FileLocationTable ReadFileLocationTable()
        {
            FileLocationTable flt = new FileLocationTable();

            flt.formIDArrayCount = br.ReadUInt32();
            flt.unknownTable3Offset = br.ReadUInt32();
            flt.globalDataTable1Offset = br.ReadUInt32();
            flt.globalDataTable2Offset = br.ReadUInt32();
            flt.changedFormsOffset = br.ReadUInt32();
            flt.globalDataTable3Offset = br.ReadUInt32();
            flt.globalDataTable1Count = br.ReadUInt32();
            flt.globalDataTable2Count = br.ReadUInt32();
            flt.globalDataTable3Count = br.ReadUInt32();
            flt.changedFormCount = br.ReadUInt32();

            flt.unused = new uint[15];
            for (int i = 0; i < flt.unused.Length; i++)
            {
                flt.unused[i] = br.ReadUInt32();
            }

            return flt;
        }


        private GlobalDataType[] ReadGlobalDataTable(int tableSize)
        {
            GlobalDataType[] gtab = new GlobalDataType[tableSize];
            for (int i = 0; i < tableSize; i++)
            {
                GlobalData gd = new GlobalData();
                gd.type = br.ReadUInt32();
                gd.length = br.ReadUInt32();
                gd.data = br.ReadBytes((int)gd.length);

                gtab[i] = ParseGlobalData(gd);
            }

            return gtab;
        }


        private GlobalDataType ParseGlobalData(GlobalData gd)
        {
            foreach (var factory in gtypeFactories)
            {
                if (factory.CanBuild(gd))
                {
                    return factory.BuildType(gd);
                }
            }
            throw new ArgumentException("unknown global data type: " + gd.type);
        }

        private void ReadScreenshot(Header h)
        {
            int pixelCount = (int) (3*h.shotWidth*h.shotHeight);
            byte[] rgbPixelData = br.ReadBytes(pixelCount);

            /*
            FileStream fout = new FileStream("d:/temp/skyshot.bmp", FileMode.Create);
            fout.Write(rgbPixelData, 0, pixelCount);
            fout.Flush();
            fout.Close();
            */
        }


        private void Print(string varName, object msg, params object[] args)
        {
            string s = varName + " : " + string.Format(msg.ToString(), args);
            Debug.Print(s);
            //Console.WriteLine(s);
        }

    }
}
