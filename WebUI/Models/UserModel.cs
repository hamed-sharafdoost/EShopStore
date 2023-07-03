namespace WebUI.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? phonenumber { get; set; }
        public DateTime CreationTime { get; set; }
        public int UserRoleId { get; set; }
    }
}
