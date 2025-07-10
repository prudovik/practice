namespace task07;

using System;
using System.Reflection;

public static class ReflectionHelper
{
    public static void PrintTypeInfo(Type type)
    {
        var dispname = type.GetCustomAttribute<DisplayNameAttribute>();
        if(dispname != null) Console.WriteLine(dispname.DisplayName);

        var version = type.GetCustomAttribute<VersionAttribute>();
        if (version != null) Console.WriteLine($"{version.Major}.{version.Minor}");

        foreach (var method in type.GetMethods())
        {
            var methname = method.GetCustomAttribute<DisplayNameAttribute>();
            if (methname != null) Console.WriteLine(methname.DisplayName);

        }

        foreach (var property in type.GetProperties())
        {
            var propname = property.GetCustomAttribute<DisplayNameAttribute>();
            if (propname != null) Console.WriteLine(propname.DisplayName);

        }
    }
}
