using Microsoft.VisualStudio.TestTools.UnitTesting;
using PxWebComparer.Services;
using Moq;

namespace PxWebComparerTest
{
    [TestClass]
    public class SavedQueryTest
    {
        [TestMethod]
        public void ShouldReturnHtml()
        {
            //ISavedQueryService savedQueryService = new SavedQueryService();
            //var savedQueryService = new Mock<ISavedQueryService>();

            //savedQueryService.Setup(x => x.);

            SavedQueryService savedQueryService = new SavedQueryService();

            var savedQueryList = savedQueryService.GetSavedQuery(string.Empty);
        }
    }
}
