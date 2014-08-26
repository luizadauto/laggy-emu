using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TXTGameOffWeb.Objects
{
    public class Quests
    {
        private static string name;
        private static int questType;
        private static int currentQuestID;
        private static int noOfKills;
        private static int noOfMobs;
        private static int noOfDrops;        
        private static int noOfItems;
        private static string questString1 = "You have killed a quest monster.";
        private static string questString2 = "You have collected a ";
        private static string questString3 = "You currently do not have a quest";

        public void LoadPlayerQuest()
        {
            var data = File.ReadAllLines("PlayerQuestInfo.txt")
                .Select(x => x.Split('='))
                .Where(x => x.Length > 1)
                .ToDictionary(x => x[0].Trim(), x => x[1]);
            //[Player]
            this.Name = data["Name"];
            this.GetCurrentQuest = Convert.ToInt16(data["QuestID"]);
            this.QuestType = Convert.ToInt16(data["QuestType"]);
            this.NumberOfKills = Convert.ToInt16(data["NoOfKills"]);
            this.NumberOfMobs = Convert.ToInt16(data["NoOfMobs"]);
            this.NumberOfDrops = Convert.ToInt16(data["NoOfDrops"]);
            this.NumberOfItems = Convert.ToInt16(data["NoOfItems"]);   
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int QuestType
        {
            get { return questType; }
            set { questType = value; }
        }

        public int GetCurrentQuest
        {
            get { return currentQuestID; }
            set { currentQuestID = value; }
        }

        public int NumberOfKills
        {
            get { return noOfKills; }
            set { noOfKills = value; }
        }

        public int NumberOfMobs
        {
            get { return noOfMobs; }
            set { noOfMobs = value; }
        }

        public int NumberOfDrops
        {
            get { return noOfDrops; }
            set { noOfDrops = value; }
        }

        public int NumberOfItems
        {
            get { return noOfItems; }
            set { noOfItems = value; }
        }

        public void QuestSeclector()
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                questType = 0;
            }
            else
            {
                questType = 1;
            }
        }

        public void QuestUpdate()
        {
            Player player = new Player();
            Monster mob = new Monster();
            questType = player.CurrentQuest;
            switch (questType)
            {
                case 1:
                    GetKillQuest(mob.MonsterName);
                    break;
                case 2:
                    GetCollectQuest();
                    break;
                case 3:
                    questType = 3;
                    break;
                default:
                    break;
            }
        }

        public void GetKillQuest(string monsterName)
        {

        }

        public void GetCollectQuest()
        {

        }
    }
}
