using BattleShip.enums;

namespace BattleShip.ships
{
    public class Submarine : Ship
    {

        public override int Length => (int)Types.Submarine;

        public Submarine(int x, int y) : this(x, y, Direction.Horizontal)
        {

        }

        public Submarine(int x, int y, Direction direction) : base(x, y, direction)
        {

        }

    }
}
