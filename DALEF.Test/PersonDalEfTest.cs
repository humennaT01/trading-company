using NUnit.Framework;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DALEF.Concrete;
using DTO;


namespace DALEF.Test
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    class PersonDalEfTest
    {
        private int id;

        public PersonDalEfTest() { }

        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(RoleDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        [Test]
        public void CreatePersonTest()
        {
            PersonDalEf person = new PersonDalEf(SetupMapper());
            var result = person.CreatePerson(new PersonDTO
            {
                PersonID = 1009,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Gender = false,
                Address = "TestAdress",
                Phone = "0000000000",
                BankCard = {},
                RowInsertTime = DateTime.UtcNow,
                RowUpdateTime = DateTime.UtcNow
            }) ;
            this.id = result.PersonID;
            Assert.IsTrue(result.PersonID != 0, "returned ID should be more than zero");
        }

        [Test]
        public void GetPersonTest()
        {
            PersonDalEf person = new PersonDalEf(SetupMapper());
            var result = person.GetPersonById(this.id);
            var res = person.GetPersonById(result.PersonID);
            Assert.IsTrue(res.PersonID != 0, "Get person by id fail");
        }

        [Test]
        public void UpdatePersonTest()
        {
            PersonDalEf person = new PersonDalEf(SetupMapper());
            var result = person.GetPersonById(this.id); 
            result.FirstName = "TestUpdatingFirstName";
            var res = person.UpdatePerson(result);

            Assert.IsTrue(result.FirstName == res.FirstName, "Update test failde");
        }

        [Test]
        public void GetAllPeopleTest()
        {
            PersonDalEf person = new PersonDalEf(SetupMapper());
            var result = person.GetAllPersons();
            Assert.IsTrue(result.Count() > 0, "Get all account fail");
        }

        [Test]
        public void DeletePersonTest()
        {
            PersonDalEf person = new PersonDalEf(SetupMapper());
            var result = person.GetPersonById(this.id);
            int id = result.PersonID;
            person.DeletePerson(result.PersonID);
            Assert.IsTrue(person.GetPersonById(id) == null, "DeleteRoleTest");
        }

        [OneTimeSetUp]
        public void SetupFixture()
        {
            Console.WriteLine("SetupFixture");
        }

        [SetUp]
        public void SetupTest()
        {
            Console.WriteLine("SetupTest");
        }

        [OneTimeTearDown]
        public void TearDownFixture()
        {
            Console.WriteLine("TearDownFixture");
        }

        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }


    }
}
