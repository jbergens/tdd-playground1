using Xunit;

namespace Algorithm.Tests
{    
    public class FinderTests
    {
        private readonly Thing _sue = new() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        private readonly Thing _greg = new() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        private readonly Thing _sarah = new() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        private readonly Thing _mike = new() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };

        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Thing>();
            var finder = new Finder(list);

            var result = finder.Find(FT.One);

            Assert.Null(result.P1);
            Assert.Null(result.P2);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Thing>() { _sue };
            var finder = new Finder(list);

            var result = finder.Find(FT.One);

            Assert.Null(result.P1);
            Assert.Null(result.P2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Thing>() { _sue, _greg };
            var finder = new Finder(list);

            var result = finder.Find(FT.One);

            Assert.Same(_sue, result.P1);
            Assert.Same(_greg, result.P2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Thing>() { _greg, _mike };
            var finder = new Finder(list);

            var result = finder.Find(FT.Two);

            Assert.Same(_greg, result.P1);
            Assert.Same(_mike, result.P2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Thing>() { _greg, _mike, _sarah, _sue };
            var finder = new Finder(list);

            var result = finder.Find(FT.Two);

            Assert.Same(_sue, result.P1);
            Assert.Same(_sarah, result.P2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Thing>() { _greg, _mike, _sarah, _sue };
            var finder = new Finder(list);

            var result = finder.Find(FT.One);

            Assert.Same(_sue, result.P1);
            Assert.Same(_greg, result.P2);
        }
    }
}