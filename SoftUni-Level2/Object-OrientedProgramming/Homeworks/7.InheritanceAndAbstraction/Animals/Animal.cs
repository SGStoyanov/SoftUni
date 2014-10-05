using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal : ISound
    {
        private string name;
        private double age;
        private char gender;
        //private string sound;

        protected Animal(string name, double age, char gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Name couldn't be null");
                }
                this.name = value;
            }
        }

        public double Age
        {
            get { return this.age; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("Age", "Age couldn't be null");
                }

                if (value <= 0)
                {
                    throw new ArgumentException("Age coulnd't be negative");
                }
                this.age = value;
            }
        }

        public char Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("Gender", "The gender can't be null");
                }
                this.gender = value;
            }
        }

        public void ProduceSound()
        {
            string curType = this.GetType().Name;

            switch (curType)
            {
                case "Cat":
                    Console.WriteLine("Myauuuu!");
                    break;
                case "Dog":
                    Console.WriteLine("Djaf, Djaf!");
                    break;
                case "Frog":
                    Console.WriteLine("Kwak, kwak!");
                    break;
                case "Kitten":
                    Console.WriteLine("Female myauuuu!");
                    break;
                case "Tomcat":
                    Console.WriteLine("Male myauuuu");
                    break;
                default:
                    Console.WriteLine("Sooooooound!");
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}\nName: {1}\nAge (years): {2}\nGender: {3}\n", 
                                 this.GetType().Name, this.name, this.age, this.gender);
        }
    }
}