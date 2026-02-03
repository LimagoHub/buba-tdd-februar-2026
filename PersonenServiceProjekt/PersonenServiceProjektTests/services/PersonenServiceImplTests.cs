using Moq;
using PersonenServiceProjekt.persistence;
using PersonenServiceProjekt.services;

namespace PersonenServoceProjektTests.services;


[TestFixture]
public class PersonenServiceImplTests
{
    private Mock<IPersonenRepository> _repoMock;
    private Mock<IBlacklistService> _blacklistServiceMock;
    private PersonenServiceImpl _objectUnderTest;

    [SetUp]
    public void SetUp()
    {
        _repoMock = new Mock<IPersonenRepository>(MockBehavior.Strict);
        _blacklistServiceMock = new Mock<IBlacklistService>(MockBehavior.Strict);
        _objectUnderTest = new PersonenServiceImpl(_repoMock.Object, _blacklistServiceMock.Object);
        
       // _blacklistServiceMock.Setup(x => x.IsBlacklisted(It.IsAny<Person>())).Returns(false);
    }
    
    
    [TestCaseSource(nameof(InvalidepersonesCases))]
    public void Speichern_InvalidNames_ThrowsPersonenServiceException(Person? invalidPerson, string expectedMessage)
    {
          
        Assert.That(() => _objectUnderTest.Speichern(invalidPerson), 
            Throws.TypeOf<PersonenServiceException>().With.Message.EqualTo(expectedMessage));
        
        
    }
    
    [Test]
    public void Speichern_Antipath_ThrowsPersonenServiceException()
    {
        var invalidPerson = new Person("John", "Doe");

        _blacklistServiceMock.Setup(b => b.IsBlacklisted(invalidPerson)).Returns(true);
        
        Assert.That(() => _objectUnderTest.Speichern(invalidPerson), 
            Throws.TypeOf<PersonenServiceException>().With.Message.EqualTo("Unerwuenschte Person"));

        _blacklistServiceMock.Verify((b => b.IsBlacklisted(invalidPerson)), Times.Once);
    }
    
    [Test]
    public void Speichern_UnexpectedExceptionInUnderlyingService_ThrowsPersonenServiceException()
    {
        // Arrange
        var validPerson = new Person("John", "Doe");
        
        
        _repoMock.Setup(repo => repo.SaveOrUpdate(It.IsAny<Person>())).Throws(new IndexOutOfRangeException("Upps"));
        
        
        
        Assert.That(() => _objectUnderTest.Speichern(validPerson), 
            Throws.TypeOf<PersonenServiceException>().With.Message.EqualTo("Ein Fehler ist aufgetreten!")
                .And.InnerException.TypeOf<IndexOutOfRangeException>() // Prüft den Typ der inneren Exception
                .And.InnerException.Message.Contains("Upps"));
        
        _repoMock.Verify(repo => repo.SaveOrUpdate(It.IsAny<Person>()), Times.Once);
    }
    
    [Test]
    public void Speichern_HappyPath_personPassedToRepo()
    {
        // Arrange
        var validPerson = new Person("John", "Doe");
        var sequence = new MockSequence();
        
        _blacklistServiceMock.InSequence(sequence).Setup(b => b.IsBlacklisted(validPerson)).Returns(false);
        
        _repoMock.InSequence(sequence).Setup(repo => repo.SaveOrUpdate(It.IsAny<Person>())).Verifiable();
        

        _objectUnderTest.Speichern(validPerson);
        
        _repoMock.Verify(repo => repo.SaveOrUpdate(validPerson), Times.Once);
        _blacklistServiceMock.Verify(b => b.IsBlacklisted(validPerson), Times.Once);
    }
    
    [Test]
    public void Speichern_overloaded_HappyPath_personPassedToRepo()
    {
        // Arrange
       string vorname = "John";
       string nachname = "Doe";
        
       Person capturedPerson = null!;
       
        _repoMock.Setup(repo => repo.SaveOrUpdate(It.IsAny<Person>()))
            .Callback((Person person) => capturedPerson = person);

        // Act
        _objectUnderTest.Speichern(vorname, nachname);
        
        // Assert
        Assert.Multiple(() => {
            Assert.That(capturedPerson.Vorname, Does.StartWith("J").Or.StartWith("M"));
            Assert.That(capturedPerson.Id, Is.Not.Null);
        });
        _repoMock.Verify(repo => repo.SaveOrUpdate(capturedPerson), Times.Once);
    }

    
    private static IEnumerable<TestCaseData> InvalidepersonesCases => new List<TestCaseData>
    {
        new TestCaseData(null, "Person darf nicht null sein!"),
        new TestCaseData(new Person(null, "Doe"), "Vorname zu kurz!"),
        new TestCaseData(new Person("", "Doe"), "Vorname zu kurz!"),
        new TestCaseData(new Person("J", "Doe"), "Vorname zu kurz!"),
        new TestCaseData(new Person("John", null), "Nachname zu kurz!"),
        new TestCaseData(new Person("John", ""), "Nachname zu kurz!"),
        new TestCaseData(new Person("John", "D"), "Nachname zu kurz!")
        
    };
}