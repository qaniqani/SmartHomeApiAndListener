using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartApi.Domain.Services;
using Model;
using SmartApi.Entity;

namespace SmartApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Func<SmartDbContext> dbFactory;

        public UnitTest1(Func<SmartDbContext> _dbFactory)
        {
            dbFactory = _dbFactory;
        }

        [TestMethod]
        public void BlokInsert()
        {
            var b = new BLOK
            {
                NAME = "Test",
                STATUS = 1
            };
            var db = dbFactory();
            db.Bloks.Add(b);
            int a = db.SaveChanges();
            Assert.IsTrue(a > 0);
        }
    }
}
