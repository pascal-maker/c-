namespace Vehicles.Interface // Namespace waarin de interface IRefuelable zich bevindt
{
    // Interface die aangeeft dat een voertuig of ander object kan worden "bijgetankt" (refueled)
    public interface IRefuelable
    {
        // Methode die moet worden geïmplementeerd door klassen die deze interface gebruiken
        // Deze methode bevat geen implementatie hier; die wordt ingevuld in de klasse die de interface implementeert
        void Refuel();
    }
}
