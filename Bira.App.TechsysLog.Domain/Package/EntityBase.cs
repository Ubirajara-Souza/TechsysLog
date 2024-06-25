using System.ComponentModel.DataAnnotations;

namespace Bira.App.TechsysLog.Domain.Package
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
            DateRegister = DateTime.Now;
        }

        [Key]
        [Required]
        public Guid Id { get; set; }
        public DateTime DateRegister { get; set; }
        public virtual DateTime? DateDeactivation { get; set; }
        public DateTime? DataUpdate { get; set; }
    }
}
