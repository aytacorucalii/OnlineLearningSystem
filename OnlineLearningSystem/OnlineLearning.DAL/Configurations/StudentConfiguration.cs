using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearning.Core.Models;

namespace OnlineLearning.DAL.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
	public void Configure(EntityTypeBuilder<Student> builder)
	{
	
		builder.ToTable("Students");

		// Primary key
		builder.HasKey(s => s.Id);

		builder.Property(s => s.Name)
			   .IsRequired()
			   .HasMaxLength(100);
		builder.Property(s => s.Surname)
			   .IsRequired()
			   .HasMaxLength(150);

		
		builder.HasMany(s => s.EnrolledCourses)
			   .WithMany(c => c.EnrolledStudents)
			   .UsingEntity(j => j.ToTable("CourseEnrollments")); // This will create the intermediate table implicitly
	}
}
