namespace task05tests;

using Xunit;
using task05;

public class TestClass
{
    public int PublicField;
    private string _privateField;
    public int Property { get; set; }

    public void Method() { }
}

[Serializable]
public class AttributedClass { }

public class ClassAnalyzerTests
{
    [Fact]
    public void GetPublicMethods_ReturnsCorrectMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methods = analyzer.GetPublicMethods();

        Assert.Contains("Method", methods);
    }

    [Fact]
    public void GetAllFields_IncludesPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var fields = analyzer.GetAllFields();

        Assert.Contains("_privateField", fields);
    }

    [Fact]
    public void GetMethodParams_ReturnsCorrectParameters()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var parameters = analyzer.GetMethodParams("Method");

        Assert.Equal(0, parameters.Count());
    }

    [Fact]
    public void GetProperties_ReturnsAllProperties()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var properties = analyzer.GetProperties();

        Assert.Contains("Property", properties);
        Assert.Equal(1, properties.Count());
    }

    [Fact]
    public void HasAttributeT_WorksCorrectly()
    {
        var analyzer1 = new ClassAnalyzer(typeof(AttributedClass));
        var result1 = analyzer1.HasAttribute<SerializableAttribute>();

        var analyzer2 = new ClassAnalyzer(typeof(TestClass));
        var result2 = analyzer2.HasAttribute<SerializableAttribute>();

        Assert.True(result1);
        Assert.False(result2);
    }
}