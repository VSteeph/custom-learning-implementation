using ProjectCSharp;

namespace TestProject;

[TestClass]
public class LIstTest
{
    [TestMethod]
    public void List_ShouldReturnSizeO_WhenNoObjectAreInserted()
    {
        var sut = new CustomList<int>();
        Assert.AreEqual(0, sut.Size);
    }

    [TestMethod]
    public void List_ShouldBeEmpty_WhenNoObjectAreInserted()
    {
        var sut = new CustomList<int>();
        Assert.AreEqual(true, sut.IsEmpty());
    }

    [TestMethod]
    public void AnItem_ShouldBeAdded_WhenPushToAList()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        Assert.AreEqual(2, sut.ValueAt(0));
    }

    [TestMethod]
    public void List_ShouldRetrieveItem_WhenInserted()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        sut.PushFront(3);
        sut.PushFront(1);
        sut.PushFront(6);
        Assert.AreEqual(6, sut.ValueAt(0));
        Assert.AreEqual(1, sut.ValueAt(1));
        Assert.AreEqual(3, sut.ValueAt(2));
        Assert.AreEqual(2, sut.ValueAt(3));
    }

    [TestMethod]
    public void List_ShouldTHrowAnError_WhenRetrieveItemAtHigherIndexThanCurrentSize()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        Assert.ThrowsException<IndexOutOfRangeException>(() => sut.ValueAt(10));
    }

    [TestMethod]
    public void List_ShouldTHrowAnError_WhenRetrieveItemForAnEmptyList()
    {
        var sut = new CustomList<int>();
        Assert.ThrowsException<IndexOutOfRangeException>(() => sut.ValueAt(0));
    }

    [TestMethod]
    public void List_ShouldReduceSize_WhenPopFront()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        sut.PushFront(3);
        sut.PopFront();
        Assert.AreEqual(1, sut.Size);
    }

    [TestMethod]
    public void List_ShouldRemoveFirstItem_WhenPopFront()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        sut.PushFront(3);
        Assert.AreEqual(3, sut.ValueAt(0));
        sut.PopFront();
        Assert.AreEqual(2, sut.ValueAt(0));
    }

    [TestMethod]
    public void List_ShouldReturnPopedValue_WhenPopFront()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        sut.PushFront(3);
        Assert.AreEqual(3, sut.PopFront());
    }

    [TestMethod]
    public void List_ShouldIncreaseSize_WhenPushBack()
    {
        var sut = new CustomList<int>();
        sut.PushBack(1);
        Assert.AreEqual(1, sut.Size);
    }

    [TestMethod]
    public void List_ShouldAddItemAtTheEnd_WhenPushBack()
    {
        var sut = new CustomList<int>();
        sut.PushBack(2);
        sut.PushBack(3);
        sut.PushBack(1);
        sut.PushBack(6);
        Assert.AreEqual(2, sut.ValueAt(0));
        Assert.AreEqual(3, sut.ValueAt(1));
        Assert.AreEqual(1, sut.ValueAt(2));
        Assert.AreEqual(6, sut.ValueAt(3));
    }

    [TestMethod]
    public void List_ShouldReduceSize_WhenPopBack()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        sut.PushFront(3);
        sut.PopBack();
        Assert.AreEqual(1, sut.Size);
    }

    [TestMethod]
    public void List_ShouldRemoveFirstItem_WhenPopBack()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        sut.PushFront(3);
        Assert.AreEqual(2, sut.ValueAt(1));
        sut.PopBack();
        Assert.AreEqual(3, sut.ValueAt(0));
    }

    [TestMethod]
    public void List_ShouldReturnPopedValue_WhenPopBack()
    {
        var sut = new CustomList<int>();
        sut.PushFront(2);
        sut.PushFront(3);
        Assert.AreEqual(2, sut.PopBack());
    }

    [TestMethod]
    public void List_ShouldReturnPopedValueWithPushBack_WhenPopBack()
    {
        var sut = new CustomList<int>();
        sut.PushBack(2);
        sut.PushBack(3);
        sut.PushBack(4);
        Assert.AreEqual(4, sut.PopBack());
    }

    [TestMethod]
    public void List_ShouldReturnPopedValueWithPushBack_WhenPopFront()
    {
        var sut = new CustomList<int>();
        sut.PushBack(2);
        sut.PushBack(3);
        sut.PushBack(4);
        Assert.AreEqual(2, sut.PopFront());
    }

    [TestMethod]
    public void List_ShouldReturnHeadValue_WhenFront()
    {
        var sut = new CustomList<int>();
        sut.PushBack(2);
        sut.PushBack(3);
        sut.PushBack(4);
        Assert.AreEqual(2, sut.Front());
    }

    [TestMethod]
    public void List_ShouldReturnTailValue_WhenBack()
    {
        var sut = new CustomList<int>();
        sut.PushBack(2);
        sut.PushBack(3);
        sut.PushBack(4);
        Assert.AreEqual(4, sut.Back());
    }

    [TestMethod]
    public void List_ShouldReturnException_WhenBackOrFrontAndEmpty()
    {
        var sut = new CustomList<int>();
        Assert.ThrowsException<IndexOutOfRangeException>(() => sut.Front());
        Assert.ThrowsException<IndexOutOfRangeException>(() => sut.Back());
    }

    [TestMethod]
    public void List_ShouldIncreaseSize_WhenInsertValue()
    {
        var sut = new CustomList<int>();
        sut.PushBack(2);
        sut.PushBack(2);
        sut.PushBack(2);
        sut.Insert(2,3);
        Assert.AreEqual(4,sut.Size);
    }
    
    [TestMethod]
    public void List_ShouldReturnValue_WhenInsertValueAfterHalf()
    {
        var sut = new CustomList<int>();
        sut.PushBack(1);
        sut.PushBack(2);
        sut.PushBack(3);
        sut.PushBack(4);
        sut.PushBack(6);
        sut.PushBack(7);
        sut.Insert(4,5);
        
        Assert.AreEqual(1,sut.ValueAt(0));
        Assert.AreEqual(2,sut.ValueAt(1));
        Assert.AreEqual(3,sut.ValueAt(2));
        Assert.AreEqual(4,sut.ValueAt(3));
        Assert.AreEqual(5,sut.ValueAt(4));
        Assert.AreEqual(6,sut.ValueAt(5));
    }
    
    [TestMethod]
    public void List_ShouldReturnValue_WhenInsertValueBeforeHalf()
    {
        var sut = new CustomList<int>();
        sut.PushBack(1);
        sut.PushBack(3);
        sut.PushBack(4);
        sut.PushBack(5);
        sut.PushBack(6);
        sut.PushBack(7);
        sut.Insert(1,2);
        
        Assert.AreEqual(1,sut.ValueAt(0));
        Assert.AreEqual(2,sut.ValueAt(1));
        Assert.AreEqual(3,sut.ValueAt(2));
        Assert.AreEqual(4,sut.ValueAt(3));
        Assert.AreEqual(5,sut.ValueAt(4));
        Assert.AreEqual(6,sut.ValueAt(5));
    }
    
    [TestMethod]
    public void List_ShouldDecreaseinSize_WhenErase()
    {
        var sut = new CustomList<int>();
        sut.PushBack(2);
        sut.PushBack(2);
        sut.PushBack(2);
        sut.Erase(1);
        Assert.AreEqual(2,sut.Size);
    }
    
    [TestMethod]
    public void List_ShouldRemoveAnItem_WhenErase()
    {
        var sut = new CustomList<int>();
        sut.PushBack(0);
        sut.PushBack(1);
        sut.PushBack(2);
        sut.PushBack(3);
        sut.PushBack(4);
        sut.Erase(2);
        Assert.AreEqual(0,sut.ValueAt(0));
        Assert.AreEqual(1,sut.ValueAt(1));
        Assert.AreEqual(3,sut.ValueAt(2));
        Assert.AreEqual(4,sut.ValueAt(3));
    }

    [TestMethod]
    public void List_ShouldReverse_WhenReverse()
    {
        var sut = new CustomList<int>();
        sut.PushBack(0);
        sut.PushBack(1);
        sut.PushBack(2);
        sut.PushBack(3);
        sut.Reverse();
        Assert.AreEqual(3,sut.ValueAt(0));
        Assert.AreEqual(2,sut.ValueAt(1));
        Assert.AreEqual(1,sut.ValueAt(2));
        Assert.AreEqual(0,sut.ValueAt(3));
    }
    
    
}