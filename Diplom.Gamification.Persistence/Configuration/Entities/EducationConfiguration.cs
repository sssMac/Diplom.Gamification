using Diplom.Gamification.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diplom.Gamification.Persistence.Configuration.Entities
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course { Id = Guid.Parse("d33027fc-4b48-4b54-a77d-8931d270257c"), Title = "Introduction to C#", 
                    Description = "Learn the basics of C# programming language.", Level = 1, CreatedAt = DateTime.UtcNow, CreatedBy = "Emily Johnson"
                },
                new Course { Id = Guid.Parse("f9554ddd-897a-4c7e-8840-e89d1075c053"), Title = "Advanced C#", 
                    Description = "Explore advanced topics in C# programming.", Level = 2, CreatedAt = DateTime.UtcNow, CreatedBy = "John Smith"
                }
                );
        }
    }

    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasData(
                new Lesson { Id = Guid.Parse("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"), Title = "Basics of C#", 
                    Content = "This lesson covers basic syntax and concepts of C#.", CourseId = Guid.Parse("d33027fc-4b48-4b54-a77d-8931d270257c"), CreatedAt = DateTime.UtcNow },
                new Lesson { Id = Guid.Parse("0ca39402-5d58-42e4-b354-6d66723b449e"), Title = "Advanced Concepts", 
                    Content = "This lesson explores advanced features of C#.", CourseId = Guid.Parse("d33027fc-4b48-4b54-a77d-8931d270257c"), CreatedAt = DateTime.UtcNow },
                new Lesson { Id = Guid.Parse("c004c26e-3be6-4581-8989-a4478e8065e2"), Title = "Parallel Programming", 
                    Content = "Learn how to write parallel programs in C#.", CourseId = Guid.Parse("f9554ddd-897a-4c7e-8840-e89d1075c053"), CreatedAt = DateTime.UtcNow }
                );
        }
    }

    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasData(
                new Assignment { Id = Guid.Parse("e8de9c11-44b5-42d6-baee-0f04f3638047"), Title = "Basics of C#", 
                    LessonId = Guid.Parse("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"), Description = "Complete the exercises from Chapter 5.", CreatedAt = DateTime.UtcNow },
                new Assignment { Id = Guid.Parse("7a975ea2-ee10-45b7-85d7-d5c646e828fd"), Title = "Advanced Concepts", 
                    LessonId = Guid.Parse("0ca39402-5d58-42e4-b354-6d66723b449e"),Description = "Write a program to implement the sorting algorithm discussed in class.", CreatedAt = DateTime.UtcNow },
                new Assignment { Id = Guid.Parse("3e7688d0-be96-4e3c-9450-432710b31c7b"), Title = "Parallel Programming", 
                    LessonId = Guid.Parse("c004c26e-3be6-4581-8989-a4478e8065e2"), Description = "Complete the exercises from Chapter 4.", CreatedAt = DateTime.UtcNow }
                );
        }
    }
}
