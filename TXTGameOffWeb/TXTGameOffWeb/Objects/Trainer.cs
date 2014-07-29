using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTGameOffWeb.Objects
{
    public class Trainer : Player
    {
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
            int exp = player.Experience;
            int[] expToLvl = new int[] { 100, 110, 120, 130, 150, 175, 200, 235, 275, 325, 400, 475, 550, 625, 750 };
            int lvl = player.Level;
            
            if (exp >= expToLvl[lvl])
            {
                LevelUp(giveExp, expToLvl[lvl]);                
            }
            else
            {
                player.Experience = player.Experience + giveExp;
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
