using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [System.Serializable()]
    abstract class Item : Tile
    {
        protected Item(int y, int x) : base(y, x)
        {
        }  
    }
}
