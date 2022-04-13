namespace task2API.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public bool Equals(Company obj)
        {
            return obj != null &&
                   this.Name == obj.Name &&
                   this.CatchPhrase == obj.CatchPhrase &&
                   this.Bs == obj.Bs;
        }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Company;

            return toCompareWith != null &&
                   this.Name == toCompareWith.Name &&
                   this.CatchPhrase == toCompareWith.CatchPhrase &&
                   this.Bs == toCompareWith.Bs;
        }
    }
}
