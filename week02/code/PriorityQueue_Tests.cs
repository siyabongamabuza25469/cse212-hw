using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Items are enqueued with different priorities.
    // Expected Result: The item with the highest priority is dequeued first.
    // Defect(s) Found: The original loop did not examine the final item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Items have equal priorities.
    // Expected Result: Items with equal priority are dequeued in FIFO order.
    // Defect(s) Found: Using >= selected the newest equal-priority item first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: An item is dequeued from the queue.
    // Expected Result: The item is removed and is not returned again.
    // Defect(s) Found: The original code did not remove the dequeued item.
    public void TestPriorityQueue_DequeueRemovesItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Item", 1);

        Assert.AreEqual("Item", priorityQueue.Dequeue());

        Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue is called on an empty queue.
    // Expected Result: InvalidOperationException is thrown.
    // Defect(s) Found: No defect found in the empty-queue check.
    public void TestPriorityQueue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: The queue contains one item.
    // Expected Result: The item can be enqueued and dequeued successfully.
    // Defect(s) Found: The original loop boundary could cause incorrect behavior for the final item.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Only Item", 100);

        Assert.AreEqual("Only Item", priorityQueue.Dequeue());

        Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: The final enqueued item has the highest priority.
    // Expected Result: The final item is selected first.
    // Defect(s) Found: The original loop condition skipped the final item.
    public void TestPriorityQueue_LastItemHasHighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("Highest", 10);

        Assert.AreEqual("Highest", priorityQueue.Dequeue());
    }
}