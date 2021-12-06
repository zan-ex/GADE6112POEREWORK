using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [Serializable()]
    abstract class Weapon : Item
    {
        protected int damage;
        protected int range;
        protected int durability;
        protected int cost;
        protected string weaponType;

        public int Damage { get => damage; set => damage = value; }
        public virtual int Range { get => range; set => range = value; }
        public int Durability { get => durability; set => durability = value; }
        public int Cost { get => cost; set => cost = value; }
        public string WeaponType { get => weaponType; set => weaponType = value; }

        public Weapon(int damage, int range, int durability, int cost, string weaponType) : base(0, 0)
        {

            this.damage = damage;
            this.range = range;
            this.durability = durability;
            this.cost = cost;
            this.weaponType = weaponType;
        }
        public Weapon(int damage, int range, int durability, int cost, string weaponType, int x, int y) : base(y, x)
        {

            this.damage = damage;
            this.range = range;
            this.durability = durability;
            this.cost = cost;
            this.weaponType = weaponType;
        }
    }
}
