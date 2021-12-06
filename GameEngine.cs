using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaneMoolman_19338463_GADE6112_POE_REWORK
{
    class GameEngine
    {
        private Map map;
        private Shop shop;

        public Map Map
        {
            get => map;
            set => map = value;
        }

        public Shop Shop
        {
            get => shop;
            set => shop = value;
        }

        public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyAmount, int amountGold, int amountWeapon)
        {
            map = new Map(minWidth, maxWidth, minHeight, maxHeight, enemyAmount, amountGold, amountWeapon);
            shop = new Shop(map.Hero);
        }

        public void EnemiesMove()
        {
            foreach (var enemy in map.Enemies)
            {
                if (enemy.GetType() == typeof(Mage))
                {
                    continue;
                }
                map.UpdateCharacterVision(enemy);
                while (!MovePlayer(enemy.ReturnMove(Character.Movement.NoMovement), enemy)) { }

            }
        }

        public bool MovePlayer(Character.Movement direction, Character character)
        {
            if (direction == Character.Movement.Left)
            {
                if (character.X - 1 != 0 && (character.Vision[2] == null || character.Vision[2].ThisTileType == Tile.TileType.Gold || character.Vision[2].ThisTileType == Tile.TileType.Weapon))
                {
                    character.Pickup(map.GetItemAtPosition(character.Y, character.X));
                    map.ThisMap[character.Y, character.X] = null;
                    character.Move(Character.Movement.Left);

                    map.ThisMap[character.Y, character.X] = character;

                    return true;
                }
            }
            else if (direction == Character.Movement.Right)
            {
                if (character.X + 2 != map.MapWidth && (character.Vision[3] == null || character.Vision[3].ThisTileType == Tile.TileType.Gold || character.Vision[3].ThisTileType == Tile.TileType.Weapon))
                {
                    character.Pickup(map.GetItemAtPosition(character.Y, character.X));
                    map.ThisMap[character.Y, character.X] = null;
                    character.Move(Character.Movement.Right);

                    map.ThisMap[character.Y, character.X] = character;

                    return true;
                }
            }
            else if (direction == Character.Movement.Up)
            {
                if (character.Y - 1 != 0 && (character.Vision[0] == null || character.Vision[0].ThisTileType == Tile.TileType.Gold || character.Vision[0].ThisTileType == Tile.TileType.Weapon))
                {
                    character.Pickup(map.GetItemAtPosition(character.Y, character.X));
                    map.ThisMap[character.Y, character.X] = null;
                    character.Move(Character.Movement.Up);
                    map.ThisMap[character.Y, character.X] = character;

                    return true;
                }
            }
            else if (direction == Character.Movement.Down)
            {
                if (character.Y + 2 != map.MapHeight && (character.Vision[1] == null || character.Vision[1].ThisTileType == Tile.TileType.Gold || character.Vision[1].ThisTileType == Tile.TileType.Weapon))
                {
                    character.Pickup(map.GetItemAtPosition(character.Y, character.X));
                    map.ThisMap[character.Y, character.X] = null;
                    character.Move(Character.Movement.Down);
                    map.ThisMap[character.Y, character.X] = character;

                    return true;

                }
            }
            else { return true; }
            return false;
        }

        public void EnemyAttacks()
        {
            foreach (var enemy in map.Enemies)
            {
                if (enemy.CheckRange(map.Hero))
                {
                    enemy.Attack(map.Hero);
                }
                foreach (var e in map.Enemies)
                {
                    if (e == enemy || enemy.GetType() != typeof(Mage))
                    {
                        continue;
                    }
                    if (enemy.CheckRange(e))
                    {
                        enemy.Attack(e);
                    }
                }
            }
        }
    }
}