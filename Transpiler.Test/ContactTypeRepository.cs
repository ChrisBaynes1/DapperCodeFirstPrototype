using CallingApp.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Translator.Test
{
    [TestClass]
    public class ContactTypeRepositoryTest
    {
        private ContactTypeRepository Repository => UnityConfig.Container.Resolve<ContactTypeRepository>();

        [TestMethod]
        [Priority(7)]
        public void Init() => Repository.Init();
    }
}
