using Bira.App.TechsysLog.Domain.Package;

namespace Bira.App.TechsysLog.Domain.Entities
{
    public class Request : EntityBase
    {
        public int Number { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime? DateDelivery { get; set; }
        public virtual Address Address { get; set; }
    }
}
