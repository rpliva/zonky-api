namespace Rpliva.Zonky.Client.OAuth
{
    public class Token
    {
        public Token(string access_token, string token_type, string refresh_token, int expires_in, string scope)
        {
            AccessToken = access_token;
            TokenType = token_type;
            RefreshToken = refresh_token;
            ExpiresIn = expires_in;
            Scope = scope;
        }

        public string AccessToken { get; private set; }
        public string TokenType { get; private set; }
        public string RefreshToken { get; private set; }
        public int ExpiresIn { get; private set; }
        public string Scope { get; private set; }
    }
}