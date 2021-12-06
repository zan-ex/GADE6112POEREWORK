using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [System.Serializable()]
    abstract class Enemy : Character
    {
        protected Random random = new Random();
        public Enemy(int y, int x, int maxHp, int Damage, char symbol, Weapon weapon) : base(y, x, maxHp, Damage, symbol, weapon)
        {

        }

        public override string ToString()
        {
            return " at [" + this.X + "," + this.Y + "]  (" + this.hp + "hp)" + (weapon != null ? " with " + weapon.Durability + "x" + weapon.WeaponType : "");
        }
    }
}
