using LanguageConsult;
using LanguageConsult.Verbs;

namespace LanguageTestSupport
{
    [TestClass]
    public class VerbCreationTests
    {
        private Guid guidToUse = Guid.NewGuid();
        #region Empty Tests
        [TestMethod]
        public void BlankIchidanKanji()
        {
            try
            {
                Verb verb = new IchidanVerb(String.Empty, "かく", "b", "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Ichidan Kanji was blank, exception should have been thrown");
        }

        [TestMethod]
        public void BlankGodanKanji()
        {
            try
            {
                Verb verb = new GodanVerb(String.Empty, "かく", "b", "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Godan Kanji was blank, exception should have been thrown");
        }

        [TestMethod]
        public void BlankIchidanHiraganai()
        {
            try
            {
                Verb verb = new IchidanVerb("書", String.Empty, "b", "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Ichidan Hiragana was blank, exception should have been thrown");
        }

        [TestMethod]
        public void BlankGodanHiragana()
        {
            try
            {
                Verb verb = new GodanVerb("書", String.Empty, "b", "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Godan Hiragana was blank, exception should have been thrown");
        }

        [TestMethod]
        public void BlankIchidanRomaji()
        {
            try
            {
                Verb verb = new IchidanVerb("書", "かく", String.Empty, "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Ichidan Romaji was blank, exception should have been thrown");
        }

        [TestMethod]
        public void BlankGodanRomaji()
        {
            try
            {
                Verb verb = new GodanVerb("書", "かく", String.Empty, "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Godan Romaji was blank, exception should have been thrown");
        }

       

       
        #endregion Empty Tests


        #region Hack Tests
        private string hackText = @"<img src=x onerror=&#x22;&#x61;&#x6C;&#x65;&#x72;&#x74;&#x28;&#x31;&#x29;&#x22;>";

        [TestMethod]
        public void HackIchidanKanji()
        {
            try
            {
                Verb verb = new IchidanVerb(hackText, "かく", String.Empty, "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Ichidan Kanji was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackIchidanHiragana()
        {
            try
            {
                Verb verb = new IchidanVerb("書", hackText, String.Empty, "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Ichidan Hiragana was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackIchidanRomaji()
        {
            try
            {
                Verb verb = new IchidanVerb("書", "かく", hackText, "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Ichidan Romaji was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackIchidanMeaning()
        {
            try
            {
                Verb verb = new IchidanVerb("書", "かく", "a", hackText, Guid.NewGuid(), "書", false);
               
            }
            catch
            {
                return;
            }

            Assert.Fail("Ichidan Meaning was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackGodanKanji()
        {
            try
            {
                Verb verb = new GodanVerb(hackText, "かく", String.Empty, "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Godan Kanji was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackGodanHiragana()
        {
            try
            {
                Verb verb = new GodanVerb("書", hackText, String.Empty, "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Godan Hiragana was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackGodanRomaji()
        {
            try
            {
                Verb verb = new GodanVerb("書", "かく", hackText, "c", Guid.NewGuid(), "書", false);
            }
            catch
            {
                return;
            }

            Assert.Fail("Godan Romaji was illegal exception should have been thrown");



        }

        [TestMethod]
        public void HackGodanMeaning()
        {
            try
            {
                Verb verb = new GodanVerb("書", "かく", "a", hackText, Guid.NewGuid(), "書", false);

            }
            catch
            {
                return;
            }

            Assert.Fail("Godan Meaning was illegal exception should have been thrown");



        }


        #endregion Hack Tests

        #region Valid tests
        [TestMethod]
        public void ValidEntries()
        {
            try
            {
                Verb ichidanVerb = new IchidanVerb("書く", "かく", "Kaku", "To Write",  Guid.NewGuid(), "書", false);
                Verb godanVerb = new GodanVerb("書く", "かく", "Kaku", "To Write", Guid.NewGuid(), "書", false);

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