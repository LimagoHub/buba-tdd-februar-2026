namespace TDDDemo.Collections;

public class Stapel
{
    
    private bool _isEmpty = true;
    public bool IsEmpty()
    {
        return _isEmpty;
    }

    public void push(int i)
    {
       _isEmpty = false;
    }
}