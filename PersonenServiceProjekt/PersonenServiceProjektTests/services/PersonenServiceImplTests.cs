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
    
    
    [TestCaseSource(nameof(InvalidepersonesCases))]
    public void Speichern_InvalidNames_ThrowsPersonenServiceException(Person? invalidPerson, string expectedMessage)
    {
          
        Assert.That(() => _objectUnderTest.Speichern(invalidPerson), 
            Throws.TypeOf<PersonenServiceException>().With.Message.EqualTo(expectedMessage));
    }
    
    [Test]
    public void Speichern_Antipath_ThrowsPersonenServiceException()
    {
        var invalidPerson = new Person("Attila", "der Hunne");
        
        Assert.That(() => _objectUnderTest.Speichern(invalidPerson), 
            Throws.TypeOf<PersonenServiceException>().With.Message.EqualTo("Unerwuenschte Person"));
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