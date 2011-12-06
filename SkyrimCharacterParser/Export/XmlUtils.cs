using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SkyrimCharacterParser.Export
{
    public static class XmlUtils
    {
        public static void SetSpecifiedFlags(object obj, Boolean flagValue)
        {
            IEnumerable<PropertyInfo> specifiedFlagProperties = obj.GetType().GetProperties().Where(
                p => p.Name.EndsWith("Specified") && p.PropertyType == typeof(bool));

            foreach (var specifiedFlagProperty in specifiedFlagProperties)
            {
                specifiedFlagProperty.SetValue(obj, flagValue, null);
            }
        }

    }
}
