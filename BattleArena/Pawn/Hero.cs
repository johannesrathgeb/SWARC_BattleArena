using BattleArena.Items;
using System;
using System.Collections.Generic;

namespace BattleArena.Pawn
{
    public class Hero
    {
        LoggingSystem logsys = LoggingSystem.getInstance();
        private IEquipment _weapon;
        private int lastKeyInput;
        private List<Goblin> goblins = new List<Goblin>();
        public string weaponName { get; private set; }
        public int Health { get; private set; } = 100;
        public int Coins { get; private set; } = 1;
        public int NumberOfGoblins => this.goblins.Count;
        public int Leprechaun { get; private set; } = 0;

        public string Name { get; private set; }

        public Hero(string name, IEquipment equipment)
        {
            this.Name = name;
            this._weapon = equipment;
            weaponName = this._weapon.Name;
            this.lastKeyInput = -1;
        }

        public bool Action(Hero other)
        {
            this._weapon.Use(other);
            return true;
        }

        public bool switchWeapon(IEquipment weapon)
        {
            _weapon = weapon;
            weaponName = this._weapon.Name;
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
                logsys.createLog("Tiny Goblin", Name, DateTime.Now);
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
                logsys.createLog("Medium Goblin", Name, DateTime.Now);
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
                logsys.createLog("Big Goblin", Name, DateTime.Now);
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