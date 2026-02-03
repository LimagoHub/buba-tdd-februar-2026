using Moq;
using PersonenServiceProjekt.persistence;
using PersonenServiceProjekt.services;

namespace PersonenServoceProjektTests.services;


[TestFixture]
public class PersonenServiceImplTests
{
    private Mock<IPersonenRepository> _repoMock;
    private PersonenServiceImpl _objectUnderTest;

    [SetUp]
    public void SetUp()
    {
        _repoMock = new Mock<IPersonenRepository>();
        _objectUnderTest = new PersonenServiceImpl(_repoMock.Object);
    }
    
    [Test]
    public void Speichern_PersonParamerIsNull_ThrowsPersonenServiceException()
    {
        // Arrange
        // Act
        // Assert
        Assert.That(() => _objectUnderTest.Speichern(null), 
            Throws.TypeOf<PersonenServiceException>().With.Message.EqualTo("Person darf nicht null sein!"));
        
    }
    
    [Test]
    public void Speichern_VornameIsNull_ThrowsPersonenServiceException()
    {
        // Arrange
        Person invalidPerson = new ()
        { 
            Vorname = null,
            Nachname = "Doe"
        };
        // Act
        // Assert
        Assert.That(() => _objectUnderTest.Speichern(invalidPerson), 
            Throws.TypeOf<PersonenServiceException>().With.Message.EqualTo("Vorname zu kurz!"));
        
    }
}