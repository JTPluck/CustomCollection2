using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionaryCollection
{
    public class CoordinateComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate c1, Coordinate c2)
        {
            if (c1 == null || c2 == null)
                return false;
            if (!(c1 is Coordinate) || !(c2 is Coordinate))
            {
                return false;
            }

            return c1.Latitude == c2.Latitude &&
                c1.Longitude == c2.Longitude;
        }

        public int GetHashCode(Coordinate id)
        {
            return id.GetHashCode();
        }
    }
}
