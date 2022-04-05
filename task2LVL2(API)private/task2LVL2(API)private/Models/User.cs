using Newtonsoft.Json;

namespace task2LVL2_API_private.Models
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
    }
}
