using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.ServiceConfigs
{
    public class ServiceConfigViewModel : BaseViewModel<Guid>
    {
        public int ServiceConfigId { get; set; }

        public string ServiceConfigName { get; set; }

        public string? Description { get; set; }

        public int Value { get; set; }

        public string StringValue { get; set; }

        public string? Note { get; set; }
    }
}
