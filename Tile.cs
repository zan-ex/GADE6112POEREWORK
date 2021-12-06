using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [System.Serializable()]
    abstract class Tile
    {
        protected int x, y;


        public Tile(int y, int x)
        {
            this.y = y;
            this.x = x;
        }

        public int Y { get { return y; } set { y = value; } }
        public int X { get { return x; } set { x = value; } }

        public TileType ThisTileType { get; set; }
        public enum TileType
        {
            Hero, Enemy, Gold, Weapon, Empty
        }

    }
}
