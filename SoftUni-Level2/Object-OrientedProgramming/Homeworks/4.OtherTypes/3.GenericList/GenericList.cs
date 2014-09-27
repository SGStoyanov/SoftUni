/* Problem 3.	Generic List
Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
•	Keep the elements of the list in an array with a certain capacity, which is given as an optional parameter in the class constructor. Declare the default capacity of 16 as constant.
•	Implement methods for:
o	adding an element 
o	accessing element by index
o	removing element by index
o	inserting element at given position
o	clearing the list
o	finding element index by given value
o	checking if the list contains a value
o	printing the entire list (override ToString()). 
•	Check all input parameters to avoid accessing elements at invalid positions.
•	Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
•	Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. You may need to add generic constraints for the type T to implement IComparable<T>.
*/

using System;
using System.Text;

public class GenericList<T> where T : IComparable<T>
{
    // Defining fields
    private const int DefaultCapacity = 16;

    private T[] elements;
    private int count = 0;

    // Default constructor
    public GenericList(int capacity = DefaultCapacity)
    {
        elements = new T[capacity];
    }

    // Defining properties
    public int Count
    {
        get { return this.count; }
    }

    public int Capacity
    {
        get { return this.elements.Length; }
    }

    // Defining methods

    // Adding an element
    public void Add(T element)
    {
        if (this.count >= this.Capacity)
        {
            this.Expand();
        }

        this.elements[count] = element;
        this.count++;
    }

    // Accessing element by index
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Wrong index!");
            }
            return elements[index];
        }
    }

    // Removing element by index
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException();
        }

        for (int i = index; i < this.count - 1; i++)
        {
            this.elements[i] = this.elements[i + 1];
        }

        this.count--;
        this.elements[count] = default(T);
    }

    // Inserting element at given position
    public void InsertAt(int index, T element)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (this.count >= this.Capacity)
        {
            this.Expand();
        }

        for (int i = this.count; i > index; i--)
        {
            this.elements[i] = this.elements[i - 1];
        }

        this.count++;
        this.elements[index] = element;
    }

    // Clearing the list
    public void Clear()
    {
        this.elements = new T[this.Capacity];
        this.count = 0;
    }

    // Finding element index by given value
    public dynamic IndexOf(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return i;
            }
        }
        return "No such element";
    }

    public string Contains(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return "Element found";
            }
        }
        return "Element not found";
    }

    // Expanding the current array if the new size exceeds the current size
    public void Expand()
    {
        T[] expandedArray = new T[this.Capacity*2];
        Array.Copy(this.elements, expandedArray, this.Capacity);
        this.elements = expandedArray;
    }

    // ToString() override
    public override string ToString()
    {
        StringBuilder result = new StringBuilder(this.count);
        for (int i = 0; i < this.count; i++)
        {
            result.Append(this.elements[i] + ", ");
        }
        return result.ToString().Trim(' ', ',');
    }

    public T Min()
    {
        if (this.count < 1)
        {
            throw new InvalidOperationException("No elements in the list");
        }

        T min = this.elements[0];
        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(min) < 0)
            {
                min = elements[i];
            }
        }
        return min;
    }

    public T Max()
    {
        if (this.count < 1)
        {
            throw new InvalidOperationException("No elements in the list");
        }
        
        T max = this.elements[0];
        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(max) > 0)
            {
                max = elements[i];
            }
        }
        return max;
    }
}

// Testing
class GenericListStarter
{
    static void Main()
    {
        GenericList<int> myList = new GenericList<int>(5);
        myList.Add(9);
        myList.Add(15);
        myList.Add(118);
        myList.Add(-219);
        myList.Add(19291);
        myList.Add(6);
        Console.WriteLine(myList);
        Console.WriteLine(myList.IndexOf(-219));
        myList.RemoveAt(2);
        Console.WriteLine(myList);
        myList.InsertAt(4, 23929);
        Console.WriteLine(myList);
        Console.WriteLine(myList.Contains(15));
        Console.WriteLine(myList[1]);
        Console.WriteLine(myList.Min() + " <> " + myList.Max());
        myList.Clear();
        Console.WriteLine(myList);
    }
}