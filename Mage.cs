using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [System.Serializable()]
    class Mage : Enemy
    {

        public Mage(int y, int x) : base(y, x, 10, 2, 'M', null)
        {
            purse = 3;
        }

        public override Movement ReturnMove(Movement move)
        {
            return Movement.NoMovement;
        }

        public override bool CheckRange(Character target)
        {
            if (this == target)
                return false;
            if (target.X == this.X || target.X == this.X - 1 || target.X == this.X + 1)
            {
                if (target.Y == this.Y || target.Y == this.Y - 1 || target.Y == this.Y + 1)
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return (weapon != null ? "Equipped: " : "BareHanded: ") + "Mage" + base.ToString();
        }
    }
}
