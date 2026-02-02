using StapelProject.Collections;

namespace StapelProjektTests.Collections;

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
    [Description("should return true when IsEmpty called on empty Stapel")]
    public void IsEmpty_EmptyStack_ReturnsTrue()
    {
        // Arrange
        
        // Act
        var result = _objectUnderTest.IsEmpty();
        
        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void IsEmpty_NotEmptyStack_ReturnsFalse()
    {
        // Arrange
        const int anyValidNumber = 1;
        _objectUnderTest.Push(anyValidNumber);
        
        // Act
        var result = _objectUnderTest.IsEmpty();
        
        // Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void push_fillUpToLimit_noExceptionIsThrown()
    {
        FillUpToLimit();
    }

   

    [Test]
    public void push_Overflow_throwsStapelException()
    {
        
        // Arrange
        FillUpToLimit();
        
        // Act
        Assert.That(() => _objectUnderTest.Push(1), 
            Throws.TypeOf<StapelException>()
                .With.Message.EqualTo("Overflow"));
        
        /*Assert.That(() => _objectUnderTest.Push(1), 
            Throws.InstanceOf<StapelException>()
                .With.Message.EqualTo("Overflow"));
        */

        //Assert.That(async () => await YourAsyncMethod(), Throws.TypeOf<UnauthorizedAccessException>());
        /*Assert.Multiple(()=>
            {
                Assert.That(() => _objectUnderTest.Push(1),
                    Throws.TypeOf<StapelException>()
                        .With.Message.EqualTo("Overflow"));
                }
            );*/
    }
    
    private void FillUpToLimit()
    {
        for (int i = 0; i < 10; i++)
        {
            Assert.That(() => _objectUnderTest.Push(i), Throws.Nothing);
            
        }
    }
    
}