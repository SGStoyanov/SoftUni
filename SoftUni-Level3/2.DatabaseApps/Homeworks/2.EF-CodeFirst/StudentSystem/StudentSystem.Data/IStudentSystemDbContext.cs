namespace StudentSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using StudentSystem.Models;

    public interface IStudentSystemDbContext
    {
        IDbSet<Student> Students { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Resource> Resources { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}