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
            try
            {
                var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string savegamePath = Path.Combine(myDocuments, "my games","Skyrim","Saves");
                if (args.Length > 0)
                {
                    savegamePath = args[0];
                }
                
                string outputFilePath = "mySkyrimCharacters.xml";
                if (args.Length > 1)
                {
                    outputFilePath = args[1];
                }

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
