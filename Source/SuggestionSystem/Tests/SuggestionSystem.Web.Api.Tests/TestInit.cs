namespace SuggestionSystem.Web.Api.Tests
{
    using Common.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.DataTransferModels);
        }
    }
}
