using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace LinqEx
{
    class StartUp
    {
        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Group { get; set; }

            public Student(string firstName, string lastName, int group)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Group = group;
            }
        }

        public static void Main()
        {
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0]+" "+studentInfo[1];

                var group = int.Parse(studentInfo[2]);

                var currentStudent = new Student(firstName, "", group);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }

            var groups = students.GroupBy(s => s.Group, s => s.FirstName);

            foreach (var group in groups.OrderBy(g => g.Key))
            {
                Console.WriteLine($"{group.Key} - {string.Join(", ", group)}");
            }

        }

        public static void StudentsGroupByGroup()
        {
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0] + " " + studentInfo[1];

                var group = int.Parse(studentInfo[2]);

                var currentStudent = new Student(firstName, "", group);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }

            var groups = students.GroupBy(s => s.Group, s => s.FirstName);

            foreach (var group in groups.OrderBy(g => g.Key))
            {
                Console.WriteLine($"{group.Key} - {string.Join(", ", group)}");
            }

        }


        public class StudentG
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<int> Grades { get; set; }

            public StudentG(string firstName, string lastName, List<int> grades)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Grades = grades;
            }
        }


        public static void StudentsByYear()
        {
            var input = Console.ReadLine();
            var students = new List<StudentG>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                var grades = new List<int>();
                for (int i = 1; i < studentInfo.Length; i++)
                {
                    grades.Add(int.Parse(studentInfo[i]));
                }

                var currentStudent = new StudentG(firstName, lastName, grades);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }


            students.Where(s => s.FirstName.EndsWith("14") || s.FirstName.EndsWith("15")).ToList().ForEach(s => Console.WriteLine(string.Join(" ", s.Grades)));
        }

        public static void WeakStudents()
        {
            var input = Console.ReadLine();
            var students = new List<StudentG>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                var grades = new List<int>();
                for (int i = 2; i < studentInfo.Length; i++)
                {
                    grades.Add(int.Parse(studentInfo[i]));
                }

                var currentStudent = new StudentG(firstName, lastName, grades);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }


            students.Where(s => s.Grades.FindAll(g => g <= 3).Count >= 2).ToList().ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }

        public static void ExcellentStudents()
        {
            var input = Console.ReadLine();
            var students = new List<StudentG>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                var grades = new List<int>();
                for (int i = 2; i < studentInfo.Length; i++)
                {
                    grades.Add(int.Parse(studentInfo[i]));
                }

                var currentStudent = new StudentG(firstName, lastName, grades);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }


            students.Where(s => s.Grades.Contains(6)).ToList().ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }

        public class StudentS
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }

            public StudentS(string firstName, string lastName, string email)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Email = email;
            }
        }

        public static void StudentsByPhone()
        {
            var input = Console.ReadLine();
            var students = new List<StudentS>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                var phone = studentInfo[2];

                var currentStudent = new StudentS(firstName, lastName, phone);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }


            students.Where(s => s.Email.StartsWith("02") || s.Email.StartsWith("+3592")).ToList().ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }

        public static void StudentSByEmail()
        {
            var input = Console.ReadLine();
            var students = new List<StudentS>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                var email = studentInfo[2];

                var currentStudent = new StudentS(firstName, lastName, email);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }


            students.Where(s => s.Email.EndsWith("@gmail.com")).ToList().ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }


        public static void SortStudents()
        {
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                //  var age = int.Parse(studentInfo[2]);

                var currentStudent = new Student(firstName, lastName, 1);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }


            students.OrderBy(s => s.LastName).ThenByDescending(s => s.FirstName).ToList().ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }

        public static void StudentsByAge()
        {
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                var age = int.Parse(studentInfo[2]);

                var currentStudent = new Student(firstName, lastName, age);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }

            var result = students.Where(s => s.Group >= 18 && s.Group <= 24).ToList();

            result.ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} {s.Group}"));
        }

        public static void StudentsByFirstAndLAstName()
        {
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];

                //   var group = int.Parse(studentInfo[2]);

                var currentStudent = new Student(firstName, lastName, 1);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }

            var result = students.Where(s => s.FirstName.CompareTo(s.LastName) == -1).ToList();

            result.ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }

        public static void StudentsByFirstName()
        {
            var input = Console.ReadLine();
            var students = new List<Student>();

            while (!input.Equals("END"))
            {
                var studentInfo = input.Split();
                var firstName = studentInfo[0];
                var lastName = studentInfo[1];

                var group = int.Parse(studentInfo[2]);

                var currentStudent = new Student(firstName, lastName, group);
                students.Add(currentStudent);

                input = Console.ReadLine();
            }

            var result = students.Where(s => s.Group == 2).OrderBy(s => s.FirstName).ToList();

            result.ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }

   
}
