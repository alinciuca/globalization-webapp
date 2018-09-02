using NUnit.Framework;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using globalization_resources;

namespace globalization_tests
{
    [TestFixture]
    public class CultureInfoTests
    {
        [Test]
        public void ReturnCurrentCulture()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;

            Assert.AreEqual("en", currentCulture.TwoLetterISOLanguageName);
        }

        [Test]
        public void ReturnCurrentUiCulture()
        {
            var currentUiCulture = Thread.CurrentThread.CurrentUICulture;
            Assert.AreEqual("en", currentUiCulture.TwoLetterISOLanguageName);
        }

        [Test]
        public void SetNeutralCulture()
        {
            var cultureInfo = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            Assert.IsTrue(currentCulture.IsNeutralCulture);
        }

        [Test]
        public void GetDefaultResource()
        {
            //reset culture
            Resources.Culture = null;
            Assert.AreEqual("this is a test", Resources.Test);
        }

        [Test]
        public void GetCultureSpecificResource()
        {
            //set culture
            Resources.Culture = new CultureInfo("ro");
            Assert.AreEqual("Acesta este un test", Resources.Test);
        }

        [Test]
        public void Fallback()
        {
            Resources.Culture = new CultureInfo("ro");
            Assert.IsNotNull(Resources.FallbackTest);
        }
    }
}
