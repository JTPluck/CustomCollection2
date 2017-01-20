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
            LookupList<string, Coordinate> listCoordinates = new LookupList<string, Coordinate>();
            listCoordinates.Add("Florence", new Coordinate() { Latitude = 43.76956, Longitude = 11.255814 });
            listCoordinates.Add("New York", new Coordinate() { Latitude = 36.102372, Longitude = -115.174556 });
            listCoordinates.Add("Sydney", new Coordinate() { Latitude = -33.86882015, Longitude = 151.207323 });
            listCoordinates.Add("Bangkok", new Coordinate() { Latitude = 13.756331, Longitude = 100.501765 });
            listCoordinates.Add("Budapest", new Coordinate() { Latitude = 47.497912, Longitude = 19.040235 });

            foreach (var value in listCoordinates.Values)
                Console.WriteLine("Latitude: {0},   Longitude: {1}", value.Latitude, value.Longitude);
            Console.WriteLine("-------------------------------------------------------------------------");


            foreach (var key in listCoordinates.Keys)
                Console.WriteLine(key);
            Console.WriteLine("-------------------------------------------------------------------------");

            Console.WriteLine("Latitude Sydney {0}", listCoordinates["sydney"].Latitude);
            Console.WriteLine("-------------------------------------------------------------------------");

            Console.WriteLine("Sydney Australia -  {0}, {1}", "Latitude:" + listCoordinates["Sydney"].Latitude, "Longitude:" + listCoordinates["Sydney"].Longitude);
            Console.WriteLine("-------------------------------------------------------------------------");

            listCoordinates.Remove("Sydney");
            listCoordinates.Remove("New York");
            listCoordinates.Remove("Bangkok");
            
            foreach (var key in listCoordinates.Keys)
                Console.WriteLine(key);
            Console.WriteLine("-------------------------------------------------------------------------");

            var list = new LookupList<int, string>()
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" }
                };

            foreach (var value in list.Values)
                Console.WriteLine(value);
            Console.WriteLine("-------------------------------------------------------------------------");

            Console.WriteLine(list[2]);
            Console.WriteLine("-------------------------------------------------------------------------");
            
            var listString = new LookupList<string, string>()
                {
                    { "#000", "Black" },
                    { "#FFF", "White" },
                    { "#CCC", "Gray" }
                };

            Console.WriteLine(listString["#FFF"]);

            Console.ReadLine();
            //listCoordinates.Clear();

        }
    }
}
