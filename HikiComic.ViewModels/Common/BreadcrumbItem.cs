namespace HikiComic.ViewModels.Common
{
    public class BreadcrumbItem
    {
        public string Title { get; set; } = null!;

        public string AspAction { get; set; } = null!;

        public string AspController { get; set; } = null!;

        public IDictionary<string, string> AspRoutes { get; set; } = new Dictionary<string, string>();


    }
}
