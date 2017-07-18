using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsJoinedSpecialties
{
    public class StartUp
    {
        public class Student
        {
            public string StudentsName { get; set; }
            public string FacultyNumber { get; set; }

            public Student(string facultyNumber, string studentsName)
            {
                this.StudentsName = studentsName;
                this.FacultyNumber = facultyNumber;
            }
        }

        public class StudentSpecialty
        {
            public StudentSpecialty(string specialty, string facultyNumber)
            {
                this.FacultyNumber = facultyNumber;
                this.Specialty = specialty;
            }

            public string FacultyNumber { get; set; }
            public string Specialty { get; set; }
        }

        public static void Main()
        {
            string input = Console.ReadLine();
            var specialityList = new List<StudentSpecialty>();
            var students = new List<Student>();
            while (!input.Equals("Students:"))
            {
                var tokens = input.Split();
                var speciality = tokens[0] + " " + tokens[1];
                var facultyNumber = tokens[2];
                var currentStudent = new StudentSpecialty(speciality, facultyNumber);
                specialityList.Add(currentStudent);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                var tokens = input.Split();
                var studentName = tokens[1] + " " + tokens[2];
                var facultyNumber = tokens[0];
                var currentStudent = new Student(facultyNumber, studentName);
                students.Add(currentStudent);
                input = Console.ReadLine();
            }

            var result = students.Join(specialityList,
                st => st.FacultyNumber,
                sp => sp.FacultyNumber,
                (st, sp) => new { st.StudentsName, st.FacultyNumber, sp.Specialty });

            foreach (var item in result.OrderBy(x => x.StudentsName))
            {
                Console.WriteLine($"{item.StudentsName} {item.FacultyNumber} {item.Specialty}");
            }
        }
    }
}