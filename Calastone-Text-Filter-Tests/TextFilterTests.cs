using Calastone_Text_Filter.Filters;

namespace Calastone_Text_Filter.Tests
{
    [TestClass]
    public class TextFilterTests
    {
        [TestMethod]
        public void VowelInMiddleFilter_OddLength_WithVowelInMiddle_ShouldFilter()
        {
            var filter = new VowelInMiddleFilter();
            Assert.IsTrue(filter.ShouldFilter("clean"));
        }

        [TestMethod]
        public void VowelInMiddleFilter_EvenLength_WithVowelInMiddle_ShouldFilter()
        {
            var filter = new VowelInMiddleFilter();
            Assert.IsTrue(filter.ShouldFilter("what"));
        }

        [TestMethod]
        public void VowelInMiddleFilter_NoVowelInMiddle_ShouldNotFilter()
        {
            var filter = new VowelInMiddleFilter();
            Assert.IsFalse(filter.ShouldFilter("the"));
            Assert.IsFalse(filter.ShouldFilter("rather"));
        }

        [TestMethod]
        public void MinimumLengthFilter_LengthLessThan3_ShouldFilter()
        {
            var filter = new MinimumLengthFilter();
            Assert.IsTrue(filter.ShouldFilter("at")); // 2 letters
            Assert.IsTrue(filter.ShouldFilter("a"));  // 1 letter
        }

        [TestMethod]
        public void MinimumLengthFilter_LengthAtLeast3_ShouldNotFilter()
        {
            var filter = new MinimumLengthFilter();
            Assert.IsFalse(filter.ShouldFilter("the"));   // 3 letters
            Assert.IsFalse(filter.ShouldFilter("hello")); // 5 letters
        }

        [TestMethod]
        public void ContainsTFilter_WithT_ShouldFilter()
        {
            var filter = new ContainsTFilter();
            Assert.IsTrue(filter.ShouldFilter("cat"));
            Assert.IsTrue(filter.ShouldFilter("Tiger"));
        }

        [TestMethod]
        public void ContainsTFilter_WithoutT_ShouldNotFilter()
        {
            var filter = new ContainsTFilter();
            Assert.IsFalse(filter.ShouldFilter("dog"));
        }

        [TestMethod]
        public void TextProcessor_CombinedFilters_ShouldReturnFilteredText()
        {
            var filters = new List<ITextFilter>
            {
                new VowelInMiddleFilter(),
                new MinimumLengthFilter(),
                new ContainsTFilter()
            };

            var processor = new TextProcessor(filters);
            List<string> result = processor.ProcessText("InputFile.txt").ToList();

            Assert.AreEqual("hello", result[0]);
            Assert.AreEqual("world", result[1]);
        }
    }
}
