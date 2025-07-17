namespace SerializationConsole;

using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using task13;

public class Program
{
    public static void Main()
    {
        Student student = new Student {FirstName = "Ivan", LastName = "Ivanov",
        BirthDate = new DateTime(year: 2001, month: 1, day: 2),
        Grades = new List<Subject> {new Subject {Name = "Math", Grade = 5},
                                    new Subject {Name = "Science", Grade = 3}}};
        var settings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd", NullValueHandling = NullValueHandling.Ignore };
        var json = JsonConvert.SerializeObject(student, Formatting.Indented, settings);
        Console.WriteLine(json);
        File.WriteAllText("student.json", json);
        var restoredStudent = JsonConvert.DeserializeObject<Student>(json, settings);
        Console.WriteLine(restoredStudent.FirstName);
        Console.WriteLine(restoredStudent.LastName);
        Console.WriteLine(restoredStudent.BirthDate);
        foreach(var grade in restoredStudent.Grades)
        {
            Console.WriteLine(grade.Name);
            Console.WriteLine(grade.Grade);
        }
    }
}
