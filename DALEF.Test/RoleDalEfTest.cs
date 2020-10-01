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
    public class RoleDalEfTest
    {
        private int id;

        public RoleDalEfTest() { }
        
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(RoleDalEf).Assembly)
                );
            return conf.CreateMapper();
        }

        [Test]
        public void CreateRoleTest()
        {
            RoleDalEf role = new RoleDalEf(SetupMapper());
            var result = role.CreateRole(new RoleDTO
            {
                RoleID = 1009,
                RoleName = "TestCreatingName",
                RowInsertTime = DateTime.UtcNow
            }) ;
            this.id = result.RoleID;
            Assert.IsTrue(result.RoleID != 0, "returned ID should be more than zero");
        }
        [Test]
        public void UpdateRoleTest()
        {
            RoleDalEf role = new RoleDalEf(SetupMapper());
            var result = role.GetRoleById(this.id); 
            result.RoleName = "TestUpdatingName";
            var res = role.UpdateRole(result);
            
            Assert.IsTrue(result.RoleName == res.RoleName, "Update test faile");
        }
        
        [Test]
        public void GetRoleTest()
        {
            RoleDalEf role = new RoleDalEf(SetupMapper());
            var result = role.GetRoleById(this.id);
            var res = role.GetRoleById(result.RoleID);
            Assert.IsTrue(res.RoleID != 0, "Get role by id fail");
        }
        [Test]
        public void GetAllRolesTest()
        {
            RoleDalEf role = new RoleDalEf(SetupMapper());
            var result = role.GetAllRole();
            Assert.IsTrue(result.Count() > 0, "Get all account fail");
        }

        [Test]
        public void DeleteRoleTest()
        {
            RoleDalEf role = new RoleDalEf(SetupMapper());
            var result = role.GetRoleById(this.id);
            int Id = result.RoleID;
            role.DeleteRole(result.RoleID);
            Assert.IsTrue(role.GetRoleById(Id) == null, "DeleteRoleTest");
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


