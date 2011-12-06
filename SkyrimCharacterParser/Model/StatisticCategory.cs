using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyrimCharacterParser.Model
{
    public class StatisticCategory
    {
        private StatisticCategoryType categoryType;
        private List<String> items;

        public StatisticCategory(StatisticCategoryType categoryType)
        {
            this.categoryType = categoryType;
            this.items = new List<String>();
        }

        public StatisticCategoryType CategoryType
        {
            get { return categoryType; }
        }

        public String Name
        {
            get { return Enum.GetName(typeof(StatisticCategoryType), this.categoryType); }
        }

        public IEnumerable<String> Items
        {
            get { return items; }
        }

        private void AddItem(String item)
        {
            this.items.Add(item);
        }



        public static readonly StatisticCategory General;
        public static readonly StatisticCategory Quest;
        public static readonly StatisticCategory Combat;
        public static readonly StatisticCategory Magic;
        public static readonly StatisticCategory Crafting;
        public static readonly StatisticCategory Crime;
        static StatisticCategory()
        {
            #region General
            General = new StatisticCategory(StatisticCategoryType.General);
            General.AddItem("Barters");
            General.AddItem("Books Read");
            General.AddItem("Bribes");
            General.AddItem("Chests Looted");
            General.AddItem("Days as a Vampire");
            General.AddItem("Days as a Werewolf");
            General.AddItem("Days Passed");
            General.AddItem("Diseases Contracted");
            General.AddItem("Dungeons Cleared");
            General.AddItem("Food Eaten");
            General.AddItem("Gold Found");
            General.AddItem("Horses Owned");
            General.AddItem("Hours Slept");
            General.AddItem("Hours Waiting");
            General.AddItem("Houses Owned");
            General.AddItem("Intimidations");
            General.AddItem("Locations Discovered");
            General.AddItem("Mauls");
            General.AddItem("Most Gold Carried");
            General.AddItem("Necks Bitten");
            General.AddItem("Persuasions");
            General.AddItem("Skill Books Read");
            General.AddItem("Skill Increases");
            General.AddItem("Standing Stones Found");
            General.AddItem("Stores Invested In");
            General.AddItem("Training Sessions");
            General.AddItem("Vampirism Cures");
            General.AddItem("Werewolf Transformations");
            #endregion

            #region Quest
            Quest = new StatisticCategory(StatisticCategoryType.Quest);
            Quest.AddItem("Civil War Quests Completed");
            Quest.AddItem("College of Winterhold Quests Completed");
            Quest.AddItem("Daedric Quests Completed");
            Quest.AddItem("Main Quests Completed");
            Quest.AddItem("Misc Objectives Completed");
            Quest.AddItem("Questlines Completed");
            Quest.AddItem("Quests Completed");
            Quest.AddItem("Side Quests Completed");
            Quest.AddItem("The Companions Quests Completed");
            Quest.AddItem("The Dark Brotherhood Quests Completed");
            Quest.AddItem("Thieves' Guild Quests Completed");
            #endregion

            #region Combat
            Combat = new StatisticCategory(StatisticCategoryType.Combat);
            Combat.AddItem("Animals Killed");
            Combat.AddItem("Automatons Killed");
            Combat.AddItem("Backstabs");
            Combat.AddItem("Brawls Won");
            Combat.AddItem("Bunnies Slaughtered");
            Combat.AddItem("Creatures Killed");
            Combat.AddItem("Critical Strikes");
            Combat.AddItem("Daedra Killed");
            Combat.AddItem("Favorite Weapon");
            Combat.AddItem("People Killed");
            Combat.AddItem("Sneak Attacks");
            Combat.AddItem("Undead Killed");
            Combat.AddItem("Weapons Disarmed");
            #endregion

            #region Magic
            Magic = new StatisticCategory(StatisticCategoryType.Magic);
            Magic.AddItem("Dragon Souls Collected");
            Magic.AddItem("Favorite School");
            Magic.AddItem("Favorite Shout");
            Magic.AddItem("Favorite Spell");
            Magic.AddItem("Shouts Learned");
            Magic.AddItem("Shouts Mastered");
            Magic.AddItem("Shouts Unlocked");
            Magic.AddItem("Spells Learned");
            Magic.AddItem("Times Shouted");
            Magic.AddItem("Words Of Power Learned");
            Magic.AddItem("Words Of Power Unlocked");
            #endregion

            #region Crafting
            Crafting = new StatisticCategory(StatisticCategoryType.Crafting);
            Crafting.AddItem("Armor Improved");
            Crafting.AddItem("Armor Made");
            Crafting.AddItem("Ingredients Eaten");
            Crafting.AddItem("Ingredients Harvested");
            Crafting.AddItem("Magic Items Made");
            Crafting.AddItem("Nirnroots Found");
            Crafting.AddItem("Poisons Mixed");
            Crafting.AddItem("Poisons Used");
            Crafting.AddItem("Potions Mixed");
            Crafting.AddItem("Potions Used");
            Crafting.AddItem("Soul Gems Used");
            Crafting.AddItem("Souls Trapped");
            Crafting.AddItem("Weapons Improved");
            Crafting.AddItem("Weapons Made");
            Crafting.AddItem("Wings Plucked");
            #endregion

            #region Crime
            Crime = new StatisticCategory(StatisticCategoryType.Crime);
            Crime.AddItem("Assaults");
            Crime.AddItem("Days Jailed");
            Crime.AddItem("Eastmarch Bounty");
            Crime.AddItem("Falkreath Bounty");
            Crime.AddItem("Fines Paid");
            Crime.AddItem("Haafingar Bounty");
            Crime.AddItem("Hjaalmarch Bounty");
            Crime.AddItem("Horses Stolen");
            Crime.AddItem("Items Pickpocketed");
            Crime.AddItem("Items Stolen");
            Crime.AddItem("Jail Escapes");
            Crime.AddItem("Largest Bounty");
            Crime.AddItem("Locks Picked");
            Crime.AddItem("Murders");
            Crime.AddItem("Pockets Picked");
            Crime.AddItem("The Pale Bounty");
            Crime.AddItem("The Reach Bounty");
            Crime.AddItem("The Rift Bounty");
            Crime.AddItem("Times Jailed");
            Crime.AddItem("Total Lifetime Bounty");
            Crime.AddItem("Trespasses");
            Crime.AddItem("Tribal Orcs Bounty");
            Crime.AddItem("Whiterun Bounty");
            Crime.AddItem("Winterhold Bounty");
            #endregion
        }


    }

    
}
