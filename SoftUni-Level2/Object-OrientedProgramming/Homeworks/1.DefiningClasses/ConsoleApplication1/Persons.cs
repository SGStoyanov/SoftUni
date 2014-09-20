using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    private string name;
    private int age;
    private string email;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Wrong name!");
            }
            this.name = value;
        }
    }
    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Wrong age");
            }
            this.age = value;
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            if ( value != null && (value.IndexOf('@') == -1) )
            {
                throw new ArgumentException("Wrong Email");
            }
            this.email = value;
        }
    }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(this.email)) {
            return "My name is " + this.name + " and I am " + this.age + " years old.";
        }
        return "My name is " + this.name + " and I am " + this.age + " years old. My email is: " + this.email;
    }
}

public class Program
{

    static void Main()
    {
        Person p1 = new Person("Kozmin", 29, "kozminmozi@fcludogoretz.bg");
        Person p2 = new Person("Vladislav", 33);

        Console.WriteLine(p1);
        Console.WriteLine(p2);
    }
}