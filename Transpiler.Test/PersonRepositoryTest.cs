using CallingApp.Data.Entities;
using CallingApp.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Translator.Test
{
    [TestClass]
    public class PersonRepositoryTest
    {
        private PersonRepository Repository => UnityConfig.Container.Resolve<PersonRepository>();

        [TestMethod]
        [Priority(7)]
        public void Init() => Repository.Init();

        [TestMethod]
        [Priority(6)]
        public void Insert() => Repository.Insert(new Person() { FirstName = "John", LastName = "Doe", IdNumber = "9006165128081" });

        [TestMethod]
        [Priority(5)]
        public void FindSingle() => Assert.IsNotNull(Repository.FindSingle(1));

        [TestMethod]
        [Priority(4)]
        public void InsertIgnore() => Repository.InsertIgnore(new Person() { FirstName = "John", LastName = "Doe", IdNumber = "9006165128081" });

        [TestMethod]
        [Priority(3)]
        public void Update() => Repository.Update(new Person() { Id = 1, FirstName = "Jamie", LastName = "Lannister", IdNumber = "9006165128081" });

        [TestMethod]
        [Priority(2)]
        public void Replace() => Repository.Replace(new Person() { Id = 1, FirstName = "Johnny", LastName = "Donut", IdNumber = "9006165128081" });

        [TestMethod]
        [Priority(1)]
        public void Delete() => Repository.Delete(new Person() { Id = 1 });

    }
}
