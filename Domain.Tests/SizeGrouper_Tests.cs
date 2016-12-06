using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class SizeGrouper_Tests
    {
        [Test]
        public void Grouping_list_of_one_by_one_produces_group_of_size_one()
        {
            var measurements = new List<Measurement>()
                                   {
                                       new Measurement() {HighValue = 10, LowValue = 1}
                                   };

            var grouper = new SizeGrouper(1);
            var groupedResults = grouper.Group(measurements);
              
            Assert.AreEqual(1, groupedResults.Count);
        }

        [Test]
        public void Grouping_list_of_two_by_one_produces_group_of_size_two()
        {
            var measurements = new List<Measurement>()
                                   {
                                       new Measurement() {HighValue = 10, LowValue = 1},
                                       new Measurement() {HighValue = 10, LowValue = 1}
                                   };

            var grouper = new SizeGrouper(1);
            var groupedResults = grouper.Group(measurements);

            Assert.AreEqual(2, groupedResults.Count);
        }

        [Test]
        public void Grouping_list_of_four_by_two_produces_group_of_size_two()
        {
            var measurements = CreateMeasurementListOfSize(4);

            var grouper = new SizeGrouper(2);
            var groupedResults = grouper.Group(measurements);

            Assert.AreEqual(2, groupedResults.Count);
            Assert.IsTrue(groupedResults.All(g => g.Count == 2));
        }

        private List<Measurement> CreateMeasurementListOfSize(int size)
        {
            var result = new List<Measurement>();
            for (int i = 0; i < size; i++)
            {
                result.Add(new Measurement() { HighValue = 10, LowValue = 1 });
            }
            return result;
        }
    }
}