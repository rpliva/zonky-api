namespace Rpliva.Zonky.Client.Common
{
    public class Paging
    {
        public Paging(int page, int size)
        {
            Page = page;
            Size = size;
        }

        public int Page { get; private set; }
        public int Size { get; private set; }
    }
}
