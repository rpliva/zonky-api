namespace Rpliva.Zonky.Client
{
    public class Config
    {
        public Config(string username, string password, string server)
        {
            Username = username;
            Password = password;
            Server = server;
        }

        public string Server { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}