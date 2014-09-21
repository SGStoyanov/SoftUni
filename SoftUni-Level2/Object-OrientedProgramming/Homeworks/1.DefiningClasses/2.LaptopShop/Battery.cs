using System;
using System.Text;

namespace LaptopShop
{
    public class Battery
    {
        private string type;
        private float hours;

        public string Type
        {
            get { return this.type; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Wrong battery type");
                }
                this.type = value;
            }
        }

        public float Hours
        {
            get { return this.hours; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong battery life");
                }
                this.hours = value;
            }
        }

        public Battery(string type)
        {
            this.Type = type;
        }

        public Battery(string type, float hours)
            : this(type)
        {
            this.Hours = hours;
        }

        public override string ToString()
        {
            StringBuilder resulStr = new StringBuilder();

            if (this.Type != null)
            {
                resulStr.AppendLine("battery: " + this.Type);
            }
            if (this.Hours > 0)
            {
                resulStr.AppendLine("battery life: " + this.Hours + " hours");
            }

            return resulStr.ToString();
        }
    }
}
