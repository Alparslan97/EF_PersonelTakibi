using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFAPersonelTakibi.Models.Entities
{
    public class Employee
    {
        public Employee()
        {
            this.Id = Guid.NewGuid();
            this.HireDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Mail { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; private set; }
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }




        [NotMapped] // veri tabanına ekleme :)
        public bool HasImage { get; set; }
    }
}
