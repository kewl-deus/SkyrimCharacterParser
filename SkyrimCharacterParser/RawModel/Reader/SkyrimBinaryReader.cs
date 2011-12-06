using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SkyrimCharacterParser.RawModel.Reader
{
    public class SkyrimBinaryReader : BinaryReader
    {
        public SkyrimBinaryReader(Stream input) : base(input)
        {
        }

        public SkyrimBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public string ReadWString()
        {
            UInt16 len = ReadUInt16();
            char[] chars = ReadChars(len);
            return new string(chars);
        }
    }
}
