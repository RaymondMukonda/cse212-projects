using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue values with different priorities, including the highest priority last.
    // Expected Result: Values are added at the back and dequeued highest-priority first.
    // Defect(s) Found: The highest-priority search skipped the last item in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 7);

        Assert.AreEqual("[Low (Pri:1), Medium (Pri:3), High (Pri:7)]", priorityQueue.ToString());
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue equal highest priorities with another item between them.
    // Expected Result: The first highest-priority item is dequeued before the later tied item.
    // Defect(s) Found: The later item with an equal highest priority was selected instead of the earlier item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("First high", 5);
        priorityQueue.Enqueue("Middle", 3);
        priorityQueue.Enqueue("Second high", 5);
        priorityQueue.Enqueue("Last", 0);

        Assert.AreEqual("First high", priorityQueue.Dequeue());
        Assert.AreEqual("Second high", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue the highest-priority value, then dequeue again.
    // Expected Result: Each dequeue removes and returns the current highest-priority value.
    // Defect(s) Found: Dequeue returned the same highest-priority value repeatedly because it was not removed.
    public void TestPriorityQueue_RemovesDequeuedItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None; the expected exception and message were returned.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}