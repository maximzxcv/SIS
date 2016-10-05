using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sis.Interview.Dal.Framework;
using Sis.Interview.Models.ScrumCeremony;

namespace Sis.Interview.Tests
{
    [TestClass]
    public class RetrospectiveServiceTests: BaseTest
    {
        [TestMethod]
        public void CreateShouldReturnWithCorrectId()
        {
            var retrospectiveService = GetService<BaseService<Retrospective>>();
            var sourceItem = CreateTestRetrospective();
            var objectToAssert = retrospectiveService.Create(sourceItem);

            Assert.AreEqual(sourceItem.Name, objectToAssert.Name);
        }

        [TestMethod]
        public void CreateShouldFail()
        {
            var retrospectiveService = GetService<BaseService<Retrospective>>();
            var sourceItem = new Retrospective();

            try
            {
                var objectToAssert = retrospectiveService.Create(sourceItem);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NullReferenceException));
            }
        }

        [TestMethod]
        public void GetAllShouldReturnEmptyIenumerable()
        {
            var retrospectiveService = GetService<BaseService<Retrospective>>();
            var retrospectives = retrospectiveService.Get();

            Assert.AreEqual(retrospectives.Count(), 0);
        }

        [TestMethod]
        public void GetAllShouldReturnSameAmountAsCreated()
        {
            var retrospectiveService = GetService<BaseService<Retrospective>>();
            var randomAmount = new Random().Next(3, 9);
            for (var i = 0; i < randomAmount; i++)
                retrospectiveService.Create(CreateTestRetrospective());

            var retrospectives = retrospectiveService.Get();

            Assert.AreEqual(retrospectives.Count(), randomAmount);
        }
    }
}

