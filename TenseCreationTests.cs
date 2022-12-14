using LanguageConsult;
using LanguageConsult.Verbs;

namespace LanguageTestSupport
{
    [TestClass]
    public class TenseCreationTests
    {
        private Guid guidToUse = Guid.NewGuid();
        #region Empty Tests
        [TestMethod]
        public void BlankKanji()
        {
            try
            {
                Tense tense = new Tense("", "かく", "b", "c", "d", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE,Guid.NewGuid(),"PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("Kanji was blank exception should have been thrown");



        }

        [TestMethod]
        public void BlankHiragana()
        {
            try
            {
                Tense tense = new Tense("書", "", "b", "c", "d", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("Hiragana was blank exception should have been thrown");



        }

       

        [TestMethod]
        public void BlankMeaning()
        {
            try
            {
                Tense tense = new Tense("書", "かく", "b", "", "d", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("Meaning was blank exception should have been thrown");



        }

        [TestMethod]
        public void EmptyGuid()
        {
            try
            {
                Tense tense = new Tense("書", "かく", "b", "", "d", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("GUID was empty exception should have been thrown");



        }
        #endregion Empty Tests


        #region Hack Tests
        private string hackText = @"<img src=x onerror=&#x22;&#x61;&#x6C;&#x65;&#x72;&#x74;&#x28;&#x31;&#x29;&#x22;>";

        [TestMethod]
        public void HackKanji()
        {
            try
            {
                Tense tense = new Tense(hackText, "かく", "b", "c", "d", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("Kanji was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackHiragana()
        {
            try
            {
                Tense tense = new Tense("書", hackText, "b", "c", "d", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("Hiragana was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackRomaji()
        {
            try
            {
                Tense tense = new Tense("書", "かく", hackText, "c", "d", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("Romaji was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackMeaning()
        {
            try
            {
                Tense tense = new Tense("書", "かく", "b", hackText, "d", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("Meaning was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackNotes()
        {
            try
            {
                Tense tense = new Tense("書", "かく", "b", "c", hackText, guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");
            }
            catch
            {
                return;
            }

            Assert.Fail("Notes was illegal exception should have been thrown");



        }
        #endregion Hack Tests

        #region Valid tests
        [TestMethod]
        public void ValidEntry()
        {
            try
            {
                Tense tense = new Tense("書く", "かく", "Kaku", "To Write", "", guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, Guid.NewGuid(), "PotentialCasual");

                bool works2 = tense.IsValid();

                Assert.IsTrue(works2);
            }
            catch
            {
                Assert.Fail("Entries were valid - Exception should not have been thrown");
            }

            return;





        }

        [TestMethod]
        public void ValidateWorks()
        {
            try
            {
                Tense tense = new Tense(guidToUse, TENSE_TYPE.CURRENT_FUTURE_NEGATIVE, "PotentialCasual");// default constructor
                 bool works = tense.IsValid();

                Assert.IsFalse(works);



            }
            catch
            {
                Assert.Fail("Entries were valid - Exception should not have been thrown");
            }

            return;





        }
        #endregion Valid tests




    }
}