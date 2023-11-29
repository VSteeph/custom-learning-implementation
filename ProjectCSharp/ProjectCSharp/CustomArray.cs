namespace ProjectCSharp;

public class CustomArray<T>
{
    public int Capacity { get; private set; }
    public int Size { get; private set; }

    private T[] data;

    private int currentIndex;

    public CustomArray(int x)
    {
        Capacity = x;
        data = new T[x];
    }
    public bool IsEmpty()
    {
        return Size == 0;
    }

    public void Push(T x)
    {
        data[currentIndex] = x;
        currentIndex++;
        Size++;
        CheckResize();
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
        
        ShiftRight(index, value);
        CheckResize();
    }

    public T Pop()
    {
        Size--;
        CheckResize();
        return data[Size];
    }

    private void CheckResize()
    {
        if (Size == Capacity)
        {
            Capacity *= 2;
            Resize();
        }


        if ( Size > 0 && Size <= Capacity / 4)
        {
            Capacity /= 2;
            Resize();
        }
            
    }

    private void Resize()
    {
        var newData = new T[Capacity];
        for (var i = 0; i < Size; i++)
        {
            newData[i] = data[i];
        }
        data = newData;
    }

    public int Find(T value)
    {
        for (var i = 0; i < Size; i++)
        {
            if (data[i].Equals(value))
                return i;
        }

        return -1;
    }

    public void Remove(T value)
    {
        for (int i = Size; i >= 0; i++)
        {
            if (data[i].Equals(value))
            {
                ShiftLeft(i);
                Size--;
                currentIndex--;
            }
        }

        CheckResize();
    }

    public void Delete(int index)
    {
        ShiftLeft(index);
        Size--;
        currentIndex--;
        CheckResize();
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < Size - 1; i++)
        {
            data[i] = data[i + 1];
        }
    }

    private void ShiftRight(int index, T value)
    {
        Size++;
        for (int i = currentIndex; i > index; i--)
        {
            data[i] = data[i - 1];
        }
        data[index] = value;
        currentIndex++;
    }
}