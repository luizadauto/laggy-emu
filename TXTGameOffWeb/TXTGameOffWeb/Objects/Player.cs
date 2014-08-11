using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TXTGameOffWeb.Objects
{
    public class Player
    {
        // Text file layout
        // [Player]
        private static string name;
        private static int level;
        private static int exp;
        private static string guild;
        private static int guildlvl;
        private static int rep;
        private static string rank;
        // [Stats]
        private static int endurance;
        private static int HP;
        private static int origPlayerHP;
        private static int attack;
        private static int defence;
        private static float acc;
        private static float eva;
        // [Currencies]
        private static int platinum;
        private static int gold;
        private static int silver;
        private static int copper;
        private static int jade;
        private static int tokens;
        private static int prizeTickets;
        private static int diamonds;
        private static int sapphires;
        private static int rubies;
        private static int emeralds;
        private static int opals;
        // [Quests]
        private static int currentQuest;
        private static int qCompleted;
        private static int mKills;
        private static int QCount;
        private static int MaxQCount;
        // [Equipment]
        private static string weapon1;
        private static string weapon2;
        private static string head;
        private static string hands;
        private static string wrist;
        private static string arm;
        private static string chestarmor;
        private static string legs;
        private static string feet;
        private static string necklace;
        private static string ring1;
        private static string ring2;
        private static string ring3;
        private static string ring4;
        private static string brace1;
        private static string brace2;

        #region Player
        public string Name
        {
            get { return name; }
            set { name = value; }
            
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Experience
        {
            get { return exp; }
            set { exp = value; }
        }

        public string GuildName
        {
            get { return guild; }
            set { guild = value; }
        }

        public int GuildLevel
        {
            get { return guildlvl; }
            set { guildlvl = value; }
        }

        public int Rep
        {
            get { return rep; }
            set { rep = value; }
        }

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        #endregion

        #region Stats

        public int Endurance
        {
            get { return endurance; }
            set { endurance = value; }
        }

        public int Health
        {
            get { return HP; }
            set { HP = value; }
        }

        public int OrigPlayerHP
        {
            get { return origPlayerHP; }
            set { origPlayerHP = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }

        public float Accuracy
        {
            get { return acc; }
            set { acc = value; }
        }

        public float Evasion
        {
            get { return eva; }
            set { eva = value; }
        }

        #endregion

        #region Currencies
        public int Platinum
        {
            get { return platinum; }
            set { platinum = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public int Silver
        {
            get { return silver; }
            set { silver = value; }
        }

        public int Copper
        {
            get { return copper; }
            set { copper = value; }
        }

        public int Jade
        {
            get { return jade; }
            set { jade = value; }
        }

        public int Tokens
        {
            get { return tokens; }
            set { tokens = value; }
        }

        public int PrizeTickets
        {
            get { return prizeTickets; }
            set { prizeTickets = value; }
        }

        public int Diamonds
        {
            get { return diamonds; }
            set { diamonds = value; }
        }

        public int Sapphires
        {
            get { return sapphires; }
            set { sapphires = value; }
        }

        public int Rubies
        {
            get { return rubies; }
            set { rubies = value; }
        }

        public int Emeralds
        {
            get { return emeralds; }
            set { emeralds = value; }
        }

        public int Opals
        {
            get { return opals; }
            set { opals = value; }
        }

        #endregion

        #region Quests

        public int CurrentQuest
        {
            get { return currentQuest; }
            set { currentQuest = value; }
        }

        public int QuestsCompleted
        {
            get { return qCompleted; }
            set { qCompleted = value; }
        }

        public int MonstersKilled
        {
            get { return mKills; }
            set { mKills = value; }
        }

        public int QuestAmount
        {
            get { return QCount; }
            set { QCount = value; }
        }

        public int MaxQuestAmount
        {
            get { return MaxQCount; }
            set { MaxQCount = value; }
        }

        #endregion

        #region Equipment

        public string Weapon1
        {
            get { return weapon1; }
            set { weapon1 = value; }
        }

        public string Weapon2
        {
            get { return weapon2; }
            set { weapon2 = value; }
        }

        public string Hands
        {
            get { return hands; }
            set { hands = value; }
        }

        public string Head
        {
            get { return head; }
            set { head = value; }
        }

        public string Wrist
        {
            get { return wrist; }
            set { wrist = value; }
        }

        public string Arm
        {
            get { return arm; }
            set { arm = value; }
        }

        public string ChestArmor
        {
            get { return chestarmor; }
            set { chestarmor = value; }
        }

        public string Legs
        {
            get { return legs; }
            set { legs = value; }
        }

        public string Feet
        {
            get { return feet; }
            set { feet = value; }
        }

        public string Necklace
        {
            get { return necklace; }
            set { necklace = value; }
        }

        public string Ring1
        {
            get { return ring1; }
            set { ring1 = value; }
        }

        public string Ring2
        {
            get { return ring2; }
            set { ring2 = value; }
        }

        public string Ring3
        {
            get { return ring3; }
            set { ring3 = value; }
        }

        public string Ring4
        {
            get { return ring4; }
            set { ring4 = value; }
        }

        public string Brace1
        {
            get { return brace1; }
            set { brace1 = value; }
        }

        public string Brace2
        {
            get { return brace2; }
            set { brace2 = value; }
        }

        #endregion

        public void PlayerDestroy()
        {
            this.Name = "";
            this.Level = 0;
            this.Experience = 0;
            this.GuildName = "";
            this.GuildLevel = 0;
            this.Rep = 0;
            this.Rank = "";
            // [Stats]
            this.Endurance = 0;
            this.Health = 0;
            this.OrigPlayerHP = 0;
            this.Attack = 0;
            this.Defence = 0;
            this.Accuracy = 0.0f;
            this.Evasion = 0.0f;
            // [Currencies]
            this.Platinum = 0;
            this.Gold = 0;
            this.Silver = 0;
            this.Copper = 0;
            this.Jade = 0;
            this.Tokens = 0;
            this.PrizeTickets = 0;
            this.Diamonds = 0;
            this.Sapphires = 0;
            this.Rubies = 0;
            this.Emeralds = 0;
            this.Opals = 0;
            // [Quests]        
            this.MonstersKilled = 0;
            // [Equipment]
            this.Weapon1 = "";
            this.Weapon2 = "";
            this.Head = "";
            this.Hands = "";
            this.Wrist = "";
            this.Arm = "";
            this.ChestArmor = "";
            this.Legs = "";
            this.Feet = "";
            this.Necklace = "";
            this.Ring1 = "";
            this.Ring2 = "";
            this.Ring3 = "";
            this.Ring4 = "";
            this.Brace1 = "";
            this.Brace2 = "";
        }
    }
}
