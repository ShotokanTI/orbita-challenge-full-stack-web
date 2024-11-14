using Desafio_A__Educacao.Domain.Entities;

namespace Infra.Seed
{
    public static class StudentSeed
    {
        public static List<Student> GetStudents()
        {
            var students = new List<Student>();
            for (int i = 1; i <= 200; i++)
            {
                students.Add(new Student
                {
                    Id = i,
                    Name = $"Student {i}",
                    Email = $"student{i}@example.com",
                    RA = $"RA{i:D6}",
                    CPF = $"123456789{i:D2}"
                });
            }
            return students;
        }
    }
}
