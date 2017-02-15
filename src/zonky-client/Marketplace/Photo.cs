namespace Rpliva.Zonky.Client.Marketplace
{
    public class Photo
    {
        public Photo(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public string Name { get; private set; }
        public string Url { get; private set; }
    }
}