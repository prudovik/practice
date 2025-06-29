namespace task02;

using System;
using System.Collections.Generic;
using System.Linq;

public class StudentService
{
    private readonly List<Student> _students;

    public StudentService(List<Student> students) => _students = students;

    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
    => from student in _students where student.Faculty == faculty select student;

    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade)
    => from student in _students where student.Grades.Average() >= minAverageGrade select student;

    public IEnumerable<Student> GetStudentsOrderedByName()
    => from student in _students orderby student.Name select student;

    public ILookup<string, Student> GroupStudentsByFaculty()
    => _students.ToLookup(student => student.Faculty);

    public string GetFacultyWithHighestAverageGrade()
    => _students.GroupBy(student => student.Faculty).Select(s => new
    {
        Faculty = s.Key, averageGrade = s.Average(student => student.Grades.Average())
    }).OrderByDescending(s => s.averageGrade).First().Faculty;
}