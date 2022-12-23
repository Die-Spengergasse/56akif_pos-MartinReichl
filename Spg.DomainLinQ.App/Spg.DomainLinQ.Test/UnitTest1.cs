using Microsoft.EntityFrameworkCore;
using Spg.DomainLinQ.App.Infrastructure;
using Spg.DomainLinQ.App.Model;

namespace Spg.DomainLinQ.Test
{
    public class UnitTest1
    {
        private School2000Context GenerateDb()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=./../../../School2000.db");

            School2000Context db = new School2000Context(optionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        [Fact]
        public void Teacher_Add_OneEntity_SuccessTest()
        {
            // 1. Arrange
            School2000Context db = GenerateDb();
            Teacher newTeacher = new Teacher("Firstname", "Lastname", "EMail", Gender.Female, Guid.NewGuid(), new Address("Street", "Zip", "City"));

            // 2. Act
            db.Teachers.Add(newTeacher);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Teachers.Count());
        }

        [Fact]
        public void SchoolClass_Add_OneEntity_SuccessTest()
        {
            // 1. Arrange
            School2000Context db = GenerateDb();
            SchoolClass newSchoolClass = new SchoolClass("Test SchoolClass",
                        new Teacher("Firstname", "Lastname", "email", Gender.Male, Guid.NewGuid(), new Address("street", "zip", "city")),
                        Guid.NewGuid());

            // 2. Act
            db.SchoolClasses.Add(newSchoolClass);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.SchoolClasses.Count());
        }

        [Fact]
        public void Subject_Add_OneEntity_SuccessTest()
        {
            // 1. Arrange
            School2000Context db = GenerateDb();
            Subject newSubject = new Subject("Test Subject", new SchoolClass("Test SchoolClass",
                                                                new Teacher("Firstname", "Lastname", "email", Gender.Male, Guid.NewGuid(), new Address("street", "zip", "city")),
                                                                Guid.NewGuid()));

            // 2. Act
            db.Subjects.Add(newSubject);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.SchoolClasses.Count());
        }

        [Fact]
        public void Exam_Add_OneEntity_SuccessTest()
        {
            // 1. Arrange
            School2000Context db = GenerateDb();
            Exam newExam = new Exam(Guid.NewGuid(), 
                DateTime.UtcNow.AddDays(7), 
                1, 
                3,
                new Subject("Test Subject", 
                    new SchoolClass("Test SchoolClass", 
                        new Teacher("Firstname", "Lastname", "email", Gender.Male, Guid.NewGuid(), new Address("street", "zip", "city")),
                        Guid.NewGuid())),
                DateTime.Now);

            // 2. Act
            db.Exams.Add(newExam);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Exams.Count());
        }
    }
}