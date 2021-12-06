using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [System.Serializable()]
    class Goblin : Enemy
    {
        public Goblin(int y, int x) : base(y, x, 10, 1, 'G', new MeleeWeapon(MeleeWeapon.Types.Dagger))
        {
            purse = 1;
        }

        public override Movement ReturnMove(Movement move)
        {
            bool canmove = false;
            int direction = random.Next(0, 4);
            for (int i = 0; i < vision.Length; i++)
            {
                if (vision[i]?.GetType() == typeof(Hero))
                    return Movement.NoMovement;
                if (vision[i] == null)
                {
                    canmove = true;
                    break;
                }
                if ((vision[i].GetType().BaseType != typeof(Character) && vision[i].GetType().BaseType.BaseType != typeof(Character) && vision[i]?.ThisTileType != TileType.Empty))
                {
                    canmove = true;
                    break;
                }
            }
            if (canmove == false)
            {
                return Movement.NoMovement;
            }
            while (vision[direction] != null)
            {
                if (vision[direction].GetType().BaseType != typeof(Character) && vision[direction].GetType().BaseType.BaseType != typeof(Character) && vision[direction]?.ThisTileType != TileType.Empty)
                {
                    return (Movement)direction + 1;
                }
                direction = random.Next(0, 4);
            }
            return (Movement)direction + 1;
        }

        public override string ToString()
        {
            return (weapon != null ? "Equipped: " : "BareHanded: ") + "Goblin" + base.ToString();
        }
    }
}
