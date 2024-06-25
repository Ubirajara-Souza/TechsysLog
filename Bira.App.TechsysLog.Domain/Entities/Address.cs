using Bira.App.TechsysLog.Domain.Package;

namespace Bira.App.TechsysLog.Domain.Entities
{
    public class Address : EntityBase
    {
        public string? Street { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }

        public string? Neighborhood { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }
        public Guid RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}
