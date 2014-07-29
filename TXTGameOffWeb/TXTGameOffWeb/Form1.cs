using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using TXTGameOffWeb.Objects;

namespace TXTGameOffWeb
{
    public partial class Form1 : Form
    {
        private static int auto = 6;
        private static int attacks = 20;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bLogPanel.Hide();
            bLogPanel.Visible = false;
            jewelPanel.Hide();
            jewelPanel.Visible = false;
            LoadPlayer();
        }

        public void BattleState()
        {
            Battle battle = new Battle();
            Player player = new Player();
            Monster mob = new Monster();
            sMHPLbl.Text = mob.MonsterHealth.ToString();
            sPHPLbl.Text = player.Health.ToString();
            while (battle.BattleEnd == false)
            {
                if (player.Health >= 1 && mob.MonsterHealth <= 0)
                {
                    battle.BattleEnd = true;               
                }
                if (player.Health <= 0 && mob.MonsterHealth >= 1)
                {
                    battle.BattleEnd = true;
                }
                else if (player.Health >= 0 || mob.MonsterHealth >= 1)
                {
                    sDefeatLBl.Text = battle.SendMessage;
                    sDDealtLbl.Text = battle.DamageDealt.ToString();
                    sDTakenLbl.Text = battle.DamageTaken.ToString();
                    if (player.Health <= 0)
                    {
                        battle.BattleEnd = true;
                    }
                    if (mob.MonsterHealth <= 0)
                    {
                        battle.BattleEnd = true;
                    }
                }
            }
        }

