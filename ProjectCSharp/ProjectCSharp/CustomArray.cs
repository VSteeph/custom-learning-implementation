namespace ProjectCSharp;

public class CustomArray<T>
{
    public int Capacity { get; private set; }
    public int Size { get; private set; }

    private T[] data;

    private int currentIndex = 0;

    public CustomArray(int x)
    {
        Capacity = x;
        data = new T[x];
    }
    public bool IsEmpty()
    {
        return Size == 0 ? true : false;
    }

    public void Push(T x)
    {
        Resize();
        data[currentIndex] = x;
        currentIndex++;
        Size++;
    }

    public T At(int x)
    {
        if (x > Size)
            throw new IndexOutOfRangeException();
        return data[x];
    }

    public void Insert(int index, T value)
    {
        if (index > Size)
            return;
        
        Resize();
        T newValue = value;
        T oldValue;
        for (int i = index; i < Size; i++)
        {
            oldValue = data[i];
            data[i] = newValue;
            newValue = oldValue;
        }
        Push(newValue);
    }

    public T Pop()
    {
        Size--;
        Resize();
        return data[Size];
    }

    private void Resize()
    {
        if (Size == Capacity)
            Capacity *= 2;

        if (Size <= (Capacity / 4))
            Capacity /= 2;

        T[] newData = new T[Capacity];
        for (int i = 0; i < Size; i++)
        {
            newData[i] = data[i];
        }
        data = newData;
    }
}