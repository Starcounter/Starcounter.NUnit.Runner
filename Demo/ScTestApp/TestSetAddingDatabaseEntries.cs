using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;
using ScApp;
using NUnit.Framework;

namespace ScTestApp
{
    [TestFixture]
    public class TestSetAddingDatabaseEntries
    {
        [Test]
        public void TestCase_AddingNewRow_1()
        {
            AddNewRow();
        }
        
        [Test]
        public void TestCase_AddingNewRow_2()
        {
            AddNewRow();
        }
        
        [Test]
        public void TestCase_AddingNewRow_3()
        {
            AddNewRow();
        }

        private void AddNewRow()
        {
            int entriesBeforeCount = 0;
            int entriesAfterCount = 0;

            Scheduling.ScheduleTask(() => {
                entriesBeforeCount = Db.SQL<ScAppDb>(ScApp.Program.GetAllDbEntriesCommand).Count();

                Db.Transact(() =>
                {
                    ScAppDb entry = new ScAppDb();
                });

                entriesAfterCount = Db.SQL<ScAppDb>(ScApp.Program.GetAllDbEntriesCommand).Count();
            }, waitForCompletion: true);

            Assert.True(int.Equals(entriesBeforeCount + 1, entriesAfterCount), $"ScApp.ScAppDb beforeCount={entriesBeforeCount} is not one less than afterCount={entriesAfterCount}");
        }
    }
}
