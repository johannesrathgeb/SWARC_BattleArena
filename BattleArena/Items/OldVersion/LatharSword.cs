using System;

namespace BattleArena.Items.OldVersion
{
    public class LatharSword
    {
        private const int percentageVariable = 4;
        private const int strenght = 5;

        private readonly Random randomNumberGenerator;

        public LatharSword(Random randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public int Hit()
        {
            return this.randomNumberGenerator.Next(10) < percentageVariable ? strenght : 0;
        }
    }
}
