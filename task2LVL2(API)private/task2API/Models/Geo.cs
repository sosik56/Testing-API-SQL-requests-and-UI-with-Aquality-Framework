namespace task2API.Models
{
    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public bool Equals(Geo obj)
        {
            return obj != null &&
                   this.Lat == obj.Lat &&
                   this.Lng == obj.Lng;
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as Geo;
            return toCompareWith != null &&
                   this.Lat == toCompareWith.Lat &&
                   this.Lng == toCompareWith.Lng;
        }
    }
}
