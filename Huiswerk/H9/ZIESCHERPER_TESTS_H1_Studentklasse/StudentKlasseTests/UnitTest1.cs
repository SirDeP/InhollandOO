using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPClassBasicsTesterLibrary;
using Studentenklasse;

namespace StudentKlasseTests
{
    [TestClass]
    public class UnitTest1
    {
        TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new Student());
        [TestMethod]
        public void TestAutoProps()
        {
            tester.CheckAutoProperty("Naam", typeof(string));
            tester.CheckAutoProperty("Leeftijd", typeof(int));
            tester.CheckAutoProperty("Klas", typeof(Klassen));
            tester.CheckAutoProperty("PuntenCommunicatie", typeof(int));
            tester.CheckAutoProperty("PuntenProgrammingPrinciples", typeof(int));
            tester.CheckAutoProperty("PuntenWebTech", typeof(int));
        }

        [TestMethod]
        public void TestBerekenGemiddelde()
        {
            if (tester.CheckMethod("BerekenGemiddelde", typeof(double)))
            {
                int pc = 12;
                int pp = 14;
                int wt = 9;

                tester.SetProp("PuntenCommunicatie", pc);
                tester.SetProp("PuntenProgrammingPrinciples", pp);
                tester.SetProp("PuntenWebTech", wt);
                tester.TestMethod("BerekenGemiddelde", null, (pc + pp + wt) / 3.0, $"Punten werden op {pc},{pp} en {wt} gezet.");
            }
        }


        [TestMethod]
        public void TestGeefOverzicht()
        {
            
            if (tester.CheckMethod("GeefOverzicht", typeof(void)))
            {
               
                int pc = 12;
                int pp = 15;
                int wt = 13;
                string naam = "Joske Vermeulen";
                int leeftijd = 21;
                tester.SetProp("Naam", naam);
                tester.SetProp("Klas", Studentenklasse.Klassen.TI1);
                tester.SetProp("Leeftijd", 21);
                tester.SetProp("PuntenCommunicatie", pc);
                tester.SetProp("PuntenProgrammingPrinciples", pp);
                tester.SetProp("PuntenWebTech", wt);
                string result = tester.TestMethod("GeefOverzicht", null, null);
                Assert.IsTrue(result.Contains(Studentenklasse.Klassen.TI1.ToString()), "GeefOverzicht toont de klas niet op het scherm");
                Assert.IsTrue(result.Contains(leeftijd.ToString()) && result.Contains("jaar"), "GeefOverzicht toont de leeftijd niet op het scherm");
                Assert.IsTrue(result.Contains(naam), "GeefOverzicht toont de naam niet op het scherm");
                Assert.IsTrue(result.Contains(pc.ToString()), "GeefOverzicht toont de punten van Communicatie niet op het scherm");
                Assert.IsTrue(result.Contains(pp.ToString()), "GeefOverzicht toont de punten van Programming Principles niet op het scherm");
                Assert.IsTrue(result.Contains(wt.ToString()), "GeefOverzicht toont de punten van WebTechnology niet op het scherm");
                Assert.IsTrue(result.Contains(((pc + pp + wt) / 3.0).ToString()), "GeefOverzicht toont het gemiddelde niet op het scherm");
                //  tester.TestMethod("BerekenGemiddelde", null, (pc + pp + wt) / 3.0, $"Punten werden op {pc},{pp} en {wt} gezet.");
            }
        }
    }
}
