using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyrimCharacterParser.Model;
using System.IO;

namespace SkyrimCharacterParser.Export
{
    public abstract class CharacterSerializer
    {
        public abstract void Write(CharacterList characterList, StreamWriter writer);

        public virtual void Write(CharacterList characterList, string fileLocation)
        {
            StreamWriter writer = new StreamWriter(fileLocation);
            Write(characterList, writer);
            writer.Flush();
            writer.Close();
        }
    }
}
