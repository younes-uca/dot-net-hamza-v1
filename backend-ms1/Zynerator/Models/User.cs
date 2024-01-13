namespace Project_Spring_to_.net.Zynerator.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string famillyName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

    }
}
