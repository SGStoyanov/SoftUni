namespace FunctionalityExtender
{
    using System.Data.Linq;
    using SoftUniDbORMSystem;

    public partial class Employee
    {
        public Employee()
        {
            this.Territories = new EntitySet<Territory>();
        }

        public EntitySet<Territory> Territories { get; set; }
    }
}