using BattleArena.Pawn;
using BattleArena.Items;

namespace BattleArena.Items
{
    public interface IEquipment
    {
        public string Name { get; }
        public void Use(Hero other);
    }
}
