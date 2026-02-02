using NUnit.Framework;
using Moq;

[TestFixture]
public class MyServiceUsingDependencyTest {
    private Mock<IDependency> _dependencyMock;
    private MyServiceUsingDependency _objectUnderTest;

    [SetUp]
    public void SetUp() {
        // Entspricht der TestFixture-Initialisierung
        _dependencyMock = new Mock<IDependency>();
        _objectUnderTest = new MyServiceUsingDependency(_dependencyMock.Object);
    }
    
    /*
     *
     * public void F(string value) {
        var upperValue = value.ToUpper(); // C# String-Transformation
        _dependency.Foo(upperValue);
    }
     */

    [Test]
    public void MockdemoFooFunc() {
      
        // Recordmode
        _dependencyMock.Setup(m => m.Foo(It.IsAny<string>())).Verifiable();
        // Replay

       
        // Act
        _objectUnderTest.F("hallo");

        // Assert
        _dependencyMock.Verify(m => m.Foo("HALLO"), Times.Once);
    }

    /*
     
         public int G(string value) {
             value += " Welt";
             return _dependency.Foobar(value) + 5;
         }
     
     
     */
    
    [Test]
    public void MockdemoFooBarFunc() {
        
        
          _dependencyMock.SetupSequence(m => m.Foobar("Hallo Welt"))
         
            .Returns(10)
            .Returns(15)
            .Throws(new System.Exception());
        
        //_dependencyMock.Setup(m => m.Foobar("Hello Welt")).Returns(100);
        //_dependencyMock.Setup(m => m.Foobar("Hallo Welt")).Returns(10);
        
        // Act & Assert
        // Der erste Aufruf gibt 10 zurück (+5 vom Service = 15)
        var result = _objectUnderTest.G("Hallo");
        //_dependencyMock.Verify(m => m.Foobar("Hello Welt"), Times.AtLeast(1));
        
        _dependencyMock.Verify(m => m.Foobar("Hallo Welt"), Times.AtLeast(1));
        Assert.That(result, Is.EqualTo(15));
    }

    
    /*
     
    public long H() {
       //var barValue = _dependency.Bar();
       // return (long)barValue * barValue;
        
       return _dependency.Bar() * _dependency.Bar();
    }
     
     */
    [Test]
    public void MockdemoBarFunc() {
        // Arrange
        _dependencyMock.Setup(m => m.Bar()).Returns(3);

        // Act
        var result = _objectUnderTest.H();
        
        // Assert
        _dependencyMock.Verify(m => m.Bar(), Times.AtLeast(1));
        Assert.That(result, Is.EqualTo(9));
    }
}