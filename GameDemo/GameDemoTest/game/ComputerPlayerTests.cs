using GameDemo.game;
using GameDemo.io;
using Moq;

namespace GameDemoTest.game;
[TestFixture]
public class ComputerPlayerTests
{
    private Mock<IWriter> _writerMock;
    private ComputerPlayer _objectUnderTest;

    [SetUp]
    public void SetUp()
    {
        _writerMock = new Mock<IWriter>();
        _objectUnderTest = new ComputerPlayer(_writerMock.Object);
    }

    [Test]
    public void DoTurn_StonesMod4Equal0_Returns3()
    {
        // Act
        var result = _objectUnderTest.DoTurn(20);

        // Assert
        Assert.That(result, Is.EqualTo(3));
        _writerMock.Verify(w => w.Write("Computer nimmt 3 Steine"), Times.Once);
    }
    
    [Test]
    public void DoTurn_StonesMod4Equal1_Returns1()
    {
        // Act
        var result = _objectUnderTest.DoTurn(21);

        // Assert
        Assert.That(result, Is.EqualTo(1));
        _writerMock.Verify(w => w.Write("Computer nimmt 1 Steine"), Times.Once);
    }
    
    [Test]
    public void DoTurn_StonesMod4Equal2_Returns1()
    {
        // Act
        var result = _objectUnderTest.DoTurn(22);

        // Assert
        Assert.That(result, Is.EqualTo(1));
        _writerMock.Verify(w => w.Write("Computer nimmt 1 Steine"), Times.Once);
    }
    
    [Test]
    public void DoTurn_StonesMod4Equal3_Returns2()
    {
        // Act
        var result = _objectUnderTest.DoTurn(23);

        // Assert
        Assert.That(result, Is.EqualTo(2));
        _writerMock.Verify(w => w.Write("Computer nimmt 2 Steine"), Times.Once);
    }

    [TestCase(20, 3)]
    //[TestCase(21, 1)]
    [TestCase(22, 1)]
    [TestCase(23, 2)]
    [TestCase(4, 3)]
    [TestCase(5, 1)]
    [TestCase(6, 1)]
    [TestCase(7, 2)]
    [TestCase(21, 1, Description = "Szenario für Modulo 1", TestName = "Stones: 21 -> Move: 1")]
    public void DoTurn_HappyDay_ReturnsExpectedValue(int stones, int expectedValue)
    {
        // Act
        var result = _objectUnderTest.DoTurn(stones);
        
        // Assert
        Assert.That(result, Is.EqualTo(expectedValue));
        _writerMock.Verify(w => w.Write($"Computer nimmt {expectedValue} Steine"), Times.Once);
    }
}