public class MyServiceUsingDependency {
    private readonly IDependency _dependency;

    public MyServiceUsingDependency(IDependency dependency) {
        _dependency = dependency;
    }

    public void F(string value) {
        var upperValue = value.ToUpper(); // C# String-Transformation
        _dependency.Foo(upperValue);
    }

    public int G(string value) {
        value += " Welt";
        return _dependency.Foobar(value) + 5;
    }

    public long H() {
       /* var barValue = _dependency.Bar();
        return (long)barValue * barValue;
        */
       return _dependency.Bar() * _dependency.Bar();
    }
}