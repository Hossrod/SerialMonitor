namespace SerialMonitor.nUnitTests
{
    [TestFixture(Description = "Tests the Helpers.ConvertBytesToHumanReadable Method.")]
    public class Helpers_ConvertBytesToHumanReadable
    {
        [TestCase(512, "512 bytes")] 
        [TestCase(1024, "1 KB")] 
        [TestCase(1048576, "1 MB")] 
        [TestCase(1073741824, "1 GB")] 
        [TestCase(1099511627776, "1 TB")] 
        public void Functional_Testing(long bytes, string expected)
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
        public void OutOfRangeTesting_NegativeBytes()
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
        public void BoundryTesting_ZeroBytes()
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
        public void BoundryTesting_MaxLong()
        {
            // Arrange
            long bytes = long.MaxValue; // Maximum possible long value
            string expected = "TB";

            // Act
            string result = Helpers.ConvertBytesToHumanReadable(bytes);

            // Assert
            // Value can vary, but we can at least assert that it ends with "TB"
            StringAssert.EndsWith(expected, result, $"Input was '{bytes}', ");
        }

        [TestCase(1023, "1023 bytes")] // Maximum bytes before KB
        [TestCase(1048575, "1024 KB")] // Maximum bytes before MB
        [TestCase(1073741823, "1024 MB")] // Maximum bytes before GB
        [TestCase(1099511627775, "1024 GB")] // Maximum bytes before TB
        public void Edge_Testing(long bytes, string expected)
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