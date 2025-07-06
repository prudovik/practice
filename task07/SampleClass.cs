namespace task07;

[DisplayNameAttribute("Пример класса"), VersionAttribute(1, 0)]
public class SampleClass
{
    [DisplayNameAttribute("Тестовый метод")]
    public void TestMethod() { }

    [DisplayNameAttribute("Числовое свойство")]
    public int Number { get; set; }
}
