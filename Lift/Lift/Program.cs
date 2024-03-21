namespace Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liftbesturingssysteem liftbesturingssysteem = new Liftbesturingssysteem();
            Paneel paneel = new Paneel();

            // Simulatie van liftverzoeken via het paneel
            paneel.Verzoek(3, liftbesturingssysteem);
            paneel.Verzoek(5, liftbesturingssysteem);
            paneel.Verzoek(2, liftbesturingssysteem);

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
