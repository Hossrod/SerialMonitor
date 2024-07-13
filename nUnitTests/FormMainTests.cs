using System.Drawing;

namespace SerialMonitor.nUnitTests
{
    [TestFixture(Description = "Tests for the FormMain.FormatRule class.")]
    public class FormMain_FormatRule
    {
        [Test]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string searchTerm = "test";
            Color termColor = Color.Red;
            bool caseSensitive = true;

            // Act
            FormatRule rule = new FormatRule(searchTerm, termColor, caseSensitive);

            // Assert
            Assert.That(rule.SearchTerm, Is.EqualTo(searchTerm));
            Assert.That(rule.TermColor, Is.EqualTo(termColor));
            Assert.That(rule.CaseSensitive, Is.EqualTo(caseSensitive));
        }

        [Test]
        public void Constructor_SetsCaseSensitiveToFalseByDefault()
        {
            // Arrange
            string searchTerm = "test";
            Color termColor = Color.Red;

            // Act
            FormatRule rule = new FormatRule(searchTerm, termColor);

            // Assert
            Assert.That(rule.SearchTerm, Is.EqualTo(searchTerm));
            Assert.That(rule.TermColor, Is.EqualTo(termColor));
            Assert.That(rule.CaseSensitive, Is.False);
        }
    }
}