using BattleShip.enums;
using BattleShip.exceptions;
using System.Linq;
using System.Text.RegularExpressions;

namespace BattleShip.ships
{
    public abstract class Ship
    {

        public static bool operator ==(Ship a, Ship b)
        {
            var positionEquals = a.X == b.X && a.Y == b.Y;
            var directionEquals = (a.Length > 1 && b.Length > 1) ? a.Direction == b.Direction : true;
            var typeEquals = a.GetType() == b.GetType();

            return positionEquals && directionEquals && typeEquals;
        }

        public static bool operator !=(Ship a, Ship b)
        {
            return !(a == b);
        }


        public static bool TryParse(string notation, out Ship ship)
        {
            try
            {
                ship = Parse(notation);
                return true;
            }
            catch (NotAShipException)
            {
                ship = null;
                return false;
            }
        }

        public static Ship Parse(string notation)
        {
            notation = notation.ToUpper();

            int positionX = 0;
            int positionY = 0;
            var positionParsed = ParsePosition(notation, ref positionX, ref positionY);

            int length = ParseLength(notation);

            Direction direction = ParseDirection(notation);

            if (positionParsed &&
                positionX >= Board.POSITION_MIN && positionX <= Board.POSITION_MAX &&
                positionY >= Board.POSITION_MIN && positionY <= Board.POSITION_MAX &&
                length >= (int)Types.PatrolBoat && length <= (int)Types.AircraftCarrier)
            {
                Ship ship = null;

                switch (length)
                {
                    case (int)Types.PatrolBoat:
                        ship = new PatrolBoat(positionX, positionY);
                        break;
                    case (int)Types.Cruiser:
                        ship = new Cruiser(positionX, positionY, direction);
                        break;
                    case (int)Types.Submarine:
                        ship = new Submarine(positionX, positionY, direction);
                        break;
                    case (int)Types.AircraftCarrier:
                        ship = new AircraftCarrier(positionX, positionY, direction);
                        break;
                }

                return ship;
            }
            else
            {
                throw new NotAShipException();
            }
        }


        private static bool ParsePosition(string notation, ref int x, ref int y)
        {
            var match = Regex.Match(notation, @"^[A-Z]\d+");
            if (match.Success)
            {
                x = match.Value[0] - 'A' + 1;
                int.TryParse(match.Value.Substring(1).ToString(), out y);

                return true;
            }

            return false;
        }

        private static int ParseLength(string notation)
        {
            var match = Regex.Match(notation, @"X\d+");
            if (match.Success)
            {
                int length;
                int.TryParse(match.Value.Substring(1).ToString(), out length);
                return length;
            }

            return (int)Types.PatrolBoat;
        }

        private static Direction ParseDirection(string notation)
        {
            var match = Regex.Match(notation, @"[\-\|]");

            return (match.Success && match.Value.Equals("|"))
                ? Direction.Vertical
                : Direction.Horizontal;

        }
        

        public abstract int Length { get; }

        public int X { get; }
        public int Y { get; }
        public Direction Direction;

        public int EndX => X + (Direction == Direction.Horizontal ? Length : 1) - 1;
        public int EndY => Y + (Direction == Direction.Vertical ? Length : 1) - 1;


        public Ship(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public bool FitsInSquare(int squareHeight, int squareWidth)
        {
            return EndX <= squareWidth && EndY <= squareHeight;
        }

        public bool OverlapsWith(Ship ship)
        {
            if (Equals(ship))
            {
                return true;
            }
            
            var widthRange = Enumerable.Range(X, EndX - X + 1 + Board.GAP);
            var heightRange = Enumerable.Range(Y, EndY - Y + 1 + Board.GAP);

            var widthShipRange = Enumerable.Range(ship.X, ship.EndX - ship.X + 1 + Board.GAP);
            var heightShipRange = Enumerable.Range(ship.Y, ship.EndY - ship.Y + 1 + Board.GAP);

            return widthRange.Intersect(widthShipRange).Count() > 0 && heightRange.Intersect(heightShipRange).Count() > 0;
        }


        public override bool Equals(object obj)
        {
            if (obj is Ship)
            {
                return this == (Ship)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
