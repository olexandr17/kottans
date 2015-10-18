using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Triangle : ShapeBase
    {

        protected double _edge1;
        protected double _edge2;
        protected double _edge3;

        public override string ShapeName => nameof(Triangle);


        public Triangle(double edge1, double edge2, double edge3) : this(
            new Dictionary<ParamKeys, object> {
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.Edge3, edge3},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = (double)parameters[ParamKeys.Edge3];
        }


        public override double GetPerimeter() => Multiplier * (_edge1 + _edge2 + _edge3);


        protected override double Area()
        {
            var pHalf = GetPerimeter() / 2;
            var areaHeron = Math.Sqrt(pHalf * (pHalf - _edge1) * (pHalf - _edge2) * (pHalf - _edge3));
            return Multiplier * Multiplier * areaHeron;
        }

    }
}