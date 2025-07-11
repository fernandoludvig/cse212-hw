using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue
    // Expected Result: Items should be dequeued in order of highest priority
    // Defect(s) Found: Dequeue wasn't removing items, priority comparison missed last item
    public void TestPriorityQueue_BasicFunctionality()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority
    // Expected Result: Items with same priority should be dequeued in FIFO order
    // Defect(s) Found: Original implementation didn't guarantee FIFO for same priority
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Should throw InvalidOperationException
    // Defect(s) Found: None - this case was already handled correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        Assert.ThrowsException<InvalidOperationException>(() => 
        {
            priorityQueue.Dequeue();
        });
    }

    [TestMethod]
    // Scenario: Mixed priorities with some duplicates
    // Expected Result: Highest priority first, FIFO for same priority
    // Defect(s) Found: Original implementation didn't properly handle mixed cases
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 1);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 2);

        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
}