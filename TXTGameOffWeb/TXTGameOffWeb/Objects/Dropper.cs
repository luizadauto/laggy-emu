using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TXTGameOffWeb.Objects
{
    public class Dropper
    {
      
        public void DropItem()
        {
            Player player = new Player();
            Monster mob = new Monster();
            Random rand = new Random();

            player.Copper += mob.MonsterCopper;
            player.Silver += mob.MonsterSilver;
            player.Gold += mob.MonsterGold;
            player.Platinum += mob.MonsterPlatinum;
            player.Tokens += mob.MonsterTokens;

            player.Jade += rand.Next(mob.MonsterMinJade, mob.MonsterMaxJade);

        }
    }
}
