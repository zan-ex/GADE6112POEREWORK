using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [Serializable()]
    class Shop
    {
        private Weapon[] weapons = new Weapon[3];
        private Random random = new Random();
        private Character buyer;

        public Shop(Character buyer)
        {
            this.buyer = buyer;
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i] = RandomWeapon();
            }
        }

        private Weapon RandomWeapon()
        {
            switch (random.Next(0, 4))
            {
                case 0:
                    return new RangedWeapon(RangedWeapon.Types.Rifle);
                case 1:
                    return new RangedWeapon(RangedWeapon.Types.Longbow);
                case 2:
                    return new MeleeWeapon(MeleeWeapon.Types.Dagger);
                case 3:
                    return new MeleeWeapon(MeleeWeapon.Types.LongSword);

            }
            return null;
        }

        public bool CanBuy(int num)
        {
            if (weapons[num].Cost > buyer.Purse)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Buy(int num)
        {
            buyer.Pickup(weapons[num]);
            buyer.Purse -= weapons[num].Cost;
            weapons[num] = RandomWeapon();
        }

        public string DisplayWeapon(int num)
        {
            return "Buy " + weapons[num].WeaponType + " (" + weapons[num].Cost + "Gold)";
        }
    }
}
