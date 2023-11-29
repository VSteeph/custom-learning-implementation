using ProjectCSharp;

namespace TestProject
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void CreateAVector_ShouldReturnAVector()
        {
            CustomArray<int> arr = new CustomArray<int>(1);
            Assert.IsNotNull(arr);
        }
        [TestMethod]
        public void CreateAVectofWithASize_ShouldReturnAVectorWithCapacityOfX()
        {
            int x = 6;
            CustomArray<int> arr = new CustomArray<int>(x);
            Assert.IsNotNull(arr);
            Assert.AreEqual(arr.Capacity, x);
        }
        
        [TestMethod]
        public void Vector_ShouldReturnIsEmpty_WhenEmpty()
        {
            int x = 2;
            CustomArray<int> arr = new CustomArray<int>(x);
            Assert.IsTrue(arr.IsEmpty());
        }
        
        [TestMethod]
        public void Vector_ShouldNotReturnIsEmpty_WhenEmpty()
        {
            int x = 2;
            CustomArray<int> arr = new CustomArray<int>(x);
            arr.Push(3);
            Assert.IsFalse(arr.IsEmpty());
        }
        
        [TestMethod]
        public void AnEmptyVector_ShouldReturnASizeOf0()
        {
            int x = 3;
            CustomArray<int>arr = new CustomArray<int>(x);
            Assert.AreEqual(0, arr.Size);
        }
        
        [TestMethod]
        public void AddAValueToAVector_ShouldChangeSize()
        {
            int x = 5;
            CustomArray<int>arr = new CustomArray<int>(x);
            arr.Push(3);
            Assert.AreEqual(1, arr.Size);
        }
        
        [TestMethod]
        public void Vector_ShouldStillAdd_WhenMaxSizeIsExceeded()
        {
            int x = 1;
            CustomArray<int>arr = new CustomArray<int>(x);
            arr.Push(3);
            arr.Push(4);
            Assert.AreEqual(2, arr.Size);
        }
        
        [TestMethod]
        public void Vector_ShouldDoubleCapacity_WhenMaxSizeIsExceeded()
        {
            int x = 2;
            CustomArray<int>arr = new CustomArray<int>(x);
            arr.Push(3);
            arr.Push(4);
            arr.Push(4);
            Assert.AreEqual(4, arr.Capacity);
        }
        
        [TestMethod]
        public void Vector_ShouldDoubleCapacity_WhenMaxSizeEqualsCapacityAfterAnOperation()
        {
            int x = 2;
            CustomArray<int>arr = new CustomArray<int>(x);
            arr.Push(3);
            arr.Push(4);
            arr.Push(4);
            arr.Push(4);
            Assert.AreEqual(8, arr.Capacity);
        }
        
        [TestMethod]
        public void Vector_ShouldReturnCorrectValueAtIndex()
        {
            int x = 3;
            CustomArray<int> arr = new CustomArray<int>(x);
            arr.Push(3);
            Assert.AreEqual(3, arr.At(0));
        }

        [TestMethod]
        public void Vector_ShouldReturnOutOfBound_WhenIndexIsNotValid()
        {
            int x = 3;
            CustomArray<int> arr = new CustomArray<int>(x);
            arr.Push(3);
            Assert.ThrowsException<IndexOutOfRangeException>(() => arr.At(2));
        }
        
        [TestMethod]
        public void Vector_ShouldShiftEveryValue_WhenInsertingAnElement()
        {
            int x = 4;
            CustomArray<int> arr = new CustomArray<int>(x);
            arr.Push(1);
            arr.Push(3);
            arr.Push(4);
            arr.Insert(1,2);
            Assert.AreEqual(1, arr.At(0));
            Assert.AreEqual(2, arr.At(1));
            Assert.AreEqual(3, arr.At(2));
            Assert.AreEqual(4, arr.At(3));
        }
        
        [TestMethod]
        public void Vector_ShouldShiftEveryValue_WhenInsertingAnElement_EvenWhenExcedingCapacity()
        {
            int x = 3;
            CustomArray<int> arr = new CustomArray<int>(x);
            arr.Push(1);
            arr.Push(3);
            arr.Push(4);
            arr.Insert(1,2);
            Assert.AreEqual(1, arr.At(0));
            Assert.AreEqual(2, arr.At(1));
            Assert.AreEqual(3, arr.At(2));
            Assert.AreEqual(4, arr.At(3));
        }
        
        [TestMethod]
        public void Vector_ShouldNotShiftEveryValue_WhenIndexExcedingCapacity()
        {
            int x = 2;
            CustomArray<int> arr = new CustomArray<int>(x);
            arr.Push(1);
            arr.Push(3);
            arr.Push(4);
            arr.Insert(5,2);
            Assert.ThrowsException<IndexOutOfRangeException>(() => arr.At(5));
        }
    }
}