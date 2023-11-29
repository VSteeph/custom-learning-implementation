using ProjectCSharp;

namespace TestProject;

[TestClass]
public class QueuesTest
{
    [TestMethod]
    public void ShouldCreateAQueue_WhenInstantiatingOne()
    {
        var sut = new Queues<int>();
        Assert.IsNotNull(sut);
    }
    [TestMethod]
    public void QueueSHouldBeEmpty_WhenCreated()
    {
        var sut = new Queues<int>();
        Assert.IsTrue(sut.IsEmpty());
    }
    [TestMethod]
    public void Queue_ShouldNotBeEmpty_WhenEnqueued()
    {
        var sut = new Queues<int>();
        sut.Enqueue(1);
        Assert.IsFalse(sut.IsEmpty());
    }
    
    [TestMethod]
    public void Queue_ShouldReturnItem_WhenDequeueAndNotEmpty()
    {
        var sut = new Queues<int>();
        sut.Enqueue(1);
        Assert.AreEqual(1, sut.Dequeue());
    }
    
    [TestMethod]
    public void Queue_ShouldBeEmpty_WhenLastItemIsDequeue()
    {
        var sut = new Queues<int>();
        sut.Enqueue(1);
        sut.Dequeue();
        Assert.IsTrue(sut.IsEmpty());
    }
    
    [TestMethod]
    public void Queue_ShouldThrowException_WhenDequeueIsUSedOnEmptyQueue()
    {
        var sut = new Queues<int>();
        Assert.ThrowsException<NullReferenceException>(() => sut.Dequeue());
    }

}