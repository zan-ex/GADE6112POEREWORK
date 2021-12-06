using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [System.Serializable()]
    class Hero : Character
    {

        public Hero(int y, int x, int maxhp) : base(y, x, maxhp, 2, 'H', null)
        {
            this.ThisTileType = TileType.Hero;
            purse = 0;
        }

        public override Movement ReturnMove(Movement move)
        {
            return move;
        }

        public override string ToString()
        {
            return "Player Stats:\n" + "HP: " + hp + "/" + maxHP
                + "\nCurrent Weapon: " + (weapon != null ? weapon.WeaponType : "Fists")
                + "\n Weapon Range: " + (weapon != null ? weapon.Range.ToString() : "1")
                + "\n Weapon Damage: " + (weapon != null ? weapon.Damage.ToString() : "2")
                + "\nGold: " + purse
                + "\nDamage: 2\n"
                + "[" + Y + "," + X + "]";
        }
    }
}
