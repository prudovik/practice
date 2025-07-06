namespace task07;

using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
public class VersionAttribute(int maj, int min) : Attribute
{
    public int Major { get; } = maj;
    public int Minor { get; } = min;
}
