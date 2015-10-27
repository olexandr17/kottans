using BattleShip.enums;

namespace BattleShip.ships
{
    public class AircraftCarrier : Ship
    {

        public override int Length => (int)Types.AircraftCarrier;

        public AircraftCarrier(int x, int y) : this(x, y, Direction.Horizontal)
        {

        }

        public AircraftCarrier(int x, int y, Direction direction) : base(x, y, direction)
        {

        }

    }
}
