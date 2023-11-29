namespace ProjectCSharp;

public class CustomList<T>
{
    private CustomListNode<T> head;
    private CustomListNode<T> tail;
    public int Size { get; private set; }

    public bool IsEmpty()
    {
        if (Size == 0)
            return true;
        return false;
    }

    public void PushFront(T value)
    {
        var node = new CustomListNode<T>(value);
        if (head is not null)
        {
            head.previous = node;
            node.next = head;
        }

        head = node;
        if (tail is null)
            tail = node;
        Size++;
    }

    public T PopFront()
    {
        var currentNode = head;
        head = head.next;
        head.previous = null;
        Size--;
        return currentNode.item;
    }

    public void PushBack(T value)
    {
        var node = new CustomListNode<T>(value);
        if (tail is not null)
        {
            tail.next = node;
            node.previous = tail;
        }

        tail = node;
        if (head is null)
            head = node;
        Size++;
    }

    public T PopBack()
    {
        var currentNode = tail;
        tail = tail.previous;
        tail.next = null;
        Size--;
        return currentNode.item;
    }

    public T Front()
    {
        if (head is null)
            throw new IndexOutOfRangeException();

        return head.item;
    }

    public T Back()
    {
        if (tail is null)
            throw new IndexOutOfRangeException();

        return tail.item;
    }

    public T ValueAt(int index)
    {
        if (index + 1 > Size)
            throw new IndexOutOfRangeException();

        if (index > Size / 2)
        {
            return GetIndexNodeFromEnd(tail, index, Size - 1).item;
        }

        return GetIndexNodeFromStart(head, index, 0).item;
    }

    public void Insert(int index, T value)
    {
        if (index + 1 > Size)
            throw new IndexOutOfRangeException();

        CustomListNode<T> node = GetSpecificNode(index);
        
        var newNode = new CustomListNode<T>(value);
        newNode.next = node;
        newNode.previous = node.previous;
        node.previous = newNode.previous.next = newNode;
        Size++;
    }

    public void Erase(int index)
    {
        if (index + 1 > Size)
            throw new IndexOutOfRangeException();

        CustomListNode<T> node = GetSpecificNode(index);
        
        node.next.previous = node.previous;
        node.previous.next = node.next;
        Size--;
    }

    public void Reverse()
    {
        var oldHead = head;
        head = tail;
        tail = oldHead;
        ReverseRecursif(head);
    }

    private void ReverseRecursif(CustomListNode<T> currentNode)
    {

        if (currentNode != tail)
        {
            if (currentNode == head)
            {
                currentNode.next = currentNode.previous;
                currentNode.previous = null;
            }
            else
            {
                (currentNode.next, currentNode.previous) = (currentNode.previous, currentNode.next);
            }

            ReverseRecursif(currentNode.next);
        }
        else
        {
            tail.previous = currentNode.previous;
        }
        
    }

    private CustomListNode<T> GetSpecificNode(int index)
    {
        CustomListNode<T> node;
        
        if (index > Size / 2)
        {
            node =  GetIndexNodeFromEnd(tail, index, Size - 1);
        }
        else
        {
            node =  GetIndexNodeFromStart(head, index, 0);
        }

        return node;
    }
    private CustomListNode<T> GetIndexNodeFromStart(CustomListNode<T> node, int targetIndex, int index)
    {
        if (index == targetIndex)
        {
            return node;
        }

        index++;
        return GetIndexNodeFromStart(node.next, targetIndex, index);
    }

    private CustomListNode<T> GetIndexNodeFromEnd(CustomListNode<T> node, int targetIndex, int index)
    {
        if (index > targetIndex)
        {
            index--;
            return GetIndexNodeFromEnd(node.previous, targetIndex, index);
        }

        return node;
    }
}