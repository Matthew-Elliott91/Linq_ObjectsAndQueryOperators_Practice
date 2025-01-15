namespace Linq_ObjectsAndQueryOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
        

            UniversityManager um = new UniversityManager();

            um.FemaleStudents();



        }

         class UniversityManager
        {
            public List<University> universities;
            public List<Student> students;

            //Constructor
            public UniversityManager()
            {
                universities = new List<University>();
                students = new List<Student>();

                //Adding universities
                universities.Add(new University { Id = 1, Name = "Oxford" });
                universities.Add(new University { Id = 2, Name = "Harvard" });

                //Adding students
                students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1 });
                students.Add(new Student { Id = 2, Name = "Tom", Gender = "male", Age = 21, UniversityId = 1 });
                students.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 22, UniversityId = 2 });
                students.Add(new Student { Id = 4, Name = "Peter", Gender = "male", Age = 31, UniversityId = 2 });
                students.Add(new Student { Id = 5, Name = "Gale", Gender = "male", Age = 23, UniversityId = 1 });



            }

            public void FemaleStudents()
            {
                IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;

                foreach (var student in femaleStudents)
                {
                    student.Print();
                }
            }

            public void MalesStudents()
            {
                IEnumerable<Student> maleStudents =
                    from student in students where student.Gender == "male" select student;

                foreach (var student in maleStudents)
                {
                    student.Print();
                }
            }

        }

        class University
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public void Print()
            {
                Console.WriteLine($"University {Name} with id {Id}");
            }
        }

        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }

            //Foreign key

            public int UniversityId { get; set; }

            public void Print()
            {
                Console.WriteLine($"Student {Name} with ID {Id}, Gender {Gender} and Age {Age} from the University with the ID {UniversityId}");
            }
        }
    }
}
