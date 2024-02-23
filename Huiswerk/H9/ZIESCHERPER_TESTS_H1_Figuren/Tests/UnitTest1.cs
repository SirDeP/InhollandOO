using FigurenConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPClassBasicsTesterLibrary;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void TestRechthoekProps()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new Rechthoek());

            tester.CheckFullProperty("Lengte", typeof(int));
            tester.CheckFullProperty("Breedte", typeof(int));
            tester.TestPropGetSet("Lengte", 5, 5);
            tester.TestPropGetSet("Breedte", 7, 7);
            tester.TestPropGetSet("Lengte", -2, 5);
            tester.TestPropGetSet("Breedte", -5, 7);
        }

        [TestMethod]
        public void TestRechthoekMethode()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new Rechthoek());
            if (tester.CheckMethod("ToonOppervlakte", typeof(void)))
            {
                if (tester.CheckFullProperty("Breedte", typeof(int)) && tester.CheckFullProperty("Lengte", typeof(int)))
                {
                    tester.SetProp("Lengte", 5);
                    tester.SetProp("Breedte", 6);
                    var res = tester.TestMethod("ToonOppervlakte", null);
                    Assert.AreEqual("30", res);
                }
            }
               
        }

        [TestMethod]
        public void TestDriehoekProps()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new Driehoek());

            tester.CheckFullProperty("Basis", typeof(int));
            tester.CheckFullProperty("Hoogte", typeof(int));
            tester.TestPropGetSet("Basis", 5, 5);
            tester.TestPropGetSet("Hoogte", 7, 7);
            tester.TestPropGetSet("Basis", -2, 5);
            tester.TestPropGetSet("Hoogte", -5, 7);
        }

        [TestMethod]
        public void TestDriehoekMethode()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new Driehoek());
            if (tester.CheckMethod("ToonOppervlakte", typeof(void)))
            {
                if (tester.CheckFullProperty("Basis", typeof(int)) && tester.CheckFullProperty("Hoogte", typeof(int)))
                {
                    tester.SetProp("Basis", 5);
                    tester.SetProp("Hoogte", 6);
                    var res = tester.TestMethod("ToonOppervlakte", null);
                    Assert.AreEqual("15", res);
                }
            }
        }

    }

}
