using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    [System.Serializable()]
    abstract class Character : Tile
    {
        protected char symbol { get; set; }
        protected int hp { get; set; }
        protected int maxHP { get; set; }
        protected int damage { get; set; }
        protected Tile[] vision { get; set; }// up down left right
        protected bool dead { get; set; }
        protected int purse { get; set; }

        protected Weapon weapon;

        public int Purse
        {
            get => purse;
            set => purse = value;
        }
        public char Symbol
        {
            get => symbol;
            set => symbol = value;
        }

        public int Hp
        {
            get => hp;
            set => hp = value;
        }

        public int MaxHp
        {
            get => maxHP;
            set => maxHP = value;
        }
        public int Damage
        {
            get => damage;
            set => damage = value;
        }
        public Tile[] Vision
        {
            get => vision;
            set => vision = value;
        }
        public bool Dead
        {
            get => dead;
            set => dead = value;
        }
        public Weapon Weapon { get => weapon; set => weapon = value; }

        public enum Movement
        {
            NoMovement, Up, Down, Left, Right
        }
        public Character(int y, int x, int maxhp, int damage, char symbol, Weapon weapon) : base(y, x)
        {
            this.symbol = symbol;
            maxHP = maxhp;
            hp = maxhp;
            this.damage = damage;
            vision = new Tile[4];
            this.weapon = weapon;
        }

        public void Pickup(Item i)

        {
            if (i == null)
            {
                return;
            }
            if (i.ThisTileType == TileType.Gold)
            {
                purse += ((Gold)i).GetGold();
            }
            if (i.ThisTileType == TileType.Weapon)
            {
                EquipWeapon((Weapon)i);
            }
        }

        public void Loot(Character character)
        {
            purse += character.purse;
            if (this.GetType() != typeof(Mage))
                if (weapon == null)
                {
                    EquipWeapon(character.weapon);
                }
        }

        private void EquipWeapon(Weapon w)
        {
            weapon = w;
        }

        public virtual void Attack(Character target)
        {
            target.hp -= this.damage;
            if (target.hp <= 0)
            {
                target.dead = true;
                Loot(target);
            }
        }

        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) <= 1 && DistanceTo(target) >= -1)
            {
                return true;
            }
            return false;
        }

        public void Move(Movement move)
        {
            //if move == nomovement nothing will happen
            if (move == Movement.Down)
            {
                this.Y++;
            }
            if (move == Movement.Up)
            {
                this.Y--;
            }
            if (move == Movement.Right)
            {
                this.X++;
            }
            if (move == Movement.Left)
            {
                this.X--;
            }
        }

        public bool IsDead()
        {
            return dead;
        }
        private int DistanceTo(Character target)
        {
            return Math.Abs(target.X - this.X) + Math.Abs(target.Y - this.Y);
        }

        public abstract Movement ReturnMove(Movement move);

        public abstract override string ToString();
    }
}

