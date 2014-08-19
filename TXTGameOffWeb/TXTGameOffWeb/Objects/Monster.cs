using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TXTGameOffWeb.Objects
{
    public class Monster
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

        private static int currentMonster;

        public int CurrentMonster
        {
            get { return currentMonster; }
            set { currentMonster = value; }
        }

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
            StreamReader reader = new StreamReader("MonsterInfo.txt");

            string s = reader.ReadLine();

            while (s != null)
            {
                    char[] delimiter = { ':' };
                    string[] fields = s.Split(delimiter);
                    this.MonsterName = fields[0];
                    this.MonsterEndurance = int.Parse(fields[1]);
                    this.MonsterHealth = this.MonsterEndurance * 5;
                    this.OrigMonsterHealth = this.MonsterHealth;
                    this.MonsterAttack = int.Parse(fields[2]);
                    this.MonsterDefence = int.Parse(fields[3]);
                    this.MonsterAccuracy = float.Parse(fields[4]);
                    this.MonsterEvasion = float.Parse(fields[5]);
                    this.MonsterExperience = int.Parse(fields[6]);
                    this.MonsterPlatinum = int.Parse(fields[7]);
                    this.MonsterGold = int.Parse(fields[8]);
                    this.MonsterSilver = int.Parse(fields[9]);
                    this.MonsterCopper = int.Parse(fields[10]);
                    this.MonsterTokens = int.Parse(fields[11]);
                    this.MonsterMinJade = int.Parse(fields[12]);
                    this.MonsterMaxJade = int.Parse(fields[13]);
                    if (this.MonsterName == monsterName)
                    {
                        return;
                    }
                    else
                    {
                        s = reader.ReadLine();
                    }                                
            }
            reader.Dispose();
            reader.Close();            
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
