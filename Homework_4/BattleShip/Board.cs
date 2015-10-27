using System;
using System.Collections.Generic;
using System.Linq;
using BattleShip.ships;
using BattleShip.exceptions;

namespace BattleShip
{
    public class Board
    {

        public const int POSITION_MIN = 1;
        public const int POSITION_MAX = 10;

        public const int GAP = 1;

        public const int PATROLBOAT_COUNT = 4;
        public const int CRUISER_COUNT = 3;
        public const int SUBMARINE_COUNT = 2;
        public const int AIRCRAFTCARRIER_COUNT = 1;

        private List<Ship> ships = new List<Ship>();


        public void Add(Ship ship)
        {
            if (ship.X < POSITION_MIN || ship.EndX > POSITION_MAX || 
                ship.Y < POSITION_MIN || ship.EndY > POSITION_MAX)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < ships.Count; i++)
            {
                if (ship.OverlapsWith(ships[i]))
                {
                    throw new ShipOverlapException();
                }
            }

            ships.Add(ship);
        }

        public void Add(string notation)
        {
            Add(Ship.Parse(notation));
        }

        public List<Ship> GetAll()
        {
            return new List<Ship>(ships);
        }

        public void Validate()
        {
            bool isPatrolboatsFull = ships.Where(s => s is PatrolBoat).Count() == PATROLBOAT_COUNT;
            bool isCruisersFull = ships.Where(s => s is Cruiser).Count() == CRUISER_COUNT;
            bool isSubmarinesFull = ships.Where(s => s is Submarine).Count() == SUBMARINE_COUNT;
            bool isAircraftCarriersFull = ships.Where(s => s is AircraftCarrier).Count() == AIRCRAFTCARRIER_COUNT;

            if (!isPatrolboatsFull || !isCruisersFull || !isSubmarinesFull || !isAircraftCarriersFull)
            {
                throw new BoardIsNotReadyException();
            }
        }
    }
}
