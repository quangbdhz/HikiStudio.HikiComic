using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class ServicePrice : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int ServicePriceId { get; set; }

        public string ServicePriceName { get; set; } 
        
        public string? Description { get; set; }

        public double Price { get; set; }
    }
}
