using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TXTGameOffWeb.Objects
{
    public class Monster : Player
    {
        private static string mName;
        private static int mEndurance;            
        private static int mHealth;
        private static int mAttack;
        private static int mDefence;
        private static float mAccuracy;
        private static float mEvasion;
        private static int mExp;
        private static int mPlat;            
        private static int mGold;        
        private static int mSilver;        
        private static int mCopper;        
        private static int mToken;                            
        private static int mMinJade;        
        private static int mMaxJade;
        private static int origMobHP;

        public string MonsterName
        {
            get { return mName; }
            set { mName = value; }
        }

        public int MonsterEndurance
        {
            get { return mEndurance; }
            set { mEndurance = value; }
        }

        public int MonsterHealth
        {
            get { return mHealth; }
            set { mHealth = value; }
        }

        public int OrigMonsterHealth
        {
            get { return origMobHP; }
            set { origMobHP = value; }
        }

        public int MonsterAttack
        {
            get { return mAttack; }
            set { mAttack = value; }
        }

        public int MonsterDefence
        {
            get { return mDefence; }
            set { mDefence = value; }
        }

        public float MonsterAccuracy
        {
            get { return mAccuracy; }
            set { mAccuracy = value; }
        }

        public float MonsterEvasion
        {
            get { return mEvasion; }
            set { mEvasion = value; }
        }

        public int MonsterExperience
        {
            get { return mExp; }
            set { mExp = value; }
        }

        public int MonsterPlatinum
        {
            get { return mPlat; }
            set { mPlat = value; }
        }

        public int MonsterGold
        {
            get { return mGold; }
            set { mGold = value; }
        }

        public int MonsterSilver
        {
            get { return mSilver; }
            set { mSilver = value; }
        }

        public int MonsterCopper
        {
            get { return mCopper; }
            set { mCopper = value; }
        }

        public int MonsterTokens
        {
            get { return mToken; }
            set { mToken = value; }
        }

        public int MonsterMinJade
        {
            get { return mMinJade; }
            set { mMinJade = value; }
        }

        public int MonsterMaxJade
        {
            get { return mMaxJade; }
            set { mMaxJade = value; }
        }

        public void GetMonster(string monsterName)
        {
            var data = File.ReadAllLines("MonsterInfo.txt")
                    .Select(x => x.Split('='))
                    .Where(x => x.Length > 1)
                    .ToDictionary(x => x[0].Trim(), x => x[1]);

            this.MonsterName = data["Name"];
            this.MonsterEndurance = Convert.ToInt16(data["Endurance"]);
            this.MonsterHealth = this.MonsterEndurance * 5;
            this.OrigMonsterHealth = this.MonsterHealth;
            this.MonsterAttack = Convert.ToInt16(data["Attack"]);
            this.MonsterDefence = Convert.ToInt16(data["Defence"]);
            this.MonsterAccuracy = float.Parse(data["Accuracy"]);
            this.MonsterEvasion = float.Parse(data["Evasion"]);
            this.MonsterExperience = Convert.ToInt16(data["EXP"]);
            this.MonsterPlatinum = Convert.ToInt16(data["Platinum"]);
            this.MonsterGold = Convert.ToInt16(data["Gold"]);
            this.MonsterSilver = Convert.ToInt16(data["Silver"]);
            this.MonsterCopper = Convert.ToInt16(data["Copper"]);
            this.MonsterTokens = Convert.ToInt16(data["Tokens"]);
            this.MonsterMinJade = Convert.ToInt16(data["MinJade"]);
            this.MonsterMaxJade = Convert.ToInt16(data["MaxJade"]);
            data.Clear();
        }

        public void MonsterDestroy()
        {
            this.MonsterName = "";
            this.MonsterEndurance = 0;
            this.MonsterHealth = 0;
            this.MonsterAttack = 0;
            this.MonsterDefence = 0;
            this.MonsterEvasion = 0.0f;
            this.MonsterAccuracy = 0.0f;
            this.MonsterExperience = 0;
            this.MonsterPlatinum = 0;
            this.MonsterGold = 0;
            this.MonsterCopper = 0;
            this.MonsterSilver = 0;
            this.MonsterTokens = 0;
            this.MonsterMinJade = 0;
            this.MonsterMaxJade = 0;
        }
    }
}
