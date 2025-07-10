namespace LibraryInfo;

using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        string libPath = Console.ReadLine();
        var asm = Assembly.LoadFrom(libPath);
        Console.WriteLine("Список классов:");
        foreach(var type in asm.GetTypes()) Console.WriteLine(type.Name);
        foreach(var type in asm.GetTypes())
        {
            Console.WriteLine($"Список методов и конструкторов класса {type.Name}:");
            foreach(var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                Console.WriteLine(method.Name);
                Console.WriteLine($"Список параметров метода/конструктора {method.Name}:");
                foreach(var parameter in method.GetParameters()) Console.WriteLine($"{parameter.Name} типа {parameter.ParameterType}");
            }
            Console.WriteLine($"Список аттрибутов класса {type.Name}:");
            foreach(var attribute in type.GetCustomAttributes()) Console.WriteLine(attribute);
        }
    }
}
