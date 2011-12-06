using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyrimCharacterParser.Model
{
    public partial class CharacterSnapshot
    {
        public int GetStatisticValue(StatisticCategory cat, string name)
        {
            if (StatisticValue == null)
            {
                return 0;
            }

            var sv = StatisticValue.FirstOrDefault(s => s.CategoryId == ((int)cat.CategoryType) && s.Name == name);
            if (sv == null)
            {
                return 0;
            }
            return sv.Value;
        }
    }
}
