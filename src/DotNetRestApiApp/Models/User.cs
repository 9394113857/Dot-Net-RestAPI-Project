namespace DotNetRestApiApp.Models
{
    public class User
    {
        public int Id { get; set; }          // Primary Key
        public required string Username { get; set; } // Username
        public required string Email { get; set; }    // Email Address
    }
}
