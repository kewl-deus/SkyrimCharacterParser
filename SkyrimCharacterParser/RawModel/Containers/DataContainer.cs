using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SkyrimCharacterParser.RawModel.Containers
{
    public abstract class DataContainer
    {
        protected virtual void Print(string varName, object msg, params object[] args)
        {
            string s = GetType().Name + "." + varName + " = " + string.Format(msg.ToString(), args);
            Debug.Print(s);
            //Console.WriteLine(s);
        }

        public abstract void Print();
    }
}
