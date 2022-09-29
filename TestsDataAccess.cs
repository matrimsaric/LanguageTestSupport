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
        private DataAccessProvider dataAccessProvider = new DataAccessProvider();


        [TestMethod]
        public void TestVerbSaveLoadDeleteSimple()
        {
            try
            {
                Verb verb = new GodanVerb("書く", "かく", "kaku", "To Write", Guid.Empty, "書く", false);

                Task<bool> result = dataAccessProvider.GetLiveDataAccess().SaveVerb(verb);

                Task<Verb> response = dataAccessProvider.GetLiveDataAccess().LoadSpecificVerb(verb.Id);

                Assert.IsNotNull(response);

                // Delete Verb
                Task<bool> result3 = dataAccessProvider.GetLiveDataAccess().DeleteVerb(response.Result);

                // Reload should not exist
                Task<Verb> result4 = dataAccessProvider.GetLiveDataAccess().LoadSpecificVerb(verb.Id);

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

                Task<bool> result = dataAccessProvider.GetLiveDataAccess().SaveTense(tense);

                Task<Tense> response = dataAccessProvider.GetLiveDataAccess().LoadSpecificTense(tense.Id);

                Assert.IsNotNull(response);

                // Delete Verb
                Task<bool> result3 = dataAccessProvider.GetLiveDataAccess().DeleteTense(response.Result);

                // Reload should not exist
                Task<Tense> result4 = dataAccessProvider.GetLiveDataAccess().LoadSpecificTense(tense.Id);

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

        private string hackText = @"<img src=x onerror=&#x22;&#x61;&#x6C;&#x65;&#x72;&#x74;&#x28;&#x31;&#x29;&#x22;>";
        [TestMethod]
        public void TestFilteredKanjiSecurity()
        {
            try
            {

                Task<DataTable> response = dataAccessProvider.GetLiveDataAccess().LoadFilteredVerbs(1, 0, hackText);

            }
            catch(Exception ex)
            {
                return;
            }
            Assert.Fail("Hack Attempt [1] should have failed ");
        }

        [TestMethod]
        public void TestFilteredHiraganaSecurity()
        {
            try
            {
                Task<DataTable> response = dataAccessProvider.GetLiveDataAccess().LoadFilteredVerbs(1, 1, hackText);

            }
            catch
            {
                return;
            }
            Assert.Fail("Hack Attempt [1] should have failed ");
        }

        [TestMethod]
        public void TestFilteredRomajiSecurity()
        {
            try
            {
                Task<DataTable> response = dataAccessProvider.GetLiveDataAccess().LoadFilteredVerbs(1, 2, hackText);

            }
            catch
            {
                return;
            }
            Assert.Fail("Hack Attempt [1] should have failed ");
        }

        [TestMethod]
        public void TestFilteredMeaningSecurity()
        {
            try
            {
                Task<DataTable> response = dataAccessProvider.GetLiveDataAccess().LoadFilteredVerbs(1, 3, hackText);

            }
            catch
            {
                return;
            }
            Assert.Fail("Hack Attempt [1] should have failed ");
        }




       

        [TestMethod]
        public void TestLoadFilteredVerbsMethod()
        {
            try
            {


                Task<DataTable> response = dataAccessProvider.GetLiveDataAccess().LoadFilteredVerbs(1, -1, String.Empty);

                Assert.IsNotNull(response);

                if(response.Result.Rows.Count <= 2)
                {
                    // throw an error this is an ichidan search and we have more than 1 in the db
                    Assert.Fail("Expected multiple returned records for an Ichidan search");
                }

                // 2nd part search for a specific godan record
                response = dataAccessProvider.GetLiveDataAccess().LoadFilteredVerbs(2, 1, "よむ");

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
                response = dataAccessProvider.GetLiveDataAccess().LoadFilteredVerbs(1, 1, "よむ");

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
