using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Enqueue multiple items with different priorities and dequeue once.
    // Expected Result:
    // The item with the highest priority should be returned.
    // Defect(s) Found:
    // The highest priority item was not always returned because the
    // dequeue loop failed to check the last element in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario:
    // Enqueue multiple items with the same highest priority.
    // Expected Result:
    // The item closest to the front of the queue (FIFO order) should be returned.
    // Defect(s) Found:
    // FIFO behavior was violated because the comparison logic used
    // >= instead of >, causing later items with the same priority
    // to be selected instead of the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 1);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario:
    // Dequeue an item and verify it is removed from the queue.
    // Expected Result:
    // The returned item should no longer exist in the queue.
    // Defect(s) Found:
    // The dequeue method returned the correct value but failed
    // to remove the item from the underlying list.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);

        priorityQueue.Dequeue();

        Assert.AreEqual("[B (Pri:1)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario:
    // Attempt to dequeue from an empty queue.
    // Expected Result:
    // An InvalidOperationException with the message
    // "The queue is empty." should be thrown.
    // Defect(s) Found:
    // No defects were found. Exception handling was implemented correctly.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }
}