using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTGameOffWeb.Objects
{
    public class Trainer : Player
    {
        private static int startEXP;
        private static int[] _expToLevel;

        public int[] ExperienceToLevel
        {
            get { return _expToLevel;}
            set { _expToLevel = value;}
        }

        public void SetDefaultNeedExp()
        {
            int i = 1;
            while (i <= 100)
            {
                i++;
                startEXP = startEXP + 50;
                ExperienceToLevel[i] = startEXP;
            }
        }

        public void TrainStats()
        {
            Player player = new Player();
            int hp, atk, def;
            float eva, acc;
            hp = player.Health;
            atk = player.Attack;
            def = player.Defence;
            acc = player.Accuracy;
            eva = player.Evasion;

            int[] stats = new int[] { hp, atk, def, Convert.ToInt16(acc), Convert.ToInt16(eva) };

            Random rand = new Random();

            int chose = rand.Next(0, stats.Length);

            chose = chose++;
        }

        public void AddExperience(int giveExp)
        {
            Player player = new Player();
            int currentEXP = player.Experience;
            
            for (int i  = 0; i < this.ExperienceToLevel[player.Level]; i++)
            {
                currentEXP += giveExp;
                if (currentEXP == this.ExperienceToLevel[player.Level])
                {
                    LevelUp(giveExp, currentEXP);
                }
            }
        }

        public void LevelUp(int remainingEXP, int currentEXP)
        {
            Player player = new Player();

            int total = player.Experience + remainingEXP;

            if (total >= currentEXP)
            {
                // while players experience less than maxXP add remainingXP
                // till players experience equal to maxXP
                for (int i = player.Experience; i < currentEXP; i++)
                {
                    player.Experience++;                
                    player.Experience = player.Experience + remainingEXP;  
                }
            }                   
            player.Level++;
            player.Experience = 0;
        }
    }
}
