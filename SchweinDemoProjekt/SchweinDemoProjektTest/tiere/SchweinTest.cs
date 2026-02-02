namespace SchweinDemoProjekt.tiere;


    [TestFixture]
    public class SchweinTests
    {
        private Schwein _objectUnderTest;
        private const int MyInitialWeight = 10;

        [SetUp]
        public void SetUp()
        {
            
            _objectUnderTest = new Schwein();
        }

        [Test]
        public void Ctor_Default_CorrectInitialisation()
        {
            string expectedValue = "Nobody";

            Assert.Multiple(() =>
            {
                Assert.That(_objectUnderTest.Gewicht, Is.EqualTo(MyInitialWeight));
                Assert.That(_objectUnderTest.Name, Is.EqualTo(expectedValue));
            });
           
        }

        [Test]
        public void Ctor_OverloadedWithInvalidName_ThrowsInvalidArgument()
        {
            const string invalidName = "Elsa";
            const string expectedMessage = "Name verstoesst gegen die Schweinewuerde!";

            Assert.That(() => _objectUnderTest.Name = invalidName, 
                Throws.ArgumentException.With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void Ctor_OverloadedWithValidName_CorrectInitialisation()
        {
            const string validName = "Piggy";
            
            var objectUnderTestLocal = new Schwein(validName);
            
                 
            Assert.Multiple(() =>
            {
                Assert.That(objectUnderTestLocal.Gewicht, Is.EqualTo(MyInitialWeight));
                Assert.That(objectUnderTestLocal.Name, Is.EqualTo(validName));
            });
        }

        [Test]
        public void Name_InvalidName_ThrowsInvalidArgument()
        {
            const string invalidName = "Elsa";
            const string expectedMessage = "Name verstoesst gegen die Schweinewuerde!";

            Assert.That(() => _objectUnderTest.Name = invalidName, 
                Throws.ArgumentException.With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void Name_ValidName_NameCorrectlySetAndNoExceptionIsThrown()
        {
            const string validName = "Piggy";
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => _objectUnderTest.Name = validName);
                Assert.That(_objectUnderTest.Name, Is.EqualTo("Piggy"));
            });
        }

        [Test]
        public void Fuettern_HappyDay_WeightIncreasedByOne()
        {
            const int expectedResult = MyInitialWeight + 1;

            _objectUnderTest.Fuettern();

            Assert.That(_objectUnderTest.Gewicht, Is.EqualTo(expectedResult));
        }
    }
