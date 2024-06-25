using Bira.App.TechsysLog.Domain.DTOs.Request;

namespace Bira.App.TechsysLog.Domain.DTOs.Response
{
    public class RequestResponse
    {
        public int Number { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public bool Delivered { get; set; }
        public DateTime? DateDelivery { get; set; }
    }
}
