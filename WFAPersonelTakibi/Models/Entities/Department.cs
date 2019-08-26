using System;
using System.Collections.Generic;

namespace WFAPersonelTakibi.Models.Entities
{
    public class Department
    {
        public Department()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
