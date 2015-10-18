using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {

        public override string ShapeName => nameof(EquilateralTriangle);


        public EquilateralTriangle(double edge) : this(
            new Dictionary<ParamKeys, object> { 
                {ParamKeys.Edge1, edge},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = _edge1;
            _edge3 = _edge1;
        }

    }
}