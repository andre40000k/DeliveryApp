﻿namespace DeliveriApp.Domein.Entities
{
    public class Order : BaseProperties
    {
        public Guid RegionId { get; set; }
        public Region Region { get; set; }

        public int OrderId { get; set; }
        public double OrderWeight { get; set; }
        public DateTime DeliveriTime { get; set; }
    }
}