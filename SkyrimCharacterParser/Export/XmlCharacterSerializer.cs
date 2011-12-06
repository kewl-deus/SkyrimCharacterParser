using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using SkyrimCharacterParser.Model;

namespace SkyrimCharacterParser.Export
{
    public class XmlCharacterSerializer : CharacterSerializer
    {

        public override void Write(CharacterList characterList, StreamWriter writer)
        {
            XmlSerializer xs = new XmlSerializer(typeof(CharacterList));
            XmlUtils.SetSpecifiedFlags(characterList, true);

            foreach (var skyrimCharacter in characterList.Character)
            {
                XmlUtils.SetSpecifiedFlags(skyrimCharacter, true);
                foreach (var snap in skyrimCharacter.Snapshot)
                {
                    XmlUtils.SetSpecifiedFlags(snap, true);
                    if (snap.StatisticValue != null)
                    {
                        foreach (var statItem in snap.StatisticValue)
                        {
                            XmlUtils.SetSpecifiedFlags(statItem, true);
                        }
                    }
                }
            }

            xs.Serialize(writer, characterList);
        }

        private XmlReaderSettings CreateXmlReaderSettings()
        {
            Assembly asm = Assembly.GetAssembly(typeof(Character));

            Stream playerXsdStream = asm.GetManifestResourceStream("SkyrimCharacterParser.Model.skyrimcharacter.xsd");
            XmlReader playerXsdReader = XmlReader.Create(playerXsdStream);


            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.ValidationType = ValidationType.Schema;
            xmlSettings.Schemas.Add("http://www.elderscrolls.com/skyrim/player", playerXsdReader);

            return xmlSettings;
        }

        public void Validate(Stream stream)
        {
            XmlReader xmlReader = XmlReader.Create(stream, CreateXmlReaderSettings());
            while(xmlReader.Read())
            {
                //throws System.Xml.XmlException on validation error
            }
            xmlReader.Close();
        }
    }
}
