namespace ProjectCSharp;

public class CustomArray<T>
{
    public int Capacity { get; set; }
    public int Size { get; set; }

    public CustomArray(int x)
    {
        Capacity = x;
    }

    public bool IsEmpty()
    {
        return true;
    }
    
}