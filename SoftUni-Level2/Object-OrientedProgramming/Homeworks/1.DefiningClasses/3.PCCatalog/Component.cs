using System;
using System.Text;

namespace PCCatalog
{
    public abstract class Component
    {
        private string name;
        private decimal price;
        private string details = null;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Wrong component name");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong component price");
                }
                this.price = value;
            }
        }

        public string Details // Could be null
        {
            get { return this.details; }
            set { this.details = value; }
        }

        // Defining constructors
        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public override string ToString()
        {
            StringBuilder strResult = new StringBuilder();
            strResult.AppendLine("Component: " + this.Name + ", Price: " + this.Price + " лв.");

            if (this.Details != null)
            {
                strResult.Append("Details: " + this.Details);
            }
            
            return strResult.ToString();
        }
    }
}