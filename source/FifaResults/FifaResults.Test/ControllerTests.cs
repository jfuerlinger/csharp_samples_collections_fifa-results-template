using System;
using System.Linq;
using FifaResults.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifaResults.Test
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void LoadClubs_CallIt_ClubsPropertyShouldNotBeNull()
        {
            // Arrange
            Controller ctrl = new Controller();

            // Act
            ctrl.LoadClubs();

            // Assert
            Assert.IsNotNull(ctrl.Clubs);
        }

        [TestMethod]
        public void LoadClubs_CallIt_ClubsPropertyShouldContainCorrectNumberOfClubs()
        {
            // Arrange
            Controller ctrl = new Controller();

            // Act
            ctrl.LoadClubs();

            // Assert
            Assert.AreEqual(651, ctrl.Clubs.Count());
        }

        [TestMethod]
        public void LoadClubsWithPlayers_CallItBeforCallOfLoadClubs_ShouldThrowInvalidOperationException()
        {
            // Arrange
            Controller ctrl = new Controller();

            // Act
            // Assert
            Assert.ThrowsException<InvalidOperationException>(
                () => ctrl.LoadPlayersForClubs(),
                "Call to LoadPlayersForClubs() has to be performed after LoadClubs()");
        }

        [TestMethod]
        public void LoadPlayersForClubs_CallIt_OverallNrOfPlayersShouldBeCorrect()
        {
            // Arrange
            Controller ctrl = new Controller();

            // Act
            ctrl.LoadClubs();
            ctrl.LoadPlayersForClubs();

            // Assert
            Assert.AreEqual(18207,
                ctrl.Players
                    .Count());
        }

        [TestMethod]
        public void GetTop10ClubsAsMarkdown_CallIt_ShouldReturnCorrectClubs()
        {
            // Arrange
            Controller ctrl = new Controller();

            // Act
            ctrl.LoadClubs();
            ctrl.LoadPlayersForClubs();
            string markdown = ctrl.GetTop10ClubsAsMarkdown();

            // Assert
            Assert.IsTrue(markdown.Contains("FC Barcelona"));
            Assert.IsTrue(markdown.Contains("Real Madrid"));
            Assert.IsTrue(markdown.Contains("Manchester City"));
            Assert.IsTrue(markdown.Contains("Inter"));
            Assert.IsTrue(markdown.Contains("Tottenham Hotspur"));
            Assert.IsTrue(markdown.Contains("Paris Saint-Germain"));
            Assert.IsTrue(markdown.Contains("Manchester United"));
            Assert.IsTrue(markdown.Contains("Juventus"));
            Assert.IsTrue(markdown.Contains("Atlético Madrid"));
            Assert.IsTrue(markdown.Contains("FC Bayern München"));
        }

        [TestMethod]
        public void GetLast10ClubsAsMarkdown_CallIt_ShouldReturnCorrectClubs()
        {
            // Arrange
            Controller ctrl = new Controller();

            // Act
            ctrl.LoadClubs();
            ctrl.LoadPlayersForClubs();
            string markdown = ctrl.GetLast10ClubsAsMarkdown();

            // Assert
            Assert.IsTrue(markdown.Contains("Guangzhou R&F"));
            Assert.IsTrue(markdown.Contains("Bray Wanderers"));
            Assert.IsTrue(markdown.Contains("Limerick FC"));
            Assert.IsTrue(markdown.Contains("Derry City"));
            Assert.IsTrue(markdown.Contains("Bohemian FC"));
            Assert.IsTrue(markdown.Contains("Sligo Rovers"));
            Assert.IsTrue(markdown.Contains("St. Patrick's Athleti"));
            Assert.IsTrue(markdown.Contains("Macclesfield Town"));
            Assert.IsTrue(markdown.Contains("Morecambe"));
            Assert.IsTrue(markdown.Contains("Cambridge United"));
        }

        [TestMethod]
        public void GetPlayersUnder100KValueByNationAndValueAsMarkdown_CallIt_ShouldReturnCorrectClubs()
        {
            // Arrange
            Controller ctrl = new Controller();

            // Act
            ctrl.LoadClubs();
            ctrl.LoadPlayersForClubs();
            string markdown = ctrl.GetPlayersUnder100KValueByNationAndValueAsMarkdown();
            var players = markdown
                .Split(Environment.NewLine)
                .Skip(2)
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(_=>
                    _.Split("|")[1].Trim()
                        )
                .ToArray();

            // Assert
            Assert.AreEqual(players[40], "T. Gebauer");
            Assert.AreEqual(players[127], "Lü Peng");
            Assert.AreEqual(players[250], "R. Zapata");
            Assert.AreEqual(players[1000], "B. Arapovic");
        }

        [TestMethod]
        public void ParseCurrency_CallWithNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            string currencyString = null;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => Controller.ParseCurrency(currencyString));
        }

        [TestMethod]
        public void ParseCurrency_CallWithEmptyString_ShouldReturnZero()
        {
            // Arrange
            string currencyString = "";

            // Act
            int actualValue = Controller.ParseCurrency(currencyString);

            // Assert
            Assert.AreEqual(0, actualValue);
        }


        [TestMethod]
        public void ParseCurrency_ValueWithCurrencySymbol_ShouldBeCorrectlyParsed()
        {
            // Arrange
            string currencyString = "€ 17 ";

            // Act
            int actualValue = Controller.ParseCurrency(currencyString);

            // Assert
            Assert.AreEqual(17, actualValue);
        }

        [TestMethod]
        public void ParseCurrency_ValueWithKSymbol_ShouldBeCorrectlyParsed()
        {
            // Arrange
            string currencyString = "€ 1K ";

            // Act
            int actualValue = Controller.ParseCurrency(currencyString);

            // Assert
            Assert.AreEqual(1000, actualValue);
        }

        [TestMethod]
        public void ParseCurrency_ValueWithMSymbol_ShouldBeCorrectlyParsed()
        {
            // Arrange
            string currencyString = "€ 220M ";

            // Act
            int actualValue = Controller.ParseCurrency(currencyString);

            // Assert
            Assert.AreEqual(220000000, actualValue);
        }

        [TestMethod]
        public void ParseHeight_CallWithNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            string heightString = null;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => Controller.ParseHeightToMetric(heightString));
        }

        [TestMethod]
        public void ParseHeight_CallWithEmptyString_ShouldThrowArgumentNullException()
        {
            // Arrange
            string heightString = "";

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => Controller.ParseHeightToMetric(heightString));
        }

        [TestMethod]
        public void ParseHeight_5Feed7Inches_ShouldBeCorrectlyParsed()
        {
            // Arrange
            string heightString = " 5'7 ";

            // Act
            double actualValue = Controller.ParseHeightToMetric(heightString);

            // Assert
            Assert.AreEqual(170.18, actualValue);
        }

        [TestMethod]
        public void ParseWeight_CallWithNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            string weightString = null;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => Controller.ParseWeightToMetric(weightString));
        }

        [TestMethod]
        public void ParseWeight_CallWithEmptyString_ShouldThrowArgumentNullException()
        {
            // Arrange
            string weightString = "";

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => Controller.ParseWeightToMetric(weightString));
        }

        [TestMethod]
        public void ParseWeight_159lbs_ShouldBeCorrectlyParsed()
        {
            // Arrange
            string weightString = " 159 lbs ";

            // Act
            double actualValue = Controller.ParseWeightToMetric(weightString);

            // Assert
            Assert.AreEqual(72.12, actualValue);
        }
    }
}
