namespace Linq_ObjectsAndQueryOperators;

internal class Program
{
    private static void Main(string[] args)
    {
        var um = new UniversityManager();

        um.FemaleStudents();
        um.MalesStudents();
        um.SortStudentsByAge();
        um.AllStudentsFromOxford();
        //um.GetStudentsByInputID();
        um.studentAndUniversityNameCollection();
    }

    private class UniversityManager
    {
        public readonly List<Student> students;
        public readonly List<University> universities;

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
            IEnumerable<Student> femaleStudents =
                from student in students where student.Gender == "female" select student;
            Console.WriteLine("Female Students: ");

            foreach (var student in femaleStudents) student.Print();
        }

        public void MalesStudents()
        {
            Console.WriteLine("");
            IEnumerable<Student> maleStudents =
                from student in students where student.Gender == "male" select student;
            Console.WriteLine("Male Students: ");


            foreach (var student in maleStudents) student.Print();
        }

        public void SortStudentsByAge()
        {

            Console.WriteLine("");
            IEnumerable<Student> studentByAge = from student in students orderby student.Age select student;
            Console.WriteLine("Students sorted by Age: ");


            foreach (var student in studentByAge) student.Print();
        }

        public void AllStudentsFromOxford()
        {
            Console.WriteLine("");
            IEnumerable<Student> oxfordStudents =
                from student in students
                join university in universities on student.UniversityId equals university.Id
                where university.Name == "Oxford"
                select student;

            foreach (var student in oxfordStudents)
            {
                student.Print();
            }
        }

        public void GetStudentsByInputID()
        {
            Console.WriteLine("Please input university id.  1 = Oxford 2 = Harvard");
            
            int id = int.Parse(Console.ReadLine());

            IEnumerable<Student> studentByUniversityId =
                from student in students where student.UniversityId == id select student;

            foreach (var student in studentByUniversityId)
            {
                student.Print();
            }

        }

        public void studentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                join university in universities on student.UniversityId equals university.Id
                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection: ");

            foreach (var col in newCollection)
            {
                Console.WriteLine($"Student {col.StudentName} from {col.UniversityName} ");
                
            }
        }
    }

    private class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"University {Name} with id {Id}");
        }
    }

    private class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        //Foreign key

        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine(
                $"Student {Name} with ID {Id}, Gender {Gender} and Age {Age} from the University with the ID {UniversityId}");
        }
    }
}