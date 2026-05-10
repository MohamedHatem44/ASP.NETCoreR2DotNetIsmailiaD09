using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanySystem.DAL
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        /*------------------------------------------------------------------*/
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Salary).HasColumnType("decimal(8,2)");

            // One To Many 
            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired();
        }
        /*------------------------------------------------------------------*/
    }
}
