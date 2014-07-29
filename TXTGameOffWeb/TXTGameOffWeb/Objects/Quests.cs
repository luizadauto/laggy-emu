using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TXTGameOffWeb.Objects
{
    public class Quests : Player
    {
        private static int questType;
        private static int currentQuestID;
        private static string questString1 = "You have killed a quest monster.";
        private static string questString2 = "You have collected a ";
        private static string questString3 = "You currently do not have a quest";

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
