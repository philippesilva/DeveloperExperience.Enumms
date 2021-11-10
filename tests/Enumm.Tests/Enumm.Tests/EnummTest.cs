using NUnit.Framework;

namespace Enumms.Tests
{
    public class EnummTest
    {
        [Test]
        public void GetDescriptionTest()
        {
            var descriptions = Enumm.GetDescriptions<Status>();

            Assert.IsNotEmpty(descriptions);
        }

        [Test]
        public void GetValueFromDescriptionTest()
        {
            var status = Enumm.GetValueFromDescription<Status>("Success");

            Assert.AreEqual(Status.Success.GetHashCode(), status.GetHashCode());
        }
    }
}