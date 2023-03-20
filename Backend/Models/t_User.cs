namespace Backend.Models
{
    public class t_User
    {
        public int UserId { get; set;}
        public string Name { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
        public string Gender { get; set;}
        public string Address { get; set;}
        public string City { get; set;}
        public string Contact { get; set;}
        public string Image { get; set;}
        public bool IsTraveler { get; set;}
    }
}