namespace task07;

using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
public class DisplayNameAttribute(string name) : Attribute
{
    public string DisplayName { get; } = name;
}
