///////////////////////////////////////////////////////////////////////////////////////////////////
// Test your Knowledge
///////////////////////////////////////////////////////////////////////////////////////////////////
/*
1. Describe the problem generics address.
Generics is trying to solve the problem of needing to extend or modify an object in order to change the underlying type. =
For example, lets say you have a class IntegerList where the underlying data structure is an array of int.
Then a new requirement comes in and you need to make an DoubleList which share alot of similar code to the IntegerList but the difference is that it is use an array of double as the underlying type./
One way to reduce code is to factor out the code into a base List class, and have IntegerList and DoubleList derive from it.
However, this can still lead to alot of redudant code for both classess.
So generic solves this by decoupling the class from it's underlying type and allow the type to be define when instantiating the object.
So if we use generic, we only need to write one List<T> class that accept any type of value T, and we could instantiating List<int>, List<double>, or even List<float> all from this one class.

2. How would you create a list of strings, using the generic List class?
We could manually call the Add method to add each string into the list, or use object initializer.
Ex: List<string> strings = new() { "s1", "s2", "..." };

3. How many generic type parameters does the Dictionary class have?
Two, first one to define the keys type, and second one to define the values type.

4. True/False. When a generic class has multiple type parameters, they must all match.
False

5. What method is used to add items to a List object?
Add
AddRange

6. Name two methods that cause items to be removed from a List.
Remove
Clear

7. How do you indicate that a class has a generic type parameter?
Using the 2 angle brackets and put the typename inside: <T1, T2>

8. True/False. Generic classes can only have one generic type parameter.
False

9. True/False. Generic type constraints limit what can be used for the generic type.
True

10. True/False. Constraints let you use the methods of the thing you are constraining to.
True if the input type follows the constraint rules
*/

///////////////////////////////////////////////////////////////////////////////////////////////////
// Practice working with Generics
///////////////////////////////////////////////////////////////////////////////////////////////////
// 1
class MyStack<T>
{
    private Stack<T> Stack { get; } = new();

    public int Count()
    {
        return Stack.Count;
    }

    public T Pop()
    {
        return Stack.Pop();
    }

    public void Push(T item)
    {
        Stack.Push(item);
    }
}

// 2
class MyList<T>
{
    private List<T> List { get; } = new();

    public void Add(T element)
    {
        List.Add(element);
    }

    public T Remove(int index)
    {
        T item = Find(index);
        DeleteAt(index);
        return item;
    }

    public bool Contains(T element)
    {
        return List.Contains(element);
    }

    public void Clear()
    {
        List.Clear();
    }

    public void InsertAt(T element, int index)
    {
        List.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        List.RemoveAt(index);
    }

    public T Find(int index)
    {
        return List[index];
    }
}

// 3
interface IEntity
{
    int Id { get; }
}

interface IRepository<T> where T : IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

class GenericRepository<T> : IRepository<T> where T : IEntity
{
    private List<T> List { get; } = new();

    public void Add(T item)
    {
        List.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return List;
    }

    public T GetById(int id)
    {
        return List.Where(entity => entity.Id == id).First();
    }

    public void Remove(T item)
    {
        List.Remove(item);
    }

    public void Save()
    {
        Console.WriteLine("Saving to some imaginary database");
    }
}
