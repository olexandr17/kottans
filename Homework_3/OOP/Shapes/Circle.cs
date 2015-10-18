using System;
using System.Collections.Generic;
namespace OOP.Shapes
{
	public class Circle : ShapeBase
	{

        double _radius;

        public override string ShapeName => nameof(Circle);


        public Circle(double radius) : this(
            new Dictionary<ParamKeys, object> { 
                {ParamKeys.Radius1, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

		public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _radius = (double) parameters[ParamKeys.Radius1];
		}


        public override double GetPerimeter() => Multiplier * 2 * _radius * Math.PI;


        protected override double Area() =>  Multiplier * Multiplier * _radius * _radius * Math.PI;

    }
}