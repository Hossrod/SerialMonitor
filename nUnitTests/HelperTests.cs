namespace SerialMonitor.nUnitTests
{
    public class Helpers_ConvertBytesToHumanReadable_Method
    {
        [Test]
        [Category("Functional Tests")]
        [TestCase(512, "512 bytes")] 
        [TestCase(1024, "1 KB")] 
        [TestCase(1048576, "1 MB")] 
        [TestCase(1073741824, "1 GB")] 
        [TestCase(1099511627776, "1 TB")] 
        public void Functional(long bytes, string expected)
        {
            // Act
            string result = Helpers.ConvertBytesToHumanReadable(bytes);

            // Assert
            if (result != expected)
            {
                Assert.Fail($"Input was '{bytes}', Expected '{expected}', but '{result}' was returned.");
            }
        }

        [Test]
        [Category("Out of Range Tests")]
        public void NegativeBytes()
        {
            // Arrange
            long bytes = -1024; // Negative bytes
            string expected = "0 bytes";

            // Act
            string result = Helpers.ConvertBytesToHumanReadable(bytes);

            // Assert
            if (result != expected)
            {
                Assert.Fail($"Input was '{bytes}', Expected '{expected}', but '{result}' was returned.");
            }
        }

        [Test]
        [Category("Boundry Tests")]
        public void ZeroBytes()
        {
            // Arrange
            long bytes = 0;
            string expected = "0 bytes";

            // Act
            string result = Helpers.ConvertBytesToHumanReadable(bytes);

            // Assert
            if (result != expected)
            {
                Assert.Fail($"Input was '{bytes}', Expected '{expected}', but '{result}' was returned.");
            }
        }

        [Test]
        [Category("Boundry Tests")]
        public void MaxLong()
        {
            // Arrange
            long bytes = long.MaxValue; // Maximum possible long value
            string expected = "TB";

            // Act
            string result = Helpers.ConvertBytesToHumanReadable(bytes);

            // Assert
            // We don't know the exact expected result, but we can at least assert that it ends with "TB"
            StringAssert.EndsWith(expected, result, $"Input was '{bytes}', ");
        }

        [Test]
        [Category("Edge Tests")]
        [TestCase(1023, "1023 bytes")] // Maximum bytes before KB
        [TestCase(1048575, "1024 KB")] // Maximum bytes before MB
        [TestCase(1073741823, "1024 MB")] // Maximum bytes before GB
        [TestCase(1099511627775, "1024 GB")] // Maximum bytes before TB
        public void Boundary(long bytes, string expected)
        {
            // Act
            string result = Helpers.ConvertBytesToHumanReadable(bytes);

            // Assert
            if (result != expected)
            {
                Assert.Fail($"Input was '{bytes}', Expected '{expected}', but '{result}' was returned.");
            }
        }
    }
}