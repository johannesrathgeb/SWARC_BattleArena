using BattleArena.Items.OldVersion;
using BattleArena.Pawn;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArena.Items
{
    class LatharSwordAdapter : IEquipment
    {
        private LatharSword _latharSword;

        public LatharSwordAdapter(Random randomNumberGenerator)
        {
            _latharSword = new LatharSword(randomNumberGenerator);
        }

        public string Name { get; } = "Lathar Sword";

        public void Use(Hero other)
        {
            other.ReduceHealth(_latharSword.Hit());
        }
    }
}
