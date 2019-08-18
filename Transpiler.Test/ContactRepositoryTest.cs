using CallingApp.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Translator.Test
{
    [TestClass]
    public class ContactRepositoryTest
    {
        private ContactRepository Repository => UnityConfig.Container.Resolve<ContactRepository>();

        [TestMethod]
        [Priority(7)]
        public void Init() => Repository.Init();
    }
}
