using BattleShip.enums;

namespace BattleShip.ships
{
    public class PatrolBoat : Ship
    {

        public override int Length => (int)Types.PatrolBoat;

        public PatrolBoat(int x, int y) : this(x, y, Direction.Horizontal)
        {

        }

        public PatrolBoat(int x, int y, Direction direction) : base(x, y, direction)
        {

        }
        
    }
}
