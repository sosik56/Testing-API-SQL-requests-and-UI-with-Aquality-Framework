namespace apiVK.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Id { get; set; }

        public User(string login, string pass, string token,string name, string secondName, string id)
        {
            Login = login;
            Password = pass;
            Token = token;
            Name = name;
            SecondName = secondName;
            Id = id;
        }
    }
}
