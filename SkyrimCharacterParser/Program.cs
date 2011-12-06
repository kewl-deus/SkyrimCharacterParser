using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using SkyrimCharacterParser.RawModel.Reader;
using SkyrimCharacterParser.RawModel;
using SkyrimCharacterParser.Model;
using SkyrimCharacterParser.Export;

namespace SkyrimCharacterParser
{
    public static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("usage: SkyrimParser savegamePath outputfilename.xml");
                return;
            }

            try
            {
                string savegamePath = savegamePath = args[0];
                string outputFilePath = args[1];

                Console.WriteLine("Reading savegames...");

                SkyrimSavegameReader savegameReader = new SkyrimSavegameReader();
                IEnumerable<SkyrimSavegame> savegames = savegameReader.Read(new DirectoryInfo(savegamePath));

                Console.WriteLine("Parsing characters...");

                CharacterParser characterParser = new CharacterParser();
                CharacterList characterList = characterParser.ParseCharacters(savegames.ToArray());

                Console.WriteLine("Exporting to XML...");
                XmlCharacterSerializer xmlSerializer = new XmlCharacterSerializer();
                xmlSerializer.Write(characterList, outputFilePath);

                Console.WriteLine("Exporting to CSV...");
                CsvCharacterSerializer csvSerializer = new CsvCharacterSerializer();
                csvSerializer.Write(characterList, outputFilePath.Replace(".xml", ".csv"));

                Console.WriteLine("FINISHED");

                //Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
