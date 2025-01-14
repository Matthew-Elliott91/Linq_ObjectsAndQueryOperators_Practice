namespace Linq_ObjectsAndQueryOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
                students.Add(new Student { Id = 2, Name = "Leyla", Gender = "female", Age = 22, UniversityId = 2 });
                students.Add(new Student { Id = 2, Name = "Peter", Gender = "male", Age = 31, UniversityId = 2 });
                students.Add(new Student { Id = 2, Name = "Gale", Gender = "male", Age = 23, UniversityId = 1 });



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
