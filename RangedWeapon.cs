using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [Serializable()]
    class RangedWeapon : Weapon
    {
        public enum Types { Rifle, Longbow }
        public override int Range { get => base.Range; set => base.Range = value; }

        public RangedWeapon(Types type) : base(0, 0, 0, 0, "", 0, 0)
        {
            ThisTileType = TileType.Weapon;
            switch (type)
            {
                case Types.Rifle:
                    damage = 5;
                    durability = 3;
                    cost = 7;
                    range = 3;
                    weaponType = "Rifle";
                    break;
                case Types.Longbow:
                    damage = 4;
                    durability = 4;
                    cost = 6;
                    range = 2;
                    weaponType = "Longbow";
                    break;
            }
        }

        public RangedWeapon(Types type, int x, int y) : base(0, 0, 0, 0, "", x, y)
        {

            switch (type)
            {
                case Types.Rifle:
                    damage = 5;
                    durability = 3;
                    cost = 7;
                    range = 3;
                    weaponType = "Rifle";
                    break;
                case Types.Longbow:
                    damage = 4;
                    durability = 4;
                    cost = 6;
                    range = 2;
                    weaponType = "Longbow";
                    break;
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
