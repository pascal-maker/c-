namespace Exercise05.Models
{
    /// <summary>
    /// Truck - Concrete implementatie van IVehicle interface
    /// Representeert een vrachtwagen voertuig
    /// Implementeert polymorphisme door eigen Drive() methode
    /// </summary>
    public class Truck : IVehicle
    {
        /// <summary>
        /// Drive implementatie specifiek voor Truck voertuigen
        /// Override van de interface methode met truck-specifiek gedrag
        /// </summary>
        public void Drive()
        {
            // Console output specifiek voor truck voertuigen
            Console.WriteLine("Driving a truck");
        }
    }
}