/* Problem 4.	Generic List Version
Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to GenericList<T> class and display its version at runtime.
*/

using System;

[AttributeUsage(
    AttributeTargets.Struct |
    AttributeTargets.Class |
    AttributeTargets.Interface |
    AttributeTargets.Enum |
    AttributeTargets.Method
)]

public class VersionAttribute : Attribute
{
    public string Version { get; private set; }

    public VersionAttribute(double version)
    {
        this.Version = string.Format("{0:#.##}", version);
    }    
}

[Version(2.11)]

public class GenericList<T>
{
    private const int DEFAULT_CAPACITY = 15;
    private T[] elements;

    public GenericList(int capacity = DEFAULT_CAPACITY)
    {
        elements = new T[capacity];
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
public class GenericListVersion
{
    static void Main()
    {
        Type type = typeof(GenericList<>);
        object[] allAttributes = type.GetCustomAttributes(typeof(VersionAttribute), false);
        Console.WriteLine("Generic List's version is: {0}", ((VersionAttribute)allAttributes[0]).Version);
    }
}