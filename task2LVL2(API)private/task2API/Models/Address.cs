namespace task2API.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }

        public bool Equals(Address obj)
        {
            return obj != null &&
                   this.Street == obj.Street &&
                   this.City == obj.City &&
                   this.Zipcode == obj.Zipcode &&
                   this.Geo.Equals(obj.Geo);
        }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Address;            
            return toCompareWith != null &&
                   this.Street == toCompareWith.Street &&
                   this.City == toCompareWith.City &&
                   this.Zipcode == toCompareWith.Zipcode &&
                   this.Geo.Equals(toCompareWith.Geo);
        }
    }
}
