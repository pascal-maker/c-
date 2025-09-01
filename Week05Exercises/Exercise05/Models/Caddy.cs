namespace Exercise05.Models
{
    /// <summary>
    /// Caddy - Concrete implementatie van IVehicle interface
    /// Representeert een caddy (golfkarretje) voertuig
    /// Implementeert polymorphisme door eigen Drive() methode
    /// </summary>
    public class Caddy : IVehicle
    {
        /// <summary>
        /// Drive implementatie specifiek voor Caddy voertuigen
        /// Override van de interface methode met caddy-specifiek gedrag
        /// </summary>
        public void Drive()
        {
            // Console output specifiek voor caddy voertuigen
            Console.WriteLine("Driving a caddie");
        }
    }
}