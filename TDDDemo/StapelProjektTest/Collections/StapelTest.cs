using TDDDemo.Collections;

namespace StapelProjektTest.Collections;
[TestFixture]
public class StapelTest
{
    
    private Stapel _objectUnderTest;
    
    [SetUp]
    public void SetUp()
    {
        _objectUnderTest = new Stapel();
    }

    [Test]
    public void blabla()
    {
        var result = _objectUnderTest.IsEmpty();
        Assert.IsTrue(result);
    }
    
    [Test]
    public void Blupp()
    {
        _objectUnderTest.push(1);
        var result = _objectUnderTest.IsEmpty();
        Assert.IsFalse(result);
    }
}

