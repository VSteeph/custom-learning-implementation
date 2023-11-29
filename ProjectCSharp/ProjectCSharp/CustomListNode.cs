using System.Diagnostics;

namespace ProjectCSharp;

[DebuggerDisplay("Value : {item}")]
public class CustomListNode<T>
{
    public CustomListNode<T> previous;
    public CustomListNode<T> next;
    public T item;

    public CustomListNode(T value)
    {
        item = value;
    }
}