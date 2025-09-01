namespace Exercise05.Models
{
    /// <summary>
    /// IVehicle - Interface voor alle voertuig types
    /// Definieert het gemeenschappelijke contract dat alle voertuigen moeten implementeren
    /// Volgt het Interface Segregation Principle van SOLID
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Drive methode - Moet geïmplementeerd worden door alle voertuig klassen
        /// Elke voertuig type kan zijn eigen implementatie hebben (polymorphisme)
        /// </summary>
        void Drive();
    }
}