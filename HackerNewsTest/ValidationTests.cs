using HackerNewsLibrary.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsTest
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateInvalidUriTest()
        {
            string uri = "Bad URI";
            string error = string.Empty;

            ValidatePostInput.ValidateUri(uri, out error);

            Assert.AreEqual("Incorrectly formed URL - Bad URI", error);
        }

        [TestMethod]
        public void ValidateValidUriTest()
        {
            string uri = "http://wwww.google.com";
            string error = string.Empty;
            
            Assert.IsTrue(ValidatePostInput.ValidateUri(uri, out error));
        }

        [TestMethod]
        public void ValidateAuthorTest()
        {
            string Author = "Adil Ahmed";
            string error = string.Empty;
            Assert.IsTrue(ValidatePostInput.ValidateAuthor(Author, out error));
        }

        [TestMethod]
        public void ValidatePointsTest()
        {
            string input = "10";
            int Points = 0;
            string error = string.Empty;
            ValidatePostInput.ValidatePoints(input, out Points, out error);
            Assert.AreEqual(10, Points);

        }

        [TestMethod]
        public void ValidateCommentsTest()
        {
            string input = "Adil";
            int Points = 0;
            string error = string.Empty;
            ValidatePostInput.ValidateComments(input, out Points, out error);
            Assert.AreNotEqual(input, Points);

        }

        [TestMethod]
        public void ValidateRankTest()
        {
            string input = "-1";
            int rank = 0;
            string error = string.Empty;
            ValidatePostInput.ValidateRank(input, out rank, out error);
            Assert.AreEqual(error, "Rank must be greater than 0.");

        }
        
    }
}
