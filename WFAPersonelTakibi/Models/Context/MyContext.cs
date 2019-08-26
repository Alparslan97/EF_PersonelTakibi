namespace WFAPersonelTakibi.Models.Context
{
    using System.Data.Entity;
    using Entities;
    public class MyContext : DbContext
    {

        public MyContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}