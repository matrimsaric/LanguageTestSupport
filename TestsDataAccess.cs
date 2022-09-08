using LanguageConsult.DataAccess.MSSqlDataAccess;
using LanguageConsult.DataAccess;
using LanguageConsult.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace LanguageTestSupport
{
    [TestClass]
    public class TestsDataAccess
    {
        private Guid guidToUse = Guid.NewGuid();
        private DataAccess dat = new MsSqlDataAccess();

        [TestMethod]
        public void TestVerbSaveSimple()
        {
            try
            {
                Verb verb = new GodanVerb("書く", "かく", "kaku", "To Write", Guid.Empty);

                Task<bool> result = dat.SaveVerb(verb);

                Task<Verb> response = dat.LoadSpecificVerb(verb.Id);

                Assert.IsNotNull(response);

                // display result

            }
            catch(Exception ex)
            {
                Assert.Fail("Exception thrown Test fail: " + ex);

            }


        }

        //private async Task<bool> RunVerbSave(Verb vb)
        //{
        //    Task<bool> result = dat.SaveVerb(vb);

        //    return result;
        //}
    }
}
