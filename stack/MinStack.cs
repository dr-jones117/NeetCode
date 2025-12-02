using System.Diagnostics;

MinStack minStack = new MinStack();
minStack.Push(1);
minStack.Push(2);
minStack.Push(0);
Debug.Assert(minStack.GetMin() == 0);
minStack.Pop();
Debug.Assert(minStack.Top() == 2);
Debug.Assert(minStack.GetMin() == 1);

public class MinStack
{
    private Stack<int> stack;
    private Stack<int> minInternal;

    public MinStack()
    {
        stack = new Stack<int>();
        minInternal = new Stack<int>();
    }

    public void Push(int val)
    {
        stack.Push(val);

        if(minInternal.Count() == 0)
        {
            minInternal.Push(val);
        }
        else
        {
            minInternal.Push(Math.Min(minInternal.Peek(), val));
        }
    }

    public void Pop()
    {
        stack.Pop();
        minInternal.Pop();
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int GetMin()
    {
        return minInternal.Peek();
    }
}