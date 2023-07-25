namespace coreMvcSecurityProject.Models
{
    public class AccountModel
    {
        private List<Account> accounts;
        public AccountModel()
        {
            accounts = new List<Account>();
            accounts.Add(new Account()
            {
                Username = "Test1",
                Password = "123",
                Roles = new string[] { "admin", "employee"}
            });
            accounts.Add(new Account()
            {
                Username = "Test2",
                Password = "123",
                Roles = new string[] { "admin" }
            });
            accounts.Add(new Account()
            {
                Username = "Test3",
                Password = "123",
                Roles = new string[] { "employee" }
            });
        }
        public Account? find(string username)
        {
            return accounts.SingleOrDefault(x => x.Username.Equals(username));
        }
        public Account? login(string username, string password)
        {
            return accounts.SingleOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
        }
    }
}
