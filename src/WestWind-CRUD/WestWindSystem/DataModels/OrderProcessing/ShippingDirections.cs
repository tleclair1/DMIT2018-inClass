namespace WestWindSystem.DataModels.OrderProcessing
{
    public class ShippingDirections
    {
        public int ShipperID { get; set; }
        public string TrackingCode { get; set; }
        public decimal? FreightCharge { get; set; }
    }
}
