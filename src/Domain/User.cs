namespace SChallenge.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool UserActive { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}
