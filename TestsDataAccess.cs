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
using System.Data;

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
        public void TestTenseSaveLoadDeleteSimple()
        {
            try
            {
                Tense tense = new Tense("書く", "かく", "Kaku", "To Write", "", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(),"PotentialCasual");

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

        [TestMethod]
        public void TestLoadFilteredVerbsMethod()
        {
            try
            {


                Task<DataTable> response = dat.LoadFilteredVerbs(1, -1, String.Empty);

                Assert.IsNotNull(response);

                if(response.Result.Rows.Count <= 2)
                {
                    // throw an error this is an ichidan search and we have more than 1 in the db
                    Assert.Fail("Expected multiple returned records for an Ichidan search");
                }

                // 2nd part search for a specific godan record
                response = dat.LoadFilteredVerbs(2, 1, "よむ");

                Assert.IsNotNull(response);

                if (response.Result.Rows.Count != 1)
                {
                    // throw an error this is an ichidan search and we have more than 1 in the db
                    Assert.Fail("Expected single returned record..");

                    // then check record is yomu
                    DataTable res = response.Result;

                    if (res.Rows[0]["Hiragana"].ToString() != "よむ")
                    {
                        Assert.Fail("Expected Yomu to be returned, actual return was: " + res.Rows[0]["Hiragana"].ToString());
                    }
                }

                // 3rd part search for a specific godan record with an ichidan flag, should return zero
                response = dat.LoadFilteredVerbs(1, 1, "よむ");

                Assert.IsNotNull(response);

                if (response.Result.Rows.Count != 0)
                {
                    // throw an error this is an ichidan search and we have more than 1 in the db
                    Assert.Fail("Expected no returns as a fake search");

                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Exception thrown Tense SaveLoadDelete fail: " + ex);

            }


        }

    }
}
