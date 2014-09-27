/* Problem 1.	Galactic GPS
Create a struct Location that holds fields of type double latitude and longitude of a given location. Create an enumeration Planet that holds the following constants: Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune.
•	Add an enum field of type Planet. Encapsulate all fields. 
•	Add a constructor that holds 3 parameters: latitude, longitude and planet.
•	Override ToString() to print the current location in the format <latitude>, <longitude> - <location> */

using System;

namespace OtherTypes
{

    // Enum
    public enum Planet
    {
        Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
    }

    struct Location
    {
        // Fields
        private double latitude;
        private double longitude;
        private Planet planet;

        // Properties
        public double Latitude
        {
            get { return this.latitude; }
            set { this.latitude = value; }
        }

        public double Longitude
        {
            get { return this.longitude; }
            set { this.longitude = value; }
        }

        public Planet Planet
        {
            get { return this.planet; }
            set { this.planet = value; }
        }

        // Constructor
        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.planet = planet;
        }
    
        // ToString() Method
        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}", this.latitude, this.longitude, this.planet);
        }
    }  

    class GalacticGPS
    {
        static void Main()
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Location loc2 = new Location(2.4939, 4843.39292196, Planet.Mars);

            Console.WriteLine(home);
            Console.WriteLine(loc2);
        }
    }
}