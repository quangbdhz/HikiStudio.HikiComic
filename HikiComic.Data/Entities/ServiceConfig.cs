using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class ServiceConfig : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int ServiceConfigId { get; set; }


        public string ServiceConfigName { get; set; }

        public string? Description { get; set; }

        public string StringValue { get; set; }

        public int Value { get; set; }

        public string? Note { get; set; }
    }
}
