using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TXTGameOffWeb.Objects
{
    public class Dropper : Player
    {
        private static int mPlatinum;
        private static int mGold;
        private static int mSilver;
        private static int mCopper;
        private static int mJade;
        private static int mTokens;

        public int DropPlatinum
        {
            get { return mPlatinum; }
            set { mPlatinum = value; }
        }

        public int DropGold
        {
            get { return mGold; }
            set { mGold = value; }
        }

        public int DropSilver
        {
            get { return mSilver; }
            set { mSilver = value; }
        }

        public int DropCopper
        {
            get { return mCopper; }
            set { mCopper = value; }
        }

        public int DropJade
        {
            get { return mJade; }
            set { mJade = value; }
        }

        public int DropTokens
        {
            get { return mTokens; }
            set { mTokens = value; }
        }


        public void DropItem(string monsterName)
        {
            Player player = new Player();
            Monster mob = new Monster();

            if (monsterName == mob.MonsterName)
            {
                if (player.Gold >= 100)
                {
                    player.Gold = player.Gold - 100;
                    player.Platinum++;
                }
                if (player.Silver >= 100)
                {
                    player.Silver = player.Silver - 100;
                    player.Gold++;
                }
                if (player.Copper >= 100)
                {
                    player.Copper = player.Copper - 100;
                }
            }
            else
            {
                Battle battle = new Battle();
                battle.SendMessage = "error with dropper";
            }


        }
    }
}
