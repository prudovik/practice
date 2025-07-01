namespace task05;

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

public class ClassAnalyzer
{
    private Type _type;

    public ClassAnalyzer(Type type)
    {
        _type = type;
    }

    public IEnumerable<string> GetPublicMethods()
    => _type.GetMethods().Select(member => member.Name);

    public IEnumerable<string?> GetMethodParams(string methodname)
    {
        var method = _type.GetMethod(methodname);
        return method.GetParameters().Select(parameter => parameter.Name);
    }

    public IEnumerable<string> GetAllFields()
    => _type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Select(member => member.Name);

    public IEnumerable<string> GetProperties()
    => _type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Select(member => member.Name);

    public bool HasAttribute<T>() where T : Attribute
    => _type.GetCustomAttributes(typeof(T), false).Length > 0;
}