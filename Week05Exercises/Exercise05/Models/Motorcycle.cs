namespace Exercise05.Models
{
    /// <summary>
    /// Motorcycle - Concrete implementatie van IVehicle interface
    /// Representeert een motorfiets voertuig
    /// Implementeert polymorphisme door eigen Drive() methode
    /// </summary>
    public class Motorcycle : IVehicle
    {
        /// <summary>
        /// Drive implementatie specifiek voor Motorcycle voertuigen
        /// Override van de interface methode met motorcycle-specifiek gedrag
        /// </summary>
        public void Drive()
        {
            // Console output specifiek voor motorcycle voertuigen
            Console.WriteLine("Driving a motorcycle");
        }
    }
}