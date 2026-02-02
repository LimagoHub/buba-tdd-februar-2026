namespace StapelProject.Collections;

public class Stapel
{
    private readonly int[] _data;
    private int _size = 0;
    private const int Capacity = 10;
    
    public Stapel()
    {
        _data = new int[Capacity];
    }
    
    public void Push(int value)
    {
        if (IsFull()) throw new StapelException("Overflow");
        _data[_size] = value;
        _size++;
    }
    
    public int Pop()
    {
        if (IsEmpty()) throw new StapelException("Underflow");
        _size--;
        return _data[_size];
    }
    
    
    
    public bool IsEmpty() => _size == 0;

    public bool IsFull() => _size >= Capacity;
    
}