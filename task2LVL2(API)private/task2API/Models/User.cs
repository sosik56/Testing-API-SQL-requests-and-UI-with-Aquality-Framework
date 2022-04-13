using Newtonsoft.Json;

namespace task2API.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }


        public bool Equals(User obj)
        {
            return obj != null &&
                   this.Id == obj.Id &&
                   this.Name == obj.Name &&
                   this.Username == obj.Username &&
                   this.Email == obj.Email &&
                   this.Phone == obj.Phone &&
                   this.Website == obj.Website &&
                   this.Address.Equals(obj.Address) &&
                   this.Company.Equals(obj.Company);
        }

        public override bool Equals(object other)
        {
            var toCompareWith = other as User;    
            
            return toCompareWith != null &&
                   this.Id == toCompareWith.Id &&
                   this.Name == toCompareWith.Name &&
                   this.Username == toCompareWith.Username &&
                   this.Email == toCompareWith.Email &&
                   this.Phone == toCompareWith.Phone &&
                   this.Website == toCompareWith.Website &&
                   this.Address.Equals(toCompareWith.Address) &&
                   this.Company.Equals(toCompareWith.Company);
        }
    }
}
