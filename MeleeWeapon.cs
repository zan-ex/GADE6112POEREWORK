using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{

    [Serializable()]
    internal class MeleeWeapon : Weapon
    {
        public enum Types { Dagger, LongSword }
        public override int Range { get => 1; }

        public MeleeWeapon(Types type) : base(0, 0, 0, 0, "", 0, 0)
        {
            ThisTileType = TileType.Weapon;
            switch (type)
            {
                case Types.Dagger:
                    damage = 3;
                    durability = 10;
                    cost = 3;
                    weaponType = "Dagger";
                    break;
                case Types.LongSword:
                    damage = 4;
                    durability = 6;
                    cost = 5;
                    weaponType = "Longsword";
                    break;
            }
        }

        public MeleeWeapon(Types type, int x, int y) : base(0, 0, 0, 0, "", x, y)
        {

            switch (type)
            {
                case Types.Dagger:
                    damage = 3;
                    durability = 10;
                    cost = 3;
                    weaponType = "Dagger";
                    break;
                case Types.LongSword:
                    damage = 4;
                    durability = 6;
                    cost = 5;
                    weaponType = "Longsword";
                    break;
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
