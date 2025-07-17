namespace task13tests;

using task13;
using SerializationConsole;
using Xunit;
using System.IO;

public class SerializationTests
{
    [Fact]
    public void CorrectWorkTest()
    {
        Student student = new Student {FirstName = "Ivan", LastName = "Ivanov",
        BirthDate = new DateTime(year: 2001, month: 10, day: 2),
        Grades = new List<Subject> {new Subject {Name = "Math", Grade = 5},
                                    new Subject {Name = "Science", Grade = 3}}};
        var output = new StringWriter();
        Console.SetOut(output);
        string result = "{\n  \"FirstName\": \"Ivan\",\n  \"LastName\": \"Ivanov\",\n  \"BirthDate\": \"2001-01-02\",\n  \"Grades\": [\n    {\n      \"Name\": \"Math\",\n      \"Grade\": 5\n    },\n    {\n      \"Name\": \"Science\",\n      \"Grade\": 3\n    }\n  ]\n}\nIvan\nIvanov\n01/02/2001 00:00:00\nMath\n5\nScience\n3\n";
        Program.Main();
        Assert.Equal(result, output.ToString());
    }
}