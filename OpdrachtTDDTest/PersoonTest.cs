using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpdrachtTDD;
using System;
using System.Collections.Generic;

namespace OpdrachtTDDTest
{
    [TestClass]
    public class PersoonTest
    {
        private List<string> lijst;

        [TestInitialize]
        public void Initialize()
        {
            lijst = new List<string>();
        }

        [TestMethod]
        public void PersoonMetCorrecteVoornamenIsOk()
        {
            lijst.Add("Jan");
            lijst.Add("Stijn");
            new Persoon(lijst);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void PersoonMet0VoornamenIsVerkeerd()
        {
            new Persoon(lijst);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void PersoonMetNullIsVerkeerd()
        {
            new Persoon(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void PersoonMet2IdentiekeVoornamenIsVerkeerd()
        {
            lijst.Add("Wim");
            lijst.Add("Henk");
            lijst.Add("Wim");
            new Persoon(lijst);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void LegeVoornaamIsVerkeerd()
        {
            lijst.Add(String.Empty);
            new Persoon(lijst);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void VoornaamZonderTekensIsVerkeerd()
        {
            lijst.Add(" ");
            new Persoon(lijst);
        }

        [TestMethod]
        public void ToStringMoetNamenMetSpatiesTeruggeven()
        {
            lijst.Add("Bart");
            lijst.Add("Tom");
            var persoon = new Persoon(lijst);
            Assert.AreEqual("Bart Tom ", persoon.ToString());
        }
    }
}
