using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkyrimCharacterParser.Model;
using SkyrimCharacterParser.RawModel;

namespace SkyrimCharacterParser
{
    public class CharacterParser
    {
        private Dictionary<string, Character> parsedCharacters;

        public CharacterList ParseCharacters(params SkyrimSavegame[] savegames)
        {
            parsedCharacters = new Dictionary<string, Character>();

            foreach (var sg in savegames)
            {
                Character skyrimPlayer;
                string name = sg.GetPlayerName();
                if (parsedCharacters.ContainsKey(name))
                {
                    skyrimPlayer = parsedCharacters[name];
                }
                else
                {
                    skyrimPlayer = new Character();
                    skyrimPlayer.Name = name;
                    skyrimPlayer.Race = sg.GetPlayerRace();
                    parsedCharacters[name] = skyrimPlayer;
                }
                CharacterSnapshot snap = ParseCharacterSnapshot(sg);
                List<CharacterSnapshot> snaps = new List<CharacterSnapshot>();
                if (skyrimPlayer.Snapshot != null)
                {
                    snaps.AddRange(skyrimPlayer.Snapshot);
                }
                snaps.Add(snap);
                skyrimPlayer.Snapshot = snaps.ToArray();
            }

            CharacterList charList = new CharacterList();
            charList.Character = parsedCharacters.Values.ToArray();
            foreach (Character c in charList.Character)
            {
                c.Snapshot = c.Snapshot.OrderBy(snap => snap.Id).ToArray();
            }
            return charList;
        }

    

        private CharacterSnapshot ParseCharacterSnapshot(SkyrimSavegame savegame)
        {
            CharacterSnapshot snap = new CharacterSnapshot();
            snap.Id = savegame.GetNumber();
            snap.Label = savegame.GetLabel();
            snap.SaveTime = savegame.GetSaveTime();
            snap.Level = savegame.GetPlayerLevel();
            snap.Location = savegame.GetPlayerLocation();

            snap.StatisticValue = ParseStats(savegame);

            return snap;
        }

        private StatisticValue[] ParseStats(SkyrimSavegame savegame)
        {
            List<StatisticValue> stats = new List<StatisticValue>();
            var orderedMiscStats = savegame.GetMiscStats().OrderBy(p => p.category).ThenBy(n => n.name);
            foreach (var ms in orderedMiscStats)
            {
                StatisticValue sv = new StatisticValue();

                StatisticCategoryType catType = (StatisticCategoryType) ms.category;

                sv.CategoryId = (int)catType;
                sv.Name = ms.name;
                sv.Value = ms.value;

                stats.Add(sv);
            }
            return stats.ToArray();
        }
    }
}
