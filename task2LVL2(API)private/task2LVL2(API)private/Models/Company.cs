namespace task2LVL2_API_private.Models
{
    public class Company
    {
        public string Name { get; set; }        
        public string CatchPhrase { get; set; }        
        public string Bs { get; set; }

        public bool Equals (Company obj)
        {
            return obj != null &&
                   this.Name == obj.Name &&
                   this.CatchPhrase == obj.CatchPhrase &&
                   this.Bs == obj.Bs;
        }
    }
}
