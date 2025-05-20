namespace TAFrame.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PageUrlAttribute : System.Attribute
    {
        public string Url { get; }
        public PageUrlAttribute(string url) => Url = url;
    }
}
