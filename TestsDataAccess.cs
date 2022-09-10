using LanguageConsult.DataAccess.MSSqlDataAccess;
using LanguageConsult.DataAccess;
using LanguageConsult.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using NuGet.Frameworks;
using LanguageConsult.Verbs.InflectionControl;

namespace LanguageTestSupport
{
    [TestClass]
    public class TestsDataAccess
    {
        private Guid guidToUse = Guid.NewGuid();
        private DataAccess dat = new MsSqlDataAccess();

        [TestMethod]
        public void TestVerbSaveLoadDeleteSimple()
        {
            try
            {
                Verb verb = new GodanVerb("書く", "かく", "kaku", "To Write", Guid.Empty, "書く", false);

                Task<bool> result = dat.SaveVerb(verb);

                Task<Verb> response = dat.LoadSpecificVerb(verb.Id);

                Assert.IsNotNull(response);

                // Delete Verb
                Task<bool> result3 = dat.DeleteVerb(response.Result);

                // Reload should not exist
                Task<Verb> result4 = dat.LoadSpecificVerb(verb.Id);

                if(result4.Result.Id != Guid.Empty)
                {
                    Assert.Fail("Verb has not deleted fail: " + verb.Id);
                }

            }
            catch(Exception ex)
            {
                Assert.Fail("Exception thrown Tense SaveLoadDelete fail fail: " + ex);

            }


        }

        [TestMethod]
        public void TesInflectionSaveLoadDeleteSimple()
        {
            try
            {
                Inflection full = new StandardCasual("A", Guid.NewGuid(), Guid.NewGuid());

                Task<bool> result = dat.SaveInflection(full);

                Task<Inflection> response = dat.LoadSpecificInflection(full.Id);

                Assert.IsNotNull(response);

                // Delete Verb
                Task<bool> result3 = dat.DeleteInflection(response.Result);

                // Reload should not exist
                Task<Inflection> result4 = dat.LoadSpecificInflection(full.Id);

                if (result4.Result.Id != Guid.Empty)
                {
                    Assert.Fail("Inflection has not deleted fail: " + full.Id);
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Exception thrown Inflection SaveLoadDelete fail: " + ex);

            }


        }

        [TestMethod]
        public void TestTenseSaveLoadDeleteSimple()
        {
            try
            {
                Tense tense = new Tense("書く", "かく", "Kaku", "To Write", "", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid());

                Task<bool> result = dat.SaveTense(tense);

                Task<Tense> response = dat.LoadSpecificTense(tense.Id);

                Assert.IsNotNull(response);

                // Delete Verb
                Task<bool> result3 = dat.DeleteTense(response.Result);

                // Reload should not exist
                Task<Tense> result4 = dat.LoadSpecificTense(tense.Id);

                if (result4.Result.Id != Guid.Empty)
                {
                    Assert.Fail("Tense has not deleted fail: " + tense.Id);
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Exception thrown Tense SaveLoadDelete fail: " + ex);

            }


        }

    }
}
