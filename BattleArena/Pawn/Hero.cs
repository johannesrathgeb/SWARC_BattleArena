using BattleArena.Items;
using System;
using System.Collections.Generic;

namespace BattleArena.Pawn
{
    public class Hero
    {
       
        private readonly IEquipment weapon;
        private int lastKeyInput;
        private List<Goblin> goblins = new List<Goblin>();

        public int Health { get; private set; } = 100;
        public int Coins { get; private set; } = 1;
        public int NumberOfGoblins => this.goblins.Count;
        public int Leprechaun { get; private set; } = 0;

        public string Name { get; private set; }

        public Hero(string name, IEquipment equipment)
        {
            this.Name = name;
            this.weapon = equipment;

            this.lastKeyInput = -1;
        }

        public bool Action(Hero other)
        {
            this.weapon.Use(other);
            return true;
        }

        public void UpdateCoins()
        {
            this.Coins += this.Leprechaun + 1;
        }

        public void useGoblins(Hero other)
        {
            foreach (Goblin tmpGoblin in this.goblins)
            {
                tmpGoblin.Action(other);
            }
        }

        public void ReduceHealth(int hitPoints)
        {
            this.Health -= hitPoints;
        }

        public bool AddLeprechaun()
        {
            if (this.Coins > 1)
            {
                this.Coins -= 2;
                this.Leprechaun++;
                return true;
            }
            return false;
        }

        public bool AddTinyGoblin(Random randomNumberGenerator)
        {
            if (this.Coins > 0)
            {
                this.Coins -= 1;
                this.goblins.Add(new Goblin(1, randomNumberGenerator));
                return true;
            }
            return false;
        }

        public bool AddMediumGoblin(Random randomNumberGenerator)
        {
            if (this.Coins > 2)
            {
                this.Coins -= 3;
                this.goblins.Add(new Goblin(2, randomNumberGenerator));
                return true;
            }
            return false;
        }

        public bool AddBigGoblin(Random randomNumberGenerator)
        {
            if (this.Coins > 5)
            {
                this.Coins -= 6;
                this.goblins.Add(new Goblin(3, randomNumberGenerator));
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}\nCoins {this.Coins}\nLeprechaun: {this.Leprechaun}\nLastKeyInput: {this.lastKeyInput}\n\n";
        }
    }
}