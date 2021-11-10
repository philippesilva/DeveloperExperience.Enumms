using NUnit.Framework;

namespace Enumms.Tests
{
    public class EnumExtensionTest
    {
        [Test]
        public void GetDescriptionTest()
        {
            var status = Status.Warning;

            var description = status.GetDescription();

            Assert.IsNotEmpty(description);
        }
    }
}