namespace Lab4_MVC.DAL
{
    using Lab4_MVC.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext1")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }


}
