using System.Collections.Generic;
namespace OOP
{
	public abstract class ShapeBase : IShape
	{

        public int CoordX { get; protected set; }
        public int CoordY { get; protected set; }
        public byte Multiplier { get; set; } = 1;


        public abstract string ShapeName { get; }

        public abstract double GetPerimeter();

        protected abstract double Area();


        protected ShapeBase() : this(0, 0)
        {
        }

        protected ShapeBase(int coordX, int coordY)
        {
            this.CoordX = coordX;
            this.CoordY = coordY;
        }

	    protected ShapeBase(IDictionary<ParamKeys, object> parameters) : this(
            parameters.Keys.Contains(ParamKeys.CoordX) ? (int)parameters[ParamKeys.CoordX] : 0,
            parameters.Keys.Contains(ParamKeys.CoordY) ? (int)parameters[ParamKeys.CoordY] : 0)
        {
        }


        public virtual void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ToString() => 
            $"Shape information: Name : {ShapeName}, X : {CoordX}, Y : {CoordY}, Perimeter : {GetPerimeter()}, Square : {GetArea()}";

        public double GetArea() =>  Area();

	}
}