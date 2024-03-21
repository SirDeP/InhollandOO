namespace Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liftbesturingssysteem liftbesturingssysteem = new Liftbesturingssysteem();

            // Simulatie van liftverzoeken via het paneel
            liftbesturingssysteem.RegistreerVerzoek(3);
            liftbesturingssysteem.RegistreerVerzoek(5);
            liftbesturingssysteem.RegistreerVerzoek(2);

            // Simulatie van liftbeweging
            liftbesturingssysteem.PrioriteitGevenAanLift();
            liftbesturingssysteem.Lift1.Beweeg();
            liftbesturingssysteem.Lift2.Beweeg();

            // Simulatie van noodprocedure
            liftbesturingssysteem.ActiveerNoodprocedure();
            liftbesturingssysteem.PrioriteitGevenAanLift();
        }
    }
}
