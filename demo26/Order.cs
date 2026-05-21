using System;

namespace demo26
{
    public class Order
    {
        public int Id { get; set; }

        public string Article { get; set; }

        public string Status { get; set; }

        public int PickupPointId { get; set; }

        public string PickupPointAddress { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
