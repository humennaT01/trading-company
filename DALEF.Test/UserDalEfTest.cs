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
    class UserDalEfTest
    {
        private int id;

        public UserDalEfTest() { }

        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(RoleDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        [Test]
        public void CreateUserTest()
        {
            UserDalEf user = new UserDalEf(SetupMapper());
            var result = user.CreateUser(new UserDTO
            {
                UserID = 1009,
                Login = "TestLogin",
                Email = "Test.Email@gmail.com",
                Password = { },
                Status = true,
                PersonID = 1,
                RoleID = 1,
                RowInsertTime = DateTime.UtcNow,
                RowUpdateTime = DateTime.UtcNow
            }) ;
            this.id = result.UserID;
            Assert.IsTrue(result.UserID != 0, "returned ID should be more than zero");
        }
        [Test]
        public void UpdateUserTest()
        {
            UserDalEf user = new UserDalEf(SetupMapper());
            var result = user.GetUserById(this.id);
            result.Login = "TestUpdatingLogin";
            var res = user.UpdateUser(result);

            Assert.IsTrue(result.Login == res.Login, "Update test failde");
        }

        [Test]
        public void GetUserTest()
        {
            UserDalEf user = new UserDalEf(SetupMapper());
            var result = user.GetUserById(this.id);
            var res = user.GetUserById(result.UserID);
            Assert.IsTrue(res.RoleID != 0, "Get user by id fail");
        }
        [Test]
        public void GetAllUsersTest()
        {
            UserDalEf user = new UserDalEf(SetupMapper());
            var result = user.GetAllUser();
            Assert.IsTrue(result.Count() > 0, "Get all account fail");
        }

        [Test]
        public void DeleteUserTest()
        {
            UserDalEf user = new UserDalEf(SetupMapper());
            var result = user.GetUserById(this.id);
            int Id = result.RoleID;
            user.DeleteUser(result.UserID);
            Assert.IsTrue(user.GetUserById(Id) == null, "DeleteRoleTest");
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
