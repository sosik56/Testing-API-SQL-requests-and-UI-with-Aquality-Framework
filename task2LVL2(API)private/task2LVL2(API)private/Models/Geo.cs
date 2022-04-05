namespace task2LVL2_API_private.Models
{
    public class Geo
    {
        public string Lat { get; set; }        
        public string Lng { get; set; }

        public bool Equals (Geo obj)
        {
            return obj != null &&
                   this.Lat == obj.Lat &&
                   this.Lng == obj.Lng;
        }
    }
}