        private void actionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = actionBox.Text.ToLower();
            if (tmp == "battle" && bLogPanel.Visible == false)
            {
                bLogPanel.Show();
                bLogPanel.Visible = true;

                autoAtkLbl.Visible = true;

                jewelPanel.Visible = false;
                jewelPanel.Hide();
            }
            else
            {
                bLogPanel.Hide();
                bLogPanel.Visible = false;

                autoAtkLbl.Visible = false;
            }
            if (tmp == "crafting" && jewelPanel.Visible == false)
            {
                jewelPanel.Show();
                jewelPanel.Visible = true;

                bLogPanel.Visible = false;
                bLogPanel.Hide();
            }
            else
            {
                jewelPanel.Hide();
                jewelPanel.Visible = false;
            }
        }

        private void actionBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string tmp = actionBox.Text.ToLower();
            if (tmp == "battle" && bLogPanel.Visible == false)
            {
                bLogPanel.Show();
                bLogPanel.Visible = true;
            }
            else
            {
                bLogPanel.Hide();
                bLogPanel.Visible = false;
            }

            if (tmp == "crafting" && jewelPanel.Visible == false)
            {
                jewelPanel.Show();
                jewelPanel.Visible = true;
            }
            else
            {
                jewelPanel.Hide();
                jewelPanel.Visible = false;
            }
        }

        private void actionBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string tmp = actionBox.Text.ToLower();
            if (tmp == "battle" && bLogPanel.Visible == false)
            {
                bLogPanel.Show();
                bLogPanel.Visible = true;
            }
            else
            {
                bLogPanel.Hide();
                bLogPanel.Visible = false;
            }
                        if (tmp == "crafting" && jewelPanel.Visible == false)
            {
                jewelPanel.Show();
                jewelPanel.Visible = true;

                bLogPanel.Visible = false;
                bLogPanel.Hide();
            }
            else
            {
                jewelPanel.Hide();
                jewelPanel.Visible = false;
            }
        }

        private void atkMobLbl_Click(object sender, EventArgs e)
        {
            StartNewBattle();
        }

        private void autoAtkLbl_Click(object sender, EventArgs e)
        {
            autoTimer.Start();
            if (continueStopLbl.Text == "Continue")
            {
                autoAtkLbl.Text = "";
            }
            bLogPanel.Show();
            bLogPanel.Visible = true;
            continueStopLbl.Text = "Stop auto battle";
        }

        private void continueStopLbl_Click(object sender, EventArgs e)
        {
            if (continueStopLbl.Text == "Stop auto battle")
            {
                attacks = 20;
                autoTimer.Enabled = false;
                autoTimer.Stop();
                auto = 6;
                continueStopLbl.Text = "Continue";
                actionTimerLbl.Text = "6";
                autoAtkLbl.Text = "Auto";
            }
            else if (continueStopLbl.Text == "Continue")
            {
                StartNewBattle();
            }
        }

        public void LoadPlayer()
        {
            Player player = new Player();
            Quests quest = new Quests();

            var data = File.ReadAllLines("PlayerInfo.txt")
                .Select(x => x.Split('='))
                .Where(x => x.Length > 1)
                .ToDictionary(x => x[0].Trim(), x => x[1]);
            //[Player]
            player.Name = data["Name"];
            player.GuildName = data["Guild"];            
            player.Rank = data["Rank"];
            player.Level = Convert.ToInt16(data["Level"]);
            player.Experience = Convert.ToInt16(data["EXP"]);
            player.GuildLevel = Convert.ToInt16(data["GuildLvl"]);
            player.Rep = Convert.ToInt16(data["Rep"]);

            //[Stats]
            player.Endurance = Convert.ToInt16(data["Endurance"]);
            player.Health = Convert.ToInt16(data["Health"]);
            player.Attack = Convert.ToInt16(data["Attack"]);
            player.Defence = Convert.ToInt16(data["Defence"]);
            player.Accuracy = float.Parse(data["Accuracy"]);
            player.Evasion = float.Parse(data["Evasion"]);

            //[Currencies]
            player.Platinum = Convert.ToInt16(data["Platinum"]);            
            player.Gold = Convert.ToInt16(data["Gold"]);
            player.Silver = Convert.ToInt16(data["Silver"]);
            player.Copper = Convert.ToInt16(data["Copper"]);
            player.Jade = Convert.ToInt16(data["Jade"]);
            player.Tokens = Convert.ToInt16(data["Tokens"]);
            player.PrizeTickets = Convert.ToInt16(data["Prize Tickets"]);
            player.Diamonds = Convert.ToInt16(data["Diamonds"]);
            player.Sapphires = Convert.ToInt16(data["Sapphires"]);
            player.Rubies = Convert.ToInt16(data["Rubies"]);
            player.Emeralds = Convert.ToInt16(data["Emeralds"]);
            player.Opals = Convert.ToInt16(data["Opals"]);

            //[Quests]
            player.CurrentQuest = Convert.ToInt16(data["CurrentQuest"]);

            player.QuestsCompleted = Convert.ToInt16(data["QComplete"]);
            player.MonstersKilled = Convert.ToInt16(data["Mkills"]);
            player.QuestAmount = Convert.ToInt16(data["QCount"]);
            player.MaxQuestAmount = Convert.ToInt16(data["MaxCount"]);

            //[Equipment]
            player.Weapon1 = data["LeftHand"];
            player.Weapon2 = data["RightHand"];
            player.Head = data["Head"];

            player.Hands = data["Gloves"];
            player.Wrist = data["Wrist"];
            player.Arm = data["Arm"];
            player.ChestArmor = data["Chest"];
            player.Legs = data["Legs"];
            player.Feet = data["Feet"];
            player.Necklace = data["Necklace"];
            player.Ring1 = data["Ring1"];
            player.Ring2 = data["Ring2"];
            player.Ring3 = data["Ring3"];
            player.Ring4 = data["Ring4"];
            player.Brace1 = data["Brace1"];
            player.Brace2 = data["Brace2"];           

            data.Clear();

       
            updateLblTimer.Start();
            updateTimer.Start();
        }

        private void updateLblTimer_Tick(object sender, EventArgs e)
        {
            Player player = new Player();

            int convertHP = player.Endurance * 5;

            //Player Info
            sNameLbl.Text = player.Name;
            sLvlLbl.Text = player.Level.ToString();
            sExpLbl.Text = player.Experience.ToString();
            sGuildLbl.Text = player.GuildName;
            sGuildLvlLbl.Text = player.GuildLevel.ToString();
            sRepLbl.Text = player.Rep.ToString();
            sRankLbl.Text = player.Rank;

            //Player Stats
            sHealthLbl.Text = player.Endurance.ToString();
            sPHPLbl.Text = convertHP.ToString();
            sAtkLbl.Text = player.Attack.ToString();
            sDefLbl.Text = player.Defence.ToString();
            sAccLbl.Text = player.Accuracy.ToString();
            sEvaLbl.Text = player.Evasion.ToString();

            //Currencies
            sPlatLbl.Text = player.Platinum.ToString() + "p";
            sGoldLbl.Text = player.Gold.ToString() + "g";
            sSilverLbl.Text = player.Silver.ToString() + "s";
            sCopperLbl.Text = player.Copper.ToString() + "c";
            sJadeLbl.Text = player.Jade.ToString();
            sTokenLbl.Text = player.Tokens.ToString();
            sPTicketLbl.Text = player.PrizeTickets.ToString();            
            sDiaLbl.Text = player.Diamonds.ToString();
            sSapphLbl.Text = player.Sapphires.ToString();
            sRubyLbl.Text = player.Rubies.ToString();
            sEmeLbl.Text = player.Emeralds.ToString();
            sOpalLbl.Text = player.Opals.ToString();

            //Quests
            sQNumLbl.Text = player.CurrentQuest.ToString();
            sQuestCompLbl.Text = player.QuestsCompleted.ToString();
            sMobKillsLbl.Text = player.MonstersKilled.ToString();
            sProgressLbl.Text = player.QuestAmount.ToString() + "/" + player.MaxQuestAmount.ToString() + "(0) to go";

            //Equips
            sWeapon1.Text = player.Weapon1;
            sWeapon2.Text = player.Weapon2;
            sHelm.Text = player.Head;
            sGloves.Text = player.Hands;
            sWrist.Text = player.Wrist;
            sArm.Text = player.Arm;
            sChest.Text = player.ChestArmor;
            sLegs.Text = player.Legs;
            sFeet.Text = player.Feet;
            sNecklaceLbl.Text = player.Necklace;
            sRing1Lbl.Text = player.Ring1;
            sRing2Lbl.Text = player.Ring2;
            sRing3Lbl.Text = player.Ring3;
            sRing4Lbl.Text = player.Ring4;
            sBrace1Lbl.Text = player.Brace1;
            sBrace2Lbl.Text = player.Brace2;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            Player player = new Player();
            StreamWriter writer = new StreamWriter("PlayerInfo.txt");
            writer.WriteLine("[Player]");
            writer.WriteLine("Name =" + player.Name);
            writer.WriteLine("Level =" + player.Level.ToString());
            writer.WriteLine("EXP =" + player.Experience.ToString());
            writer.WriteLine("Guild =" + player.GuildName);
            writer.WriteLine("GuildLvl =" + player.GuildLevel.ToString());
            writer.WriteLine("Rep =" + player.Rep.ToString());
            writer.WriteLine("Rank =" + player.Rank);

            writer.WriteLine("[Stats]");
            writer.WriteLine("Endurance =" + player.Endurance.ToString());
            int convertEndurance = player.Endurance * 5;
            writer.WriteLine("Health =" + convertEndurance.ToString());
            writer.WriteLine("Attack =" + player.Attack.ToString());
            writer.WriteLine("Defence =" + player.Defence.ToString());
            writer.WriteLine("Accuracy =" + player.Accuracy.ToString());
            writer.WriteLine("Evasion =" + player.Evasion.ToString());

            writer.WriteLine("[Currencies]");
            writer.WriteLine("Platinum =" + player.Platinum.ToString());
            writer.WriteLine("Gold =" + player.Gold.ToString());
            writer.WriteLine("Silver =" + player.Silver.ToString());
            writer.WriteLine("Copper =" + player.Copper.ToString());
            writer.WriteLine("Jade =" + player.Jade.ToString());
            writer.WriteLine("Tokens =" + player.Tokens.ToString());
            writer.WriteLine("Prize Tickets =" + player.PrizeTickets.ToString());
            writer.WriteLine("Diamonds =" + player.Diamonds.ToString());
            writer.WriteLine("Sapphires =" + player.Sapphires.ToString());
            writer.WriteLine("Rubies =" + player.Rubies.ToString());
            writer.WriteLine("Emeralds =" + player.Emeralds.ToString());
            writer.WriteLine("Opals =" + player.Opals.ToString());

            writer.WriteLine("[Quests]");
            writer.WriteLine("CurrentQuest =" + player.CurrentQuest.ToString());
            writer.WriteLine("QComplete =" + player.QuestsCompleted.ToString());
            writer.WriteLine("Mkills =" + player.MonstersKilled.ToString());
            writer.WriteLine("QCount =" + player.QuestsCompleted.ToString());
            writer.WriteLine("MaxCount =" + player.MaxQuestAmount.ToString());

            writer.WriteLine("[Equipment]");
            writer.WriteLine("LeftHand =" + player.Weapon1);
            writer.WriteLine("RightHand =" + player.Weapon2);
            writer.WriteLine("Head =" + player.Head);
            writer.WriteLine("Gloves =" + player.Hands);
            writer.WriteLine("Wrist =" + player.Wrist);
            writer.WriteLine("Arm =" + player.Arm);
            writer.WriteLine("Chest =" + player.ChestArmor);
            writer.WriteLine("Legs =" + player.Legs);
            writer.WriteLine("Feet =" + player.Feet);
            writer.WriteLine("Necklace =" + player.Necklace);
            writer.WriteLine("Ring1 =" + player.Ring1);
            writer.WriteLine("Ring2 =" + player.Ring2);
            writer.WriteLine("Ring3 =" + player.Ring3);
            writer.WriteLine("Ring4 =" + player.Ring4);
            writer.WriteLine("Brace1 =" + player.Brace1);
            writer.WriteLine("Brace2 =" + player.Brace2);
            writer.Close();
        }

        private void autoTimer_Tick(object sender, EventArgs e)
        {
            auto--;
            
            if (auto == 0 && attacks == 0)            
            {            
                autoTimer.Stop();
                attacks = 20;
            } 
            else if (auto == -1)                            
            {                                   
                auto = 6;                    
                attacks--;
                if (attacks == 0)
                {
                    attacks = 20;
                    autoTimer.Stop();
                }
            }                
            else                
            {                    
                sAutoRemainLbl.Text = attacks.ToString();                    
                actionTimerLbl.Text = auto.ToString();                    
                StartNewBattle();                
            }
        }

        public void StartNewBattle()
        {
            Battle battle = new Battle();
            Monster mob = new Monster();
            mob.MonsterName = mobBox.Text.ToLower();
            battle.BattleStarted = true;
            mob.GetMonster(mob.MonsterName);
            battle.BattleResult(mob.MonsterName);            
            BattleState();
        }
    }
}
