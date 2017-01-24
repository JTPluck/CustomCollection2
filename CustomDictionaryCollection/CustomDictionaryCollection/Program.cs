using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionaryCollection
{
    class Program
    {
       
        static void Main(string[] args)
        {
            LookupList<string, Coordinate> listCoordinates = new LookupList<string, Coordinate>(new StringIndexComparer());
            listCoordinates.Add("Florence", new Coordinate() { Latitude = 43.76956, Longitude = 11.255814 });
            listCoordinates.Add("New York", new Coordinate() { Latitude = 36.102372, Longitude = -115.174556 });
            listCoordinates.Add("Sydney", new Coordinate() { Latitude = -33.86882015, Longitude = 151.207323 });
            listCoordinates.Add("sydney", new Coordinate() { Latitude = 13.756331, Longitude = 100.501765 });
            listCoordinates.Add("Budapest", new Coordinate() { Latitude = 47.497912, Longitude = 19.040235 });

            Console.WriteLine("Latitude Sydney {0}", listCoordinates["Sydney"].Latitude);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Latitude Sydney {0}", listCoordinates["sydney"].Latitude);
            Console.WriteLine("-------------------------------------------------------------------------");

           
            // This fails just like a real dictionary implementation
            //var listString = new LookupList<string, string>(StringComparer.OrdinalIgnoreCase)
            //    {
            //        { "HORSE", "Black Horse" },
            //        { "horse", "White Horse" },
            //        { "Car", "Red" }
            //    };


            var listString2 = new LookupList<string, string>(new StringIndexComparer())
                {
                    { "HORSE", "Black Horse" },
                    { "horse", "White Horse" },
                    { "Car", "Gray" }
                };

            //Console.WriteLine(listString["HORSE"]);
            //Console.WriteLine(listString["horse"]);

            Console.WriteLine(listString2["HORSE"]);
            Console.WriteLine(listString2["horse"]);
            Console.ReadLine();
            //listCoordinates.Clear();

        }
    }
}
