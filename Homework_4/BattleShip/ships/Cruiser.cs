using BattleShip.enums;

namespace BattleShip.ships
{
    public class Cruiser : Ship
    {

        public override int Length => (int)Types.Cruiser;

        public Cruiser(int x, int y) : this(x, y, Direction.Horizontal)
        {

        }

        public Cruiser(int x, int y, Direction direction) : base(x, y, direction)
        {

        }

    }
}
