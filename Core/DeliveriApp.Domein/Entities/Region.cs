﻿namespace DeliveriApp.Domein.Entities
{
    class Region : BaseProperties
    {
        public Guid CiteId { get; set; }
        public City City { get; set; }

        public IEnumerable<RegionOrder> RegionOrder { get; set; }

    }
}
