using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.ServicePriceConfigs
{
    public class ServicePriceConfigViewModel : BaseViewModel<Guid>
    {
        public int ServicePriceId { get; set; }

        public string ServicePriceName { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }
    }
}
