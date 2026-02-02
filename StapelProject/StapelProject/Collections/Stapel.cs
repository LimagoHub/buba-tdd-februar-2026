namespace StapelProject.Collections;

public class Stapel
{
    private readonly List<int> _data = new List<int>();

    public void Push(int value)
    {
        if (IsFull()) throw new StapelException("Overflow");
        _data.Add(value);
    }

    public int Pop()
    {
        if (IsEmpty()) throw new StapelException("Underflow");
        int value = _data[^1]; // Index-from-end Operator (^1 ist das letzte Element)
        _data.RemoveAt(_data.Count - 1);
        return value;
    }

    public bool IsEmpty() => _data.Count == 0;

    public bool IsFull() => false;
    
}