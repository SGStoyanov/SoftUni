namespace SoftUniDbORMSystem
{
    public partial class Employee
    {
        public override string ToString()
        {
            return string.Format(
                "{0} {1} {2} - Position: {3}, Salary: {4:C}",
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.JobTitle,
                this.Salary);
        }
    }
}