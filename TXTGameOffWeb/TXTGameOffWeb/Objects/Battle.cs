using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTGameOffWeb.Objects
{
    /*
     * 
     *              TO DO 
     *              
     *              Calculations of Accuracy, Evasion and Health
     *              Experience table for player in order for the player to increase level | PlayerExp.txt
     *              Drop event (Random drops & Quest drops | Dropper)
     *              Health, Attack, Defence, Accuracy and Evasion training (May add it's own class | Trainer.cs)              
     * 
     */


    public class Battle
    {
        private static int damageTaken;
        private static int damageDealt;
        private static int avrgDmgDealt;
        private static int avrgDmgTaken;

        private static int missTimes;
        private static int dodgeTimes;
        private static int critTimes;

        private static string victoryString = "You succsesfully defeated the monster";
        private static string defeatString = "You failed to defeat the monster";

        private static string msg;

        private static int rounds;
        private static int dmgTaken;
        private static int dmgDealt;

        private static bool battleEnd;
        private static bool battleStarted;

        private static int baseHP;
        private static int mobBaseHP;


        Player player = new Player();
        Dropper drop = new Dropper();

        public void BattleResult(string mobName)
        {            
            Monster mob = new Monster();

            BaseHP = player.Endurance * 5;
            MobBaseHP = mob.MonsterEndurance * 5;

            rounds = 0;

            TotalDamageDealt = 0;
            TotalDamageTaken = 0;

            AverageDamageDealt = 0;
            AverageDamageTaken = 0;

            if (this.BattleStarted == true)
            {
                this.BattleEnd = false;
                while (MobBaseHP >= 1 && BaseHP >= 1)
                {
                    rounds++;
                    CalculateDamageTaken();
                    CalculateDameDealt();
                }

                if (MobBaseHP <= 0)
                {
                    drop.DropItem();
                    MobBaseHP = 0;
                    this.SendMessage = victoryString;
                    this.BattleEnd = true;
                    this.BattleStarted = false;                    
                    player.MonstersKilled++;                    
                    return;
                }
                else if (BaseHP <= 0)
                {
                    BaseHP = 0;
                    this.SendMessage = defeatString;                    
                    AverageDamageDealt = TotalDamageDealt / Rounds;
                    AverageDamageTaken = TotalDamageTaken / Rounds;
                    this.BattleEnd = true;
                    this.BattleStarted = false;
                    return;
                }
            }
        }

        public void CalculateDamageTaken()
        {
            Player player = new Player();
            Monster mob = new Monster();
            int mAttack = mob.MonsterAttack;

            int flyHP;

            if (this.BattleStarted == true)
            {
                mAttack -= player.Defence;

                dmgTaken = mAttack; //
                flyHP = BaseHP - mAttack;
                BaseHP = flyHP;
                DamageTaken = mAttack;
                TotalDamageTaken = TotalDamageTaken + DamageTaken;
            }
            else
            {
                return;
            }
        }

        public void CalculateDameDealt()
        {
            Player player = new Player();
            Monster mob = new Monster();
            int pAttack = player.Attack;

            int flyHP;            
            if (this.BattleStarted == true)
            {
                pAttack -= mob.MonsterDefence;
                dmgDealt = pAttack;

                flyHP = mobBaseHP - pAttack;
                MobBaseHP = flyHP;


                DamageDealt = pAttack;
                TotalDamageDealt = TotalDamageDealt + DamageDealt;
            }
        }

        public string SendMessage
        {
            get { return msg; }
            set { msg = value;}
        }

        public int DamageTaken
        {
            get { return dmgTaken; }
            set { dmgTaken = value; }
        }

        public int DamageDealt
        {
            get { return dmgDealt; }
            set { dmgDealt = value; }
        }

        public int TotalDamageDealt
        {
            get { return damageDealt; }
            set { damageDealt = value; }
        }

        public int TotalDamageTaken
        {
            get { return damageTaken; }
            set { damageTaken = value; }
        }

        public int AverageDamageDealt
        {
            get { return avrgDmgDealt; }
            set { avrgDmgDealt = value; }
        }

        public int AverageDamageTaken
        {
            get { return avrgDmgTaken; }
            set { avrgDmgTaken = value; }
        }

        public bool BattleEnd
        {
            get { return battleEnd; }
            set { battleEnd = value; }
        }

        public bool BattleStarted
        {
            get { return battleStarted; }
            set { battleStarted = value; }
        }

        public int Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }

        public int BaseHP
        {
            get { return baseHP; }
            set { baseHP = value; }
        }

        public int MobBaseHP
        {
            get { return mobBaseHP; }
            set { mobBaseHP = value; }
        }

        public void BattleDestroy()
        {
            SendMessage = "";
            DamageTaken = 0;
            DamageDealt = 0;
            AverageDamageDealt = 0;
            AverageDamageTaken = 0;
            TotalDamageDealt = 0;
            TotalDamageTaken = 0;
            Rounds = 0;
            BattleEnd = true;
            BattleStarted = false;
            BaseHP = 0;
            MobBaseHP = 0;

        }
    }
}
