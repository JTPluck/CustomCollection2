using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionaryCollection
{
    public class Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Coordinate))
            {
                return false;
            }

            return this.Latitude == ((Coordinate)obj).Latitude &&
                this.Longitude == ((Coordinate)obj).Longitude;
        }

        public override int GetHashCode()
        {
            return this.Latitude.GetHashCode() ^ this.Longitude.GetHashCode();
        }
    }
}
