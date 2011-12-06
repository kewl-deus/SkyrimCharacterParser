using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SkyrimCharacterParser.Model;

namespace SkyrimCharacterParser.Export
{
    public class CsvCharacterSerializer : CharacterSerializer
    {
        public override void Write(CharacterList characterList, StreamWriter writer)
        {
            string headLine = "Character;SaveGameId;SaveGameLabel;Level;Location;SavingTime;";
            writer.Write(headLine);
            WriteCategoryToHeadline(StatisticCategory.General, writer);
            WriteCategoryToHeadline(StatisticCategory.Quest, writer);
            WriteCategoryToHeadline(StatisticCategory.Combat, writer);
            WriteCategoryToHeadline(StatisticCategory.Magic, writer);
            WriteCategoryToHeadline(StatisticCategory.Crafting, writer);
            WriteCategoryToHeadline(StatisticCategory.Crime, writer);
            writer.WriteLine();

            foreach (var skyrimCharacter in characterList.Character)
            {
                Write(skyrimCharacter, writer);
            }
        }

        private void Write(Character character, StreamWriter writer)
        {
            foreach (var snap in character.Snapshot)
            {
                string snapLine = character.Name + ";" + snap.Id + ";" + snap.Label + ";" + snap.Level + ";" + snap.Location + ";" +
                                  snap.SaveTime + ";";
                writer.Write(snapLine);

                WriteStatValues(snap, StatisticCategory.General, writer);
                WriteStatValues(snap, StatisticCategory.Quest, writer);
                WriteStatValues(snap, StatisticCategory.Combat, writer);
                WriteStatValues(snap, StatisticCategory.Magic, writer);
                WriteStatValues(snap, StatisticCategory.Crafting, writer);
                WriteStatValues(snap, StatisticCategory.Crime, writer);
                writer.WriteLine();
            }
        }

        private void WriteCategoryToHeadline(StatisticCategory cat, TextWriter writer)
        {
            foreach (var statName in cat.Items)
            {
                writer.Write(statName);
                writer.Write(";");
            }
        }

        private void WriteStatValues(CharacterSnapshot snap, StatisticCategory cat, TextWriter writer)
        {
            foreach (var statName in cat.Items)
            {
                int statVal = snap.GetStatisticValue(cat, statName);
                writer.Write(statVal);
                writer.Write(";");
            }
        }
    }
}
