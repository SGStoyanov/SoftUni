using System;
using System.Text;

namespace LaptopShop
{
    class Laptop
    {
        // Defining fields
        private string model;
        private decimal price;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;

        // Defining properties
        public string Model
        {
            get { return this.model; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Wrong model");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong price");
                }
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Wrong manufacturer");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Wrong processor");
                }
                this.processor = value;
            }
        }

        public string Ram
        {
            get { return this.ram; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Wrong ram");
                }
                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Wrong graphics card");
                }
                this.graphicsCard = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Wrong hdd");
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Wrong screen");
                }
                this.screen = value;
            }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        // Building the constructors for Laptop
        public Laptop (string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer = null, string processor = null, string ram = null, 
                string hdd = null, string graphicsCard = null, Battery battery = null, string screen = null)
                : this(model, price)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
        }

        public override string ToString()
        {
            StringBuilder laptopStr = new StringBuilder();

            laptopStr.AppendLine("model: " + this.Model);

            if (this.Manufacturer != null) 
            {
                laptopStr.AppendLine("manufacturer: " + this.Manufacturer);
            }
            if (this.Processor != null)
            {
                laptopStr.AppendLine("processor: " + this.Processor);
            }
            if (this.Ram != null)
            {
                laptopStr.AppendLine("ram: " + this.Ram);
            }
            if (this.GraphicsCard != null)
            {
                laptopStr.AppendLine("graphics card: " + this.GraphicsCard);
            }
            if (this.Hdd != null) {
                laptopStr.AppendLine("hdd: " + this.Hdd);
            }
            if (this.Screen != null)
            {
                laptopStr.AppendLine("screen: " + this.Screen);
            }
            if (this.Battery != null) {
                laptopStr.Append(this.Battery.ToString());
            }
            laptopStr.AppendLine("price: " + this.Price + " lv.");

            return laptopStr.ToString();
        }
    }

    class LaptopShop
    {
        static void Main()
        {
            Battery lion = new Battery("Li-Ion, 4-cells, 2550 mAh");
            Battery nimh = new Battery("Ni-Mh", 4.5f);
            Laptop lapFirst = new Laptop("HP 250 G2", 699.00m);
            Laptop lapSecond = new Laptop("Lenovo Yoga 2 Pro", 2259.00m, "Lenovo",
                    "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", "8 GB", "128GB SSD", 
                    "Intel HD Graphics 4400", lion, "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display");
            Laptop thirdLap = new Laptop("Dell model", 1523.95m, battery: nimh, processor: "3.2GHz", ram: "4GB");

            Console.WriteLine(lapFirst.ToString());
            Console.WriteLine();
            Console.WriteLine(lapSecond.ToString());
            Console.WriteLine();
            Console.WriteLine(thirdLap.ToString());
        }
    }
}