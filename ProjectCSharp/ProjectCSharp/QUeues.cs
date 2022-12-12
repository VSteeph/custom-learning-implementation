namespace ProjectCSharp;

public class Queues<T>
{
    private CustomListNode<T> head = null;
    
    public void Enqueue(T value)
    {
        var NewNode = new CustomListNode<T>(value);
        NewNode.next = head;
        head = NewNode;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        throw new NullReferenceException();
        
        var nodeToReturn = head;
        head = head.next;
        return nodeToReturn.item;
    }

    public bool IsEmpty()
    {
        return head is null ? true : false;
    }

}